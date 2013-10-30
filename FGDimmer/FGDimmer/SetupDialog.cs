using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace FGDimmer {
    internal partial class SetupDialog : Form {
        SerialPort m_selectedPort;
        Module[] m_modules;

        public SetupDialog(SerialPort selectedPort, Module[] modules, int startChannel, int endChannel, bool holdPort, bool acOperation) {
            InitializeComponent();

            m_selectedPort = selectedPort;
            m_modules = modules;

            for(; startChannel <= endChannel; startChannel++) {
                comboBoxModule1.Items.Add(startChannel);
                comboBoxModule2.Items.Add(startChannel);
                comboBoxModule3.Items.Add(startChannel);
                comboBoxModule4.Items.Add(startChannel);
            }

            checkBoxModule1.Checked = m_modules[0].Enabled;
            if(checkBoxModule1.Checked) {
                if(m_modules[0].StartChannel >= (int)comboBoxModule1.Items[0]) {
                    comboBoxModule1.SelectedItem = m_modules[0].StartChannel;
                }
            }

            checkBoxModule2.Checked = m_modules[1].Enabled;
            if(checkBoxModule2.Checked) {
                if(m_modules[1].StartChannel >= (int)comboBoxModule2.Items[0]) {
                    comboBoxModule2.SelectedItem = m_modules[1].StartChannel;
                }
            }

            checkBoxModule3.Checked = m_modules[2].Enabled;
            if(checkBoxModule3.Checked) {
                if(m_modules[2].StartChannel >= (int)comboBoxModule3.Items[0]) {
                    comboBoxModule3.SelectedItem = m_modules[2].StartChannel;
                }
            }

            checkBoxModule4.Checked = m_modules[3].Enabled;
            if(checkBoxModule4.Checked) {
                if(m_modules[3].StartChannel >= (int)comboBoxModule4.Items[0]) {
                    comboBoxModule4.SelectedItem = m_modules[3].StartChannel;
                }
            }

            checkBoxHoldPort.Checked = holdPort;
            if(acOperation) {
                radioButtonAC.Checked = true;
            } else {
                radioButtonPWM.Checked = true;
            }
        }

        public SerialPort SelectedPort {
            get { return m_selectedPort; }
        }

        public bool UsingModule1 {
            get { return checkBoxModule1.Checked; }
        }

        public bool UsingModule2 {
            get { return checkBoxModule2.Checked; }
        }

        public bool UsingModule3 {
            get { return checkBoxModule3.Checked; }
        }

        public bool UsingModule4 {
            get { return checkBoxModule4.Checked; }
        }

        public int Module1StartChannel {
            get { return (int)comboBoxModule1.SelectedItem; }
        }

        public int Module2StartChannel {
            get { return (int)comboBoxModule2.SelectedItem; }
        }

        public int Module3StartChannel {
            get { return (int)comboBoxModule3.SelectedItem; }
        }

        public int Module4StartChannel {
            get { return (int)comboBoxModule4.SelectedItem; }
        }

        public bool HoldPort {
            get { return checkBoxHoldPort.Checked; }
        }

        public bool ACOperation {
            get { return radioButtonAC.Checked; }
        }

        private void buttonSerialSetup_Click(object sender, EventArgs e) {
            Vixen.Dialogs.SerialSetupDialog serialSetupDialog = new Vixen.Dialogs.SerialSetupDialog(m_selectedPort);
            if(serialSetupDialog.ShowDialog() == DialogResult.OK) {
                m_selectedPort = serialSetupDialog.SelectedPort;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if(m_modules[0].Enabled = checkBoxModule1.Checked) {
                m_modules[0].StartChannel = (int)comboBoxModule1.SelectedItem;
            }
            if(m_modules[1].Enabled = checkBoxModule2.Checked) {
                m_modules[1].StartChannel = (int)comboBoxModule2.SelectedItem;
            }
            if(m_modules[2].Enabled = checkBoxModule3.Checked) {
                m_modules[2].StartChannel = (int)comboBoxModule3.SelectedItem;
            }
            if(m_modules[3].Enabled = checkBoxModule4.Checked) {
                m_modules[3].StartChannel = (int)comboBoxModule4.SelectedItem;
            }
        }

    }
}