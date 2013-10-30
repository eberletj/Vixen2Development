using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Vixen;

namespace ColorOrgan
{
	public class ColorOrganBand
	{
		#region __Data

		/// <summary>
		/// raw frequency bands we support
		/// </summary>
		Dictionary<string, FrequencyBand> m_frequencyBands = new Dictionary<string, FrequencyBand>();

		/// <summary>
		/// List of the available frequency bands
		/// </summary>
		private Dictionary<string, ColorOrganFrequencyBand> m_mapOfFrequencyBands = new Dictionary<string, ColorOrganFrequencyBand>();
		private string m_xmlName_mapOfFrequencyBands = "FrequencyBands";

		/// <summary>
		/// Min level in the frequency bin needed to reach the variable output range.
		/// Values below this level are in the 'full off' range.
		/// </summary>
		private float m_minBinVariableRange = 0.00000001f;
		private string m_xmlName_minBinVariableRange = "minBinVariableRange";

		/// <summary>
		/// max level in the frequency bin needed to stay in the variable output range
		/// Values above this level are in the 'full on' range.
		/// </summary>
		private float m_maxBinVariableRange = 0.00000001f;
		private string m_xmlName_maxBinVariableRange = "maxBinVariableRange";

		/// <summary>
		/// True = look in each frequency bin assigned to the color band, locate the highest value and use that to set the output level
		/// False = Average all of the levels in the assigned frequency bins to determine the value to output.
		/// </summary>
		private bool m_usePeakLevels = true;
		private string m_xmlName_usePeakLevels = "usePeakLevels";

		/// <summary>
		/// Sequence event information
		/// </summary>
		private EventSequence m_sequence = null;

		/// <summary>
		/// Display name for this band
		/// </summary>
		private string m_name = "";
		private string m_xmlName_name = "name";

		/// <summary>
		/// unchangeable ID for this band configuration
		/// </summary>
		private string m_id = "";
		private string m_xmlName_id = "id";

		/// <summary>
		/// reference to the parent object
		/// </summary>
		private ColorOrgan m_colorOrgan = null;

		/// <summary>
		/// List of channels and their current membership state
		/// </summary>
		private Dictionary<string, ColorOrganChannel> m_mapOfChannels = new Dictionary<string, ColorOrganChannel>();
		private string m_xmlName_mapOfChannels = "Channels";

		/// <summary>
		/// Sum of all of the levels in the member energy bands
		/// </summary>
		private double m_energySumAvg = 0.0;
		private double m_energyPeak = Double.MinValue;
		private double m_energyMin = Double.MaxValue;
		private UInt64 m_energyCount = 0;

		private bool m_clearChannelsOnWrite = false;
		private string m_xmlName_clearChannelsOnWrite = "clearChannelsOnWrite";

		#endregion __Data

		public Dictionary<string, ColorOrganFrequencyBand> listOfFrequencyBands { get { return m_mapOfFrequencyBands; } set { m_mapOfFrequencyBands = value; calculatePeak(); } }
		public float minBinVariableRange { get { return m_minBinVariableRange; } set { m_minBinVariableRange = value; } }
		public float maxBinVariableRange { get { return m_maxBinVariableRange; } set { m_maxBinVariableRange = value; } }
		public bool usePeakLevels { get { return m_usePeakLevels; } set { m_usePeakLevels = value; } }
		public EventSequence Sequence { get { return m_sequence; } set { m_sequence = value; } }
		public string Name { get { return m_name; } set { m_name = value; } }
		public Dictionary<string, ColorOrganChannel> ChannelList { get { return m_mapOfChannels; } set { m_mapOfChannels = value; } }
		public string ID { get { return m_id; } }
		public Double Avg { get { return m_energySumAvg / m_energyCount; } }
		public Double Peak { get { return m_energyPeak; } }
		public Double Min { get { return m_energyMin; } }
		public bool clearChannelsOnWrite { get { return m_clearChannelsOnWrite; } set { m_clearChannelsOnWrite = value; } }

