using System;
using System.Collections.Generic;
using System.Text;
using Vixen;

namespace ColorOrgan
{
	public class ColorOrganChannel
	{
		#region __Data

		/// <summary>
		/// Is this channel a member of the current CO band
		/// </summary>
		private bool m_member = false;

		/// <summary>
		/// Reference to the Vixen channel data
		/// </summary>
		private Vixen.Channel m_channel = null;

		#endregion __Data

		public string Id 
		{ 
			get 
			{
#if VIXEN_VERSION_2_5
				return m_channel.ID.ToString();
#else
				return m_channel.GetHashCode().ToString();
#endif
			} // get
		} // ID
		public object Name { get { return m_channel.Name; } }
		public bool Member { get { return m_member; } set { m_member = value; } }

		public ColorOrganChannel(Vixen.Channel channel)
		{
			m_channel = channel;
		} // ColorOrganChannel

		public ColorOrganChannel(ColorOrganChannel template)
		{
			m_channel = template.m_channel;
			m_member = template.m_member;
		} // ColorOrganChannel

		/// <summary>
		/// Update the channels value in the vixen sequence
		/// </summary>
		/// <param name="Sequence"></param>
		/// <param name="currentEventPeriod"></param>
		/// <param name="periodValue"></param>
		internal void SetChan(EventSequence Sequence, uint currentEventPeriod, byte periodValue)
		{
			// is this channel a member of the color organ band?
			if (true == Member)
			{
				byte oldValue = Sequence.EventValues[m_channel.OutputChannel, currentEventPeriod];

				// Write the value
				Sequence.EventValues[m_channel.OutputChannel, currentEventPeriod] = Math.Max(oldValue, periodValue);
			}
		} // SetChan

		/// <summary>
		/// Update the channels value in the vixen sequence
		/// </summary>
		/// <param name="Sequence"></param>
		/// <param name="currentEventPeriod"></param>
		internal void ClearChan(EventSequence Sequence, uint currentEventPeriod)
		{
			// is this channel a member of the color organ band?
			if (true == Member)
			{
				// Write the value
				Sequence.EventValues[m_channel.OutputChannel, currentEventPeriod] = Sequence.MinimumLevel;
			}
		} // SetChan
	} // ColorOrganChannel
} // ColorOrgan
