using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO.Ports;
using System.Threading;

namespace FGDimmer {
    public class FGDimmer : Vixen.IEventDrivenOutputPlugIn {
        private List<Form> m_dialogList;
        private Vixen.SetupData m_setupData;
        private XmlNode m_setupNode;
        private SerialPort m_selectedPort = null;
        byte[][] m_packets;
        private Module[] m_modules;
        private int m_startChannel;

        Thread m_eventThread;
        AutoResetEvent m_eventTrigger;
        bool m_running = false;
        byte[] m_channelValues;
        bool m_holdPort = true;

        bool m_acOperation = false;
        #region Curve
        byte[] m_dimmingCurve = new byte[256] {
			0,18,20,23,24,27,28,31,31,33,35,37,39,40,42,43,45,
			46,48,49,50,50,51,52,53,54,54,55,56,56,56,56,56,57,
			57,56,57,58,58,58,59,58,58,58,59,59,59,59,60,61,60,
			61,61,61,61,62,62,62,62,63,63,63,63,63,63,63,63,63,
			63,64,64,64,64,65,65,66,66,67,67,68,68,68,69,69,70,
			70,71,71,72,73,73,74,74,75,75,77,77,77,78,78,79,80,
			80,80,80,81,82,83,83,84,85,85,86,87,88,89,91,92,93,
			94,96,99,101,104,107,109,115,120,135,140,146,148,151,154,156,159,
			161,162,163,164,166,167,168,169,170,170,171,172,172,173,174,175,175,
			175,175,176,177,177,178,178,178,180,180,181,181,182,182,183,184,184,
			185,185,186,186,187,187,187,188,188,189,189,190,190,191,191,191,191,
			192,192,192,192,192,192,192,192,192,192,193,193,193,193,194,194,194,
			194,194,195,195,196,196,196,196,196,197,197,197,197,197,197,198,198,
			198,199,199,199,199,199,199,200,201,201,202,203,204,205,205,206,207,
			209,210,212,213,215,216,218,220,222,224,224,227,228,231,232,235,237,
			255};
        #endregion

        public FGDimmer() {
            m_dialogList = new List<Form>();
            m_packets = new byte[][] {
                new byte[34],
                new byte[34],
                new byte[34],
                new byte[34]
            };
            for(int i = 0; i < 4; i++) {
                m_packets[i][0] = 0x55;
                m_packets[i][1] = (byte)(i+1);
            }

            m_modules = new Module[4];
            for(int i = 0; i < 4; i++) {
                m_modules[i] = new Module(i+1);
            }

            m_eventThread = new Thread(new ThreadStart(EventThread));
            m_eventTrigger = new AutoResetEvent(false);
        }

        #region PlugIn Members

        public string Author {
            get { return "K.C. Oaks"; }
        }

        public string Description {
            get { return "Output plugin for Firegod's 32-channel dimming controller"; }
        }

        public void Event(byte[] channelValues) {
            m_channelValues = channelValues;
            if(m_holdPort) {
                // Not opening and closing the port, just outputting data, so thread it.
                m_eventTrigger.Set();
            } else {
                // Opening and closing the port, so the calls need to be serialized and synchronous.
                if(!m_selectedPort.IsOpen) m_selectedPort.Open();
                FireEvent();
                m_selectedPort.Close();
            }
        }

        private void EventThread() {
            while(m_running) {
                m_eventTrigger.WaitOne();
                if(!m_running) {
                    break;
                }
                FireEvent();
            }
        }

        private void FireEvent() {
            if(!m_selectedPort.IsOpen) {
                m_selectedPort.Open();
            }

            int i;

            // Need to convert each level to a % for 100-based levels
            float multiplier = (float)100 / 255;
            if(m_acOperation) {
                // With dimming curve translation
                for(i = 0; i < m_channelValues.Length; i++) {
                    m_channelValues[i] = (byte)(m_dimmingCurve[m_channelValues[i]] * multiplier + 100);
                }
            } else {
                // No dimming curve
                for(i = 0; i < m_channelValues.Length; i++) {
                    m_channelValues[i] = (byte)(m_channelValues[i] * multiplier + 100);
                }
            }

            // Distribute the data
            int count = 0;
            Module module = null;
            for(i = 0; i < 4; i++) {
                module = m_modules[i];
                if(!module.Enabled) continue;

                // Get the max number of bytes that will be copied from the data
                // -1 because module.StartChannel starts at 1
                // m_startChannel starts at 0, and is the start channel for the data sent to this plugin
                count = Math.Min(32, m_channelValues.Length - (module.StartChannel - 1 - m_startChannel));
                // Copy the data to the module's packet
                Array.Copy(m_channelValues, module.StartChannel - 1 - m_startChannel, m_packets[i], 2, count);
                // Update the hardware
                m_selectedPort.Write(m_packets[i], 0, m_packets[i].Length);
            }
        }

        public Vixen.HardwareMap[] HardwareMap {
            get { return new Vixen.HardwareMap[] { new Vixen.HardwareMap("Serial", int.Parse(m_selectedPort.PortName.Substring(3))) }; }
        }