		/// <summary>
		/// Create an instance of a color organ band.
		/// </summary>
		/// <param name="xmlData"></param>
		public ColorOrganBand(XmlNode xmlData, 
							  Dictionary<string, FrequencyBand> frequencyBands, 
							  EventSequence newSequence,
							  ColorOrgan colorOrgan)
		{
			// save the sequence data
			Sequence = newSequence;

			m_colorOrgan = colorOrgan;

			m_frequencyBands = frequencyBands;

			// Set the name for this Color Band
			m_id = DateTime.Now.ToString("yyyyMMddHHmmssffffff", System.Globalization.CultureInfo.InvariantCulture);
			Name = "All Frequencies" + m_id;

			// parse the XML file
			m_id = Xml.GetNodeAlways(xmlData, m_xmlName_id, m_id).InnerText;
			Name = Xml.GetNodeAlways(xmlData, m_xmlName_name, Name).InnerText;
			bool.TryParse(Xml.GetNodeAlways(xmlData, m_xmlName_usePeakLevels, m_usePeakLevels.ToString()).InnerText, out m_usePeakLevels);
			m_minBinVariableRange  = float.Parse(Xml.GetNodeAlways(xmlData, m_xmlName_minBinVariableRange,  m_minBinVariableRange.ToString()).InnerText);
			m_maxBinVariableRange  = float.Parse(Xml.GetNodeAlways(xmlData, m_xmlName_maxBinVariableRange,  m_maxBinVariableRange.ToString()).InnerText);
			bool.TryParse(Xml.GetNodeAlways(xmlData, m_xmlName_clearChannelsOnWrite, m_clearChannelsOnWrite.ToString()).InnerText, out m_clearChannelsOnWrite);

			// convert the list of Frequency bands into a list we can use
			buildMapOfFrequencyBands(false);

			// mark the frequency bands that are a member of this color organ band
			XmlNodeList frequencyBandNodes = xmlData.SelectNodes(m_xmlName_mapOfFrequencyBands + "/*");
			foreach (XmlNode xmlFrequencyBandNode in frequencyBandNodes)
			{
				string frequencyBandName = xmlFrequencyBandNode.InnerText;
				m_mapOfFrequencyBands[frequencyBandName].Member = true;
				m_energySumAvg += m_mapOfFrequencyBands[frequencyBandName].Avg;
				m_energyPeak = Math.Max(m_energyPeak, m_mapOfFrequencyBands[frequencyBandName].Peak);
				m_energyMin = Math.Min(m_energyMin, m_mapOfFrequencyBands[frequencyBandName].Min);
				m_energyCount++;
			} // end build member list

			// build a list of the current channels
			foreach (Vixen.Channel channel in Sequence.Channels)
			{
				ColorOrganChannel newChannel = new ColorOrganChannel(channel);
				m_mapOfChannels.Add(newChannel.Id, newChannel);
			} // end each channel in the sequence

			// mark the channels that are a member of this color organ band
			XmlNodeList channelNodes = xmlData.SelectNodes(m_xmlName_mapOfChannels + "/*");
			foreach (XmlNode xmlChannelNode in channelNodes)
			{
				// is this channel still in the list of channels?
				if (true == m_mapOfChannels.ContainsKey(xmlChannelNode.InnerText))
				{
					// mark the channel as active
					m_mapOfChannels[xmlChannelNode.InnerText].Member = true;
				}
			} // end build member list
		} // ColorOrganBand(xml)

		/// <summary>
		/// Create a default color band
		/// </summary>
		/// <param name="frequencyBands"></param>
		/// <param name="newSequence"></param>
		/// <param name="colorOrgan"></param>
		public ColorOrganBand(Dictionary<string, FrequencyBand> frequencyBands, 
							  EventSequence newSequence,
							  ColorOrgan colorOrgan,
							  bool defaultFrequencyState = true)
		{
			m_colorOrgan = colorOrgan;

			// save the sequence info
			Sequence = newSequence;

			m_frequencyBands = frequencyBands;

			// Set the name for this Color Band
			m_id = DateTime.Now.ToString("yyyyMMddHHmmssffffff", System.Globalization.CultureInfo.InvariantCulture);
			Name = "All Frequencies" + m_id;

			// build the list of frequencies associated with this band
			buildMapOfFrequencyBands(defaultFrequencyState);

			// build a list of the current channels
			foreach (Vixen.Channel channel in Sequence.Channels)
			{
				ColorOrganChannel newChannel = new ColorOrganChannel(channel);
				m_mapOfChannels.Add(newChannel.Id, newChannel);
			} // end each channel in the sequence

		} // default Color Organ Band

