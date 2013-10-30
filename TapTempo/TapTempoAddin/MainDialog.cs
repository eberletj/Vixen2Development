using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FMOD;
using Vixen;

namespace TapTempo
{
    public partial class MainDialog : Form
    {
        private TapTempoCalc m_tapCalc;
        private int m_eventPeriod = 0;
        private int m_eventsPerBeat = 0;
        private EventSequence m_sequence;
        private fmod m_fmod;
        private SoundChannel m_soundChannel;
        private bool m_audioPlaying = false;


        public MainDialog(Vixen.EventSequence sequence)
        {
            InitializeComponent();
            m_tapCalc = new TapTempoCalc();
            m_sequence = sequence;

            // Handle all key presses at Form level
            this.KeyPreview = true;
            this.KeyDown +=new KeyEventHandler(MainDialog_KeyDown);

            /*** Tap Tempo things ***/
            comboBoxEventsPerBeat.SelectedIndex = 0;
            comboBoxEventsPerBeat.Focus();

            /*** Audio ***/
            // FMOD Audio Player
            if (m_sequence.Audio != null)
            {
                m_fmod = fmod.GetInstance(m_sequence.AudioDeviceIndex);
                this.m_soundChannel = this.m_fmod.LoadSound(Path.Combine(Paths.AudioPath, m_sequence.Audio.FileName), this.m_soundChannel);
                TimeSpan duration = new TimeSpan(0, 0, 0, 0, m_sequence.Audio.Duration);
                lblAudio.Text = String.Format("{0}   ({1}:{2})", m_sequence.Audio.Name,
                    duration.Minutes, duration.Seconds);
            }
            else
            {
                lblAudio.Text = "[No Audio Assigned]";
                btnPlayStop.Enabled = false;
            }

            /*** Actions ***/
            int i = 1;
            foreach (Vixen.Channel channel in m_sequence.Channels)
                comboBoxBeatChannel.Items.Add(String.Format("{0,-3}: {1}", i++, channel));
            comboBoxBeatChannel.SelectedIndex = 0;
        }


        private void MainDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAudio();
            if (m_soundChannel != null)
                m_fmod.ReleaseSound(m_soundChannel);
            if (m_fmod != null)
                m_fmod.Shutdown();
        }


        private void PlayAudio()
        {
            if (!m_audioPlaying)
            {
                m_fmod.Play(m_soundChannel);
                m_audioPlaying = true;
                btnPlayStop.Text = "Stop Audio";
            }
        }

        private void StopAudio()
        {
            if (m_audioPlaying)
            {
                m_fmod.Stop(m_soundChannel);
                m_audioPlaying = false;
                btnPlayStop.Text = "Play Audio";
            }
        }

        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            if (m_audioPlaying)
                StopAudio();
            else
                PlayAudio();
        }






        private void MainDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                e.SuppressKeyPress = true;
                m_tapCalc.Tap();
                UpdateValues();
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            m_tapCalc.Reset();
            ResetValues();
            lblBegin.Visible = true;
        }

        private void UpdateValues()
        {
            if (m_tapCalc.FirstBeat)
            {
                lblBegin.Visible = false;
                tbBPM.Text = "First Beat";
            }
            else
            {
                //tbElapsedTime.Text = m_tapCalc.ElapsedTime.TotalSeconds.ToString();
                //tbBeats.Text = m_tapCalc.Beats.ToString();
                tbBPM.Text = m_tapCalc.BPM.ToString("0.0");
                tbMsPerBeat.Text = m_tapCalc.MillisecondsPerBeat.ToString("0.0");
                CalcEventPeriod();
            }
        }

        private void CalcEventPeriod()
        {
            if (comboBoxEventsPerBeat.SelectedItem == null)
                return;
            m_eventPeriod = (int)Math.Round( (m_tapCalc.MillisecondsPerBeat / m_eventsPerBeat), 0);
            tbEventPeriod.Text = m_eventPeriod.ToString();
            if (m_eventPeriod > 0)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }

        private void ResetValues()
        {
            //tbElapsedTime.Text = String.Empty;
            //tbBeats.Text = String.Empty;
            tbBPM.Text = String.Empty;
            tbMsPerBeat.Text = String.Empty;
            tbEventPeriod.Text = String.Empty;

            m_eventPeriod = 0;
            btnOK.Enabled = false;
        }




        #region Properties

        public int EventPeriod
        {
            get { return m_eventPeriod; }
        }

        public Vixen.Channel BeatChannel
        {
            get { return m_sequence.Channels[BeatChannelNumber]; }
        }

        public int BeatChannelNumber
        {
            get { return comboBoxBeatChannel.SelectedIndex; }
        }

        public bool UpdateEventPeriod
        {
            get { return checkBoxUpdateEventPeriod.Checked; }
        }

        public bool InsertBeats
        {
            get { return checkBoxInsertBeats.Checked; }
        }

        public int EventsPerBeat
        {
            get { return m_eventsPerBeat; }
        }

        #endregion



        #region GUI Events

        private void comboBoxEventsPerBeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_eventsPerBeat = Int32.Parse(comboBoxEventsPerBeat.SelectedItem.ToString());
            CalcEventPeriod();
        }

        private void checkBoxInsertBeats_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxBeatChannel.Enabled = checkBoxInsertBeats.Checked;
        }

        private void checkBoxUpdateEventPeriod_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxInsertBeats.Enabled = checkBoxUpdateEventPeriod.Checked;

            if (checkBoxUpdateEventPeriod.Checked)
            {
                comboBoxBeatChannel.Enabled = checkBoxInsertBeats.Checked;
            }
            else
            {
                comboBoxBeatChannel.Enabled = false;    
            }
        }

        #endregion

        private void MainDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Tap Tempo add-in for Vixen");
            text.AppendLine("Version " + this.GetType().Assembly.GetName().Version.ToString());
            
            text.AppendLine();
            text.AppendLine("Jonathon Reinhart   2009");
            text.AppendLine("http://lights.onthefive.com");
            MessageBox.Show(text.ToString(), "About Tap Tempo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = true;
        }

        


        

    }
}