        // <Modules>
        //   <Module enabled=t/f id=1-4 start=#>
        //   <Module enabled=t/f id=1-4 start=#>
        //   <Module enabled=t/f id=1-4 start=#>
        //   <Module enabled=t/f id=1-4 start=#>
        // <Serial>
        //   <Name>
        //   <Port>
        //   <Baud>
        //   <Parity>
        //   <Data>
        //   <Stop>
        public void Initialize(Vixen.IExecutable executableObject, Vixen.SetupData setupData, XmlNode setupNode) {
            m_setupData = setupData;
            m_setupNode = setupNode;
            m_startChannel = int.Parse(m_setupNode.Attributes["from"].Value) - 1;

            XmlNode serialNode = Vixen.Xml.GetNodeAlways(setupNode, "Serial");
            // Construct a SerialPort from the data
            m_selectedPort = new SerialPort(
                m_setupData.GetString(serialNode, "Name", "COM1"),
                m_setupData.GetInteger(serialNode, "Baud", 115200),
                (Parity)Enum.Parse(typeof(Parity), m_setupData.GetString(serialNode, "Parity", Parity.None.ToString())),
                m_setupData.GetInteger(serialNode, "Data", 8),
                (StopBits)Enum.Parse(typeof(StopBits), m_setupData.GetString(serialNode, "Stop", StopBits.One.ToString()))
            );
            m_selectedPort.Handshake = Handshake.None;
            m_selectedPort.Encoding = Encoding.UTF8;

            XmlNode modulesNode = setupNode.SelectSingleNode("Modules");

        	if(modulesNode != null) {
                for(int i = 0; i < 4; i++) {
                	XmlNode moduleNode = modulesNode.SelectSingleNode(string.Format("Module[@id=\"{0}\"]", i + 1));
                	if(moduleNode != null) {
                        m_modules[i].Enabled = bool.Parse(moduleNode.Attributes["enabled"].Value);
                        if(m_modules[i].Enabled) {
                            m_modules[i].StartChannel = Convert.ToInt32(moduleNode.Attributes["start"].Value);
                        }
                    }
                }
            }

            m_holdPort = m_setupData.GetBoolean(m_setupNode, "HoldPort", false);
            m_acOperation = m_setupData.GetBoolean(m_setupNode, "ACOperation", false);
        }

        public string Name {
            get { return "FG Dimmer"; }
        }

        public void Setup() {
            SetupDialog setupDialog = new SetupDialog(m_selectedPort, m_modules, m_startChannel + 1, int.Parse(m_setupNode.Attributes["to"].Value), m_holdPort, m_acOperation);
            if(setupDialog.ShowDialog() == DialogResult.OK) {
                XmlNode serialNode = Vixen.Xml.GetNodeAlways(m_setupNode, "Serial");
                m_selectedPort = setupDialog.SelectedPort;
                m_setupData.SetString(serialNode, "Name", m_selectedPort.PortName);
                m_setupData.SetInteger(serialNode, "Baud", m_selectedPort.BaudRate);
                m_setupData.SetString(serialNode, "Parity", m_selectedPort.Parity.ToString());
                m_setupData.SetInteger(serialNode, "Data", m_selectedPort.DataBits);
                m_setupData.SetString(serialNode, "Stop", m_selectedPort.StopBits.ToString());

                // Update the module nodes
                XmlNode modulesNode = Vixen.Xml.GetEmptyNodeAlways(m_setupNode, "Modules");

            	for(int i = 0; i < 4; i++) {
                    XmlNode moduleNode = Vixen.Xml.SetNewValue(modulesNode, "Module", string.Empty);
                    Vixen.Xml.SetAttribute(moduleNode, "enabled", m_modules[i].Enabled.ToString());
                    Vixen.Xml.SetAttribute(moduleNode, "id", m_modules[i].ID.ToString());
                    if(m_modules[i].Enabled) {
                        Vixen.Xml.SetAttribute(moduleNode, "start", m_modules[i].StartChannel.ToString());
                    }
                }

                m_holdPort = setupDialog.HoldPort;
                m_acOperation = setupDialog.ACOperation;
                m_setupData.SetBoolean(m_setupNode, "HoldPort", m_holdPort);
                m_setupData.SetBoolean(m_setupNode, "ACOperation", m_acOperation);
            }
            setupDialog.Dispose();
        }

        public void Shutdown() {
            if(m_running) {
                m_running = false;
                m_eventTrigger.Set();
                // Give it one second to terminate.
                // Trying to avoid closing the port while the thread finishes up.
                m_eventThread.Join(1000);
            }

            if(m_selectedPort.IsOpen) {
                m_selectedPort.Close();
            }
        }

        public List<Form> Startup() {
            // Clear the modules' data buffers
            foreach(byte[] packet in m_packets) {
                Array.Clear(packet, 2, packet.Length - 2);
            }

            if(m_holdPort) {
                if(!m_selectedPort.IsOpen) {
                    m_selectedPort.Open();
                }
                // Only thread the operation if holding the port open
                m_running = true;
                m_eventThread.Start();
            }

            return m_dialogList;
        }

        public override string ToString() {
            return Name;
        }

        #endregion

    }

    #region Module
    internal class Module {
        private bool m_enabled;
        private int m_startChannel;
        private int m_id;

        public Module(int id) {
            m_id = id;
            m_enabled = false;
            m_startChannel = 1;
        }

        public bool Enabled {
            get { return m_enabled; }
            set { m_enabled = value; }
        }

        public int StartChannel {
            get { return m_startChannel; }
            set { m_startChannel = value; }
        }

        public int ID {
            get { return m_id; }
            set { m_id = value; }
        }

    }
    #endregion
}
