using System;
using System.Drawing;

namespace ColorOrgan
{
	public class FrequencyBand
	{
		#region __Data
		private string m_centerFrequency;
		private int m_lowFrequency;
		private int m_highFrequency;
		private int m_fmodLowFrequencyIndex;
		private int m_fmodHighFrequencyIndex;
		private static double FREQUENCY_BANDWIDTH_MULTIPLIER = Math.Pow(2.0, 0.16666666666666666);
		private static int SPECTRUMSIZE = 512;
		private static float BAND_WIDTH = (float)(22050 / FrequencyBand.SPECTRUMSIZE);
		private float m_max = float.MinValue;
		private float m_sum = float.MinValue;
		private float m_min = float.MaxValue;
		private float[] m_samples = null;

		#endregion __Data

		public void reset(UInt64 numSamples) { m_sum = 0f; m_max = 0f; m_samples = new float[numSamples]; }
		public float Peak { get { return m_max; } }
		public float Min { get { return m_min; } }
		public string CenterFrequency { get { return m_centerFrequency; } }
		public int FmodLowFrequency { get { return m_fmodLowFrequencyIndex; } }
		public int FmodHighFrequency { get { return m_fmodHighFrequencyIndex; } }
		public float[] Samples { get { return m_samples; } }
		public float Avg 
		{ 
			get 
			{
				m_sum = 0f;
				foreach (float data in m_samples)
				{
					m_sum += data;
				}
				return m_sum / m_samples.Length;
			} // get
		} // Avg

		/// <summary>
		/// Create a frequency band
		/// </summary>
		/// <param name="centerFrequency"></param>
		public FrequencyBand(int centerFrequency)
		{
			m_centerFrequency = ((centerFrequency < 1000) ? centerFrequency.ToString() : string.Format("{0:F1}k", (float)centerFrequency / 1000f));
			m_lowFrequency = (int)((double)centerFrequency / FrequencyBand.FREQUENCY_BANDWIDTH_MULTIPLIER);
			m_highFrequency = (int)((double)centerFrequency * FrequencyBand.FREQUENCY_BANDWIDTH_MULTIPLIER);
			m_fmodLowFrequencyIndex = (int)Math.Floor((double)((float)m_lowFrequency / FrequencyBand.BAND_WIDTH));
			m_fmodHighFrequencyIndex = Math.Min((int)Math.Ceiling((double)((float)m_highFrequency / FrequencyBand.BAND_WIDTH)), FrequencyBand.SPECTRUMSIZE);
		}

		/// <summary>
		/// Return center frequency as our name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return m_centerFrequency;
		} // ToString

		/// <summary>
		/// Add the value to the appropriate display period
		/// </summary>
		/// <param name="period"></param>
		/// <param name="currentLevel"></param>
		internal void add(uint period, float currentLevel)
		{
			// do we have a place to put this reading?
			if (m_samples.Length > period)
			{
				// add the sample 
				m_samples[period] = Math.Max(currentLevel, m_samples[period]);
				m_max = Math.Max(m_max, currentLevel);
				m_min = Math.Min(m_min, currentLevel);
			} // end period is within scope.
		} // add
	} // FrequencyBand
} // colorOrgan