		/// <summary>
		/// Create an instance of a color organ band.
		/// </summary>
		/// <param name="xmlData"></param>
		public ColorOrganBand(ColorOrganBand template)
		{
			Sequence = template.Sequence;
			Name = template.Name + " - Copy";
			m_id = DateTime.Now.ToString("yyyyMMddHHmmssffffff", System.Globalization.CultureInfo.InvariantCulture);
			m_colorOrgan = template.m_colorOrgan;

			m_minBinVariableRange = template.m_minBinVariableRange;
			m_maxBinVariableRange = template.m_maxBinVariableRange;
			m_usePeakLevels = template.m_usePeakLevels;

			m_energySumAvg = template.m_energySumAvg;
			m_energyPeak = template.m_energyPeak;
			m_energyMin = template.m_energyMin;
			m_energyCount = template.m_energyCount;
			m_clearChannelsOnWrite = template.m_clearChannelsOnWrite;

			m_frequencyBands = template.m_frequencyBands;

			m_mapOfFrequencyBands = new Dictionary<string, ColorOrganFrequencyBand>();
			foreach (var band in template.m_mapOfFrequencyBands)
			{
				m_mapOfFrequencyBands.Add( band.Key, new ColorOrganFrequencyBand(band.Value) );
			} // end copy frequency bands

			m_mapOfChannels = new Dictionary<string, ColorOrganChannel>();
			foreach( var channel in template.m_mapOfChannels )
			{
				m_mapOfChannels.Add( channel.Key, new ColorOrganChannel(channel.Value) );
			} // end copy channels

		} // ColorOrganBand(template)
	
		/// <summary>
		/// Wrap the frequency bands in an object that is linked to the color organ band
		/// </summary>
		/// <param name="frequencyBands"></param>
		private void buildMapOfFrequencyBands(bool defaultState)
		{
			m_energyPeak = Double.MinValue;
			m_energyMin = Double.MaxValue;
			m_energySumAvg = 0.0;
			m_energyCount = 0;

			// convert the list of frequency bands into a map of frequency bands
			foreach (var frequencyBand in m_frequencyBands)
			{
				// create a color organ frequency band
				ColorOrganFrequencyBand coFrequencyBand = new ColorOrganFrequencyBand(frequencyBand.Value, defaultState);

				// add the frequency band to the dictionary
				m_mapOfFrequencyBands.Add(frequencyBand.Value.CenterFrequency, coFrequencyBand);
				if (true == defaultState)
				{
					// ignore empty time slots
					if (0.0 < frequencyBand.Value.Avg)
					{
						m_energySumAvg += frequencyBand.Value.Avg;
						m_energyPeak = Math.Max(m_energyPeak, frequencyBand.Value.Peak);
						m_energyMin = Math.Min(m_energyMin, frequencyBand.Value.Min);
						m_energyCount++;
					} // end process non zero time slot
				} // end if this frequency is part of this band
			} // end convert frequency band list into a dictionary
		} // buildMapOfFrequencyBands

