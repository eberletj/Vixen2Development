using System;
using System.Collections.Generic;
using System.Text;

namespace ColorOrgan
{
	/// <summary>
	/// Container class to hold a reference mapping between a list of frequencies and a color organ band
	/// </summary>
	public class ColorOrganFrequencyBand
	{
		private FrequencyBand m_frequencyBand = null;
		private bool m_member = false;

		public bool Member { get {return m_member;} set {m_member = value;} }
		public string Name { get { return m_frequencyBand.CenterFrequency; } }
		public double Avg { get { return m_frequencyBand.Avg; } }
		public double Peak { get { return m_frequencyBand.Peak; } }
		public double Min { get { return m_frequencyBand.Min; } }

		/// <summary>
		/// init the Color Organ wrapper around a frequency band
		/// </summary>
		/// <param name="frequencyBand"></param>
		/// <param name="defaultState"></param>
		public ColorOrganFrequencyBand(FrequencyBand frequencyBand, bool defaultState)
		{
			// save the frequency band
			m_frequencyBand = frequencyBand;

			// set the group membership flag
			m_member = defaultState;
		} // colorOrganFrequencyBand

		/// <summary>
		/// Copy constructuor: init the Color Organ wrapper around a frequency band
		/// </summary>
		/// <param name="template"></param>
		public ColorOrganFrequencyBand(ColorOrganFrequencyBand template)
		{
			// save the frequency band
			m_frequencyBand = template.m_frequencyBand;

			// set the group membership flag
			m_member = template.m_member;
		} // colorOrganFrequencyBand

		/// <summary>
		/// Set the channel outputs for each of the output periods
		/// </summary>
		/// <param name="Sequence"></param>
		/// <param name="m_mapOfChannels"></param>
		/// <param name="m_minBinVariableRange">min level needed to turn on a channel</param>
		/// <param name="m_maxBinVariableRange">Level at which channel will be on 100%</param>
		internal void SetChans(Vixen.EventSequence Sequence, Dictionary<string, ColorOrganChannel> mapOfChannels, float minBinVariableRange, float maxBinVariableRange)
		{
			do
			{
				// is this frequency a member of this color organ band
				if (false == Member)
				{
					// nope
					break;
				} // end this frequency is not a member of this color organ band

				// get the data samples
				float[] samples = m_frequencyBand.Samples;
				byte periodValue = 0;
				float binRange = maxBinVariableRange - minBinVariableRange;
				float outRange = Sequence.MaximumLevel - Sequence.MinimumLevel;

				for (uint currentEventPeriod = 0; currentEventPeriod < Sequence.TotalEventPeriods; currentEventPeriod++)
				{
					// is this level up to the minimum value needed to turn on?
					if (minBinVariableRange > samples[currentEventPeriod])
					{
						// nope. Channel is off
						periodValue = 0;
					}
					// is the level above the full on point?
					else if (maxBinVariableRange < samples[currentEventPeriod])
					{
						// yup. Just turn it on
						periodValue = Sequence.MaximumLevel;
					}
					else
					{
						// the output is somewhere between full on and off
						float delta = (samples[currentEventPeriod] - minBinVariableRange);
						float multiplier = (delta / binRange);
						float value = Sequence.MinimumLevel + (multiplier * outRange);
						periodValue = Convert.ToByte(value);
					}

					// give it to each channel bound to this color organ band
					foreach (var channel in mapOfChannels)
					{
						channel.Value.SetChan(Sequence, currentEventPeriod, periodValue);
					} // process each channel
				} // end for each period
			} while (false);
		} // SetChans

		/// <summary>
		/// Clear the channel data
		/// </summary>
		/// <param name="Sequence"></param>
		/// <param name="m_mapOfChannels"></param>
		internal void ClearChans(Vixen.EventSequence Sequence, Dictionary<string, ColorOrganChannel> m_mapOfChannels)
		{
			do
			{
				// is this frequency a member of this color organ band
				if (false == Member)
				{
					// nope
					break;
				} // end this frequency is not a member of this color organ band
				for (uint currentEventPeriod = 0; currentEventPeriod < Sequence.TotalEventPeriods; currentEventPeriod++)
				{
					// give it to each channel bound to this color organ band
					foreach (var channel in m_mapOfChannels)
					{
						channel.Value.ClearChan(Sequence, currentEventPeriod);
					} // process each channel
				} // end for each period		
			} while (false);
		} // ClearChans
	} // colorOrganFrequencyBand
} // ColorOrgan
