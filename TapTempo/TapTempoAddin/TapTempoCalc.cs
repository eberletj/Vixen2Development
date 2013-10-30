using System;

namespace TapTempo
{
    public class TapTempoCalc
    {
        private bool m_waitForFirst = true;
        private int m_beats;
        private DateTime m_firstTap;
        private DateTime m_lastTap;

        public void Reset()
        {
            m_waitForFirst = true;
            m_beats = 0;
            m_firstTap = DateTime.MinValue;
            m_lastTap = DateTime.MinValue;
        }

        public void Tap()
        {
            m_lastTap = DateTime.Now;

            if (m_waitForFirst)
            {
                m_waitForFirst = false;
                m_firstTap = m_lastTap;
            }
            else
            {
                m_beats++;
            }
        }

        public int Beats
        {
            get { return m_beats; }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                if (m_firstTap != null && m_lastTap != null)
                    return (m_lastTap - m_firstTap);
                else
                    return new TimeSpan(0);
            }
        }

        public double BPM
        {
            get
            {
                if (ElapsedTime.TotalMinutes != 0.0)
                    return (m_beats / ElapsedTime.TotalMinutes);
                else
                    return 0.0;
            }
        }

        public double MillisecondsPerBeat
        {
            get
            {
                if (m_beats != 0)
                    return (ElapsedTime.TotalMilliseconds / m_beats);
                else
                    return 0.0;
            }
        }

        public bool FirstBeat
        {
            get { return (m_beats == 0); }
        }



        /*** Original Javascript code: ***/
        /*
            var count = 0;
            var msecsFirst = 0;
            var msecsPrevious = 0;
             
            function ResetCount()
            {
                count = 0;
                document.tap_form.avg_bpm.value = "";
                document.tap_form.num_taps.value = "";
                  
                document.tap_form.msec_per_beat.value = "";
                document.tap_form.msec_per_event_8.value = "";
                document.tap_form.msec_per_event_12.value = "";
                  
                document.tap_form.reset_button.blur();
            }
             
            function TapForBPM(e)
            {
                timeSeconds = new Date;
                msecs = timeSeconds.getTime();
                 
                if (count == 0)
                {
                    document.tap_form.avg_bpm.value = "First Beat";
                    document.tap_form.num_taps.value = "First Beat";
                    msecsFirst = msecs;
                    count = 1;
                }
                else
                {
                    // total elapsed times
                    ttot = (msecs - msecsFirst);
                    bpmAvg = 60000 * count / ttot;
                    bpm = (Math.round(bpmAvg * 100)) / 100;
                    document.tap_form.avg_bpm.value = bpm;
                        
                    // msec / beat
                    msec_per_beat = ttot / count;
                    document.tap_form.msec_per_beat.value = msec_per_beat;
                        
                    // events
                    document.tap_form.msec_per_event_8.value = Math.round(msec_per_beat / 8);
                    document.tap_form.msec_per_event_12.value = Math.round(msec_per_beat / 12);
                        
                    // beats
                    count++;
                    document.tap_form.num_taps.value = count;
                }
                msecsPrevious = msecs;
                return true;
            }
          
            document.onkeypress = TapForBPM;
             
        */
    }
}