		/// <summary>
		/// Output configuration
		/// </summary>
		/// <param name="xmlData"></param>
		internal void SaveToXml(ref XmlNode xmlData)
		{
			Xml.SetValue(xmlData, m_xmlName_id,					  m_id);
			Xml.SetValue(xmlData, m_xmlName_name,				  Name);
			Xml.SetValue(xmlData, m_xmlName_usePeakLevels,		  m_usePeakLevels.ToString());
			Xml.SetValue(xmlData, m_xmlName_minBinVariableRange,  m_minBinVariableRange.ToString());
			Xml.SetValue(xmlData, m_xmlName_maxBinVariableRange,  m_maxBinVariableRange.ToString());
			Xml.SetValue(xmlData, m_xmlName_clearChannelsOnWrite, m_clearChannelsOnWrite.ToString());

			// output frequency settings
			XmlNode xmlFrequencyData = Xml.GetEmptyNodeAlways(xmlData, m_xmlName_mapOfFrequencyBands);

			foreach (var frequencyBand in m_mapOfFrequencyBands)
			{
				// is this frequency a member of this band?
				if (true == frequencyBand.Value.Member)
				{
					Xml.SetNewValue(xmlFrequencyData, "Frequency", frequencyBand.Value.Name);
				}
			} // end process frequency info

			// output channels that are part of this band
			// start a new section for the channels
			XmlNode xmlChannelData = Xml.GetEmptyNodeAlways(xmlData, m_xmlName_mapOfChannels);
			// save the data for each color organ band
			foreach (var channel in m_mapOfChannels)
			{
				// is the channel part of this band?
				if (true == channel.Value.Member)
				{
					// save the channel ID
					Xml.SetNewValue(xmlChannelData, "Channel", channel.Value.Id);
				} // end channel is a member of this band
			} // end build color organ band list

		} // SaveToXml

		/// <summary>
		/// pass through the member frequencies and calculate the current peak and average values
		/// </summary>
		public void calculatePeak()
		{
			m_energyCount = 0;
			m_energyPeak = Double.MinValue;
			m_energyMin = Double.MaxValue;
			m_energySumAvg = 0.0;

			// process each frequency band we know about
			foreach (var frequencyBand in m_mapOfFrequencyBands)
			{
				// is this band a member of this Color Organ Channel?
				if( (true == frequencyBand.Value.Member) && (0.0 < frequencyBand.Value.Avg) )
				{
					// update the average and peak data
					m_energySumAvg += frequencyBand.Value.Avg;
					m_energyPeak = Math.Max(m_energyPeak, frequencyBand.Value.Peak);
					m_energyMin = Math.Min(m_energyMin, frequencyBand.Value.Min);
					m_energyCount++;
				} // end is a member
			} // end check each band
		} // recalculatePeak

		/// <summary>
		/// Set the output values for each channel in this band
		/// </summary>
		internal void SetChans()
		{
			// do we need to clear the channels?
			if (true == m_clearChannelsOnWrite)
			{
				ClearChans();
			} // end clear channel data

			// process each frequency that is a member of this color organ band
			foreach (var frequencyBand in m_mapOfFrequencyBands)
			{
				frequencyBand.Value.SetChans(Sequence, m_mapOfChannels, m_minBinVariableRange, m_maxBinVariableRange);
			} // end process each frequency
		} // SetChans

		/// <summary>
		/// Clear the output values for each channel in this band
		/// </summary>
		internal void ClearChans()
		{
			// process each frequency that is a member of this color organ band
			foreach (var frequencyBand in m_mapOfFrequencyBands)
			{
				frequencyBand.Value.ClearChans(Sequence, m_mapOfChannels);
			} // end process each frequency
		} // ClearChans

		/// <summary>
		/// Mark the desired frequency active
		/// </summary>
		/// <param name="frequency"></param>
		internal void SelectFrequency(int frequency)
		{
			string centerFrequency = ((frequency < 1000) ? frequency.ToString() : string.Format("{0:F1}k", (float)frequency / 1000f));

			if (true == m_mapOfFrequencyBands.ContainsKey(centerFrequency))
			{
				m_mapOfFrequencyBands[centerFrequency].Member = true;
				calculatePeak();
			}
			else
			{
				throw new NotImplementedException();
			}
		} // SelectFrequency

		/// <summary>
		/// Mark the desired channelNumber active
		/// </summary>
		/// <param name="channelNumber"></param>
		internal void selectChannel(ulong channelID )
		{
			if (true == m_mapOfChannels.ContainsKey(channelID.ToString()))
			{
				m_mapOfChannels[channelID.ToString()].Member = true;
			}
			else
			{
				throw new NotImplementedException();
			}
		} // selectChannel
	} // end class ColorOrganBand
} // ColorOrgan
