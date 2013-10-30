using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Vixen;

namespace TapTempo
{
    public class TapTempoAddin : IAddIn
    {
        #region IAddIn Members

        public bool Execute(EventSequence sequence)
        {
            if (sequence == null)
            {
                throw new Exception("Tap Tempo requires a sequence to be open.");
            }
            MainDialog dialog = new MainDialog(sequence);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Update the sequence's EventPeriod
                if (dialog.UpdateEventPeriod)
                {
                    sequence.EventPeriod = dialog.EventPeriod;
                    MessageBox.Show(String.Format("{1} has updated the sequence Event Period to {0} ms.", dialog.EventPeriod, this.Name),
                        this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Insert the beats
                if (dialog.InsertBeats)
                {
                    for (int i = 0; i < sequence.TotalEventPeriods; i += dialog.EventsPerBeat)
                        sequence.EventValues[dialog.BeatChannelNumber, i] = 0xFF;
                }
                

                dialog.Dispose();
                return true;
            }
            else
            {
                dialog.Dispose();
                return false;
            }

            
        }

        #endregion

        #region ILoadable Members

        public LoadableDataLocation DataLocationPreference
        {
            get
            {
                return LoadableDataLocation.Sequence;
            }
        }

        public void Loading(XmlNode dataNode)
        {
        }

        public void Unloading()
        {
        }

        #endregion

        #region IPlugIn Members

        public string Author
        {
            get { return "Jonathon Reinhart"; }
        }

        public string Description
        {
            get { return "Adds Tap-Tempo beat input to Vixen"; }
        }

        public string Name
        {
            get { return "Tap Tempo"; }
        }

        #endregion
    }
}
