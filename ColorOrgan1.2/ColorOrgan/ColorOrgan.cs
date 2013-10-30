using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using Vixen;
using System.Windows.Forms;


namespace ColorOrgan
{
	public class ColorOrgan
	{
		#region __Data

		private XmlNode m_xmlData = null;

		/// <summary>
		/// List of Color Organ bands that make up this color organ
		/// </summary>
		private Dictionary<string, ColorOrganBand> m_mapOfColorOrganBands = new Dictionary<string, ColorOrganBand>();
		private string m_xmlName_listOfColorOrganBands = "ColorOrganBands";
		private string m_xmlName_ColorOrganBand = "ColorOrganBand";

		/// <summary>
		/// Event sequence information received from Vixen
		/// </summary>
		private EventSequence m_sequence = null;

		/// <summary>
		/// Sound track management fields
		/// </summary>
		private FMOD._System m_FMOD_system = null;
		private FMOD.Sound m_FMOD_sound = null;
		private FMOD.Channel m_FMOD_channel = null;
		private float[] m_FMOD_spectrum = new float[512];

		/// <summary>
		/// Frequencies of interest
		/// </summary>
		int[] m_frequencyArray = new int[]
			{
				20, 25, 31, 40, 50, 63, 80, 100, 125, 160, 200, 250, 315,
				400, 500, 630, 800, 1000, 1250, 1600, 2000, 2500, 3150,
				4000, 5000, 6300, 8000, 10000, 12500, 16000, 20000
			};

		/// <summary>
		/// List of color organ bands
		/// </summary>
		private Dictionary<string, FrequencyBand> m_mapOfFrequencyBands = new Dictionary<string, FrequencyBand>();

		#endregion __Data

		public decimal numChans { get { return m_sequence.ChannelCount; } }
		public EventSequence Sequence { get { return m_sequence; } }
		public int[] FrequencyArray { get { return m_frequencyArray; } }
		public Dictionary<string, FrequencyBand> MapOfFrequencyBands { get { return m_mapOfFrequencyBands; } }

		/// <summary>
		/// Form to manage the Color Organ functionality
		/// </summary>
		/// <param name="xmlData"></param>
		/// <param name="sequence"></param>
		public ColorOrgan(ref XmlNode xmlData, EventSequence sequence)
		{
			// save the reference to the xml data
			m_xmlData = xmlData;

			// save the list of bands we have available to us
			foreach (int frequency in m_frequencyArray)
			{
				FrequencyBand newBand = new FrequencyBand(frequency);
				m_mapOfFrequencyBands.Add(newBand.CenterFrequency, newBand);
			} // end build base frequency objects

			// record the sequence
			m_sequence = sequence;

			// go find out what the peaks and valleys are for this sound track
			analyzeSoundTrack();

			// process xml data and set up any pre defined groups
			// mark the frequency bands that are a member of this color organ band
			XmlNodeList colorOrganBandNodes = xmlData.SelectNodes(m_xmlName_listOfColorOrganBands + "/*");
			foreach (XmlNode xmlColorOrganBandNode in colorOrganBandNodes)
			{
				ColorOrganBand newBand = new ColorOrganBand(xmlColorOrganBandNode, m_mapOfFrequencyBands, m_sequence, this);
				m_mapOfColorOrganBands.Add(newBand.ID, newBand); 
			} // end build color organ band list

			// did we get any groups?
			if (0 == m_mapOfColorOrganBands.Count)
			{
				createDefaultColorOrganBandSet(-1, 1);
			} // end create default color band
		} // ColorOrganForm

		internal Dictionary<string, ColorOrganBand> MapOfColorOrganBands { get { return m_mapOfColorOrganBands; } set { m_mapOfColorOrganBands = value; } }

		/// <summary>
		/// Run through each of the frequency bands and record the data 
		/// for the current pont in time in the audio track
		/// </summary>
		private void GetSpectrumData(uint period)
		{
//			int num = 0;
//			int num2 = 0;
			int sampleRate = 0;
			int numOutputChannels = 0;
			int maxInputChannels = 0;
			int numBits = 0;
			FMOD.SOUND_FORMAT sOUND_FORMAT = FMOD.SOUND_FORMAT.NONE;
			FMOD.DSP_RESAMPLER dSP_RESAMPLER = FMOD.DSP_RESAMPLER.LINEAR;

			m_FMOD_system.getSoftwareFormat(ref sampleRate /* num2 */, 
										    ref sOUND_FORMAT, 
											ref numOutputChannels /* num */,
											ref maxInputChannels /* num2 */, 
											ref dSP_RESAMPLER,
											ref numBits /* num2 */);

			// for each of the output channels
			for (int currentChannel = 0; currentChannel < numOutputChannels; currentChannel++)
			{
				// get the spectrum data for this channel
				m_FMOD_system.getSpectrum(m_FMOD_spectrum, 512, currentChannel, FMOD.DSP_FFT_WINDOW.TRIANGLE);

				// update each frequency band for this period	
				foreach (var currentFrequencyBand in m_mapOfFrequencyBands)
				{
					// this is a magic number that I have not yet tracked down.
					float currentLevel = 0f;
					for (int j = currentFrequencyBand.Value.FmodLowFrequency; j < currentFrequencyBand.Value.FmodHighFrequency; j++)
					{
						// find the highest value available to this band
						currentLevel = Math.Max(currentLevel, m_FMOD_spectrum[j]);
					}
					currentFrequencyBand.Value.add(period, currentLevel);
				} // end process each frequency band
			} // end process each channel
		} // GetSpectrumData

		private void analyzeSoundTrack()
		{
			uint endPosition = 0u;
			uint currentPosition = 0u;

			// reset all of the counters and such in the frequency band
			foreach (var current in m_mapOfFrequencyBands)
			{
				// clear and allocate new data arrays
				current.Value.reset((uint)(m_sequence.TotalEventPeriods + 1));
			} // end reset the data arrays

//			m_FMOD_sound.release();
//			m_FMOD_system.close();
//			m_FMOD_system.release();
			FMOD_ERRCHECK(FMOD.Factory.System_Create(ref m_FMOD_system));
			m_FMOD_system.setOutput(FMOD.OUTPUTTYPE.NOSOUND_NRT);

			FMOD_ERRCHECK(m_FMOD_system.init(32, FMOD.INITFLAG.STREAM_FROM_UPDATE, IntPtr.Zero));
			m_FMOD_system.createStream(Path.Combine(Paths.AudioPath, m_sequence.Audio.FileName), (FMOD.MODE)72u, ref m_FMOD_sound);

			// How much music is there (in ms)
			m_FMOD_sound.getLength(ref endPosition, FMOD.TIMEUNIT.MS);

			// set up a progress bar
			TranscribeDialog transcribeDialog = new TranscribeDialog((int)endPosition);
			transcribeDialog.Show();

			// set up the playback
			FMOD_ERRCHECK(m_FMOD_system.playSound(FMOD.CHANNELINDEX.FREE, m_FMOD_sound, false, ref m_FMOD_channel));

			// while there is more sound to process
			while (currentPosition < endPosition)
			{
				// GET the playback index
				m_FMOD_channel.getPosition(ref currentPosition, FMOD.TIMEUNIT.MS);
				uint currentPeriod = ((uint)currentPosition / (uint)m_sequence.EventPeriod);

				// tell the user where we are in the process
				transcribeDialog.Progress = (int)currentPosition;
				transcribeDialog.Refresh();

				// calculate the frequency bands for the current position
				GetSpectrumData(currentPeriod);

				// which period are we in?
				if (currentPeriod >= m_sequence.TotalEventPeriods)
				{
					// time to stop
					break;
				} // last period check
				
				m_FMOD_system.update();
			} // end while

			// turn it all off
			m_FMOD_channel.stop();
			transcribeDialog.Hide();
			transcribeDialog.Dispose();
			m_FMOD_sound.release();
			m_FMOD_sound = null;
			m_FMOD_system.close();
			m_FMOD_system.release();
			m_FMOD_system = null;
		} // analyzeSoundTrack

		/// <summary>
		/// Parse the response from the FMOD call and display an error message as needed
		/// </summary>
		/// <param name="result"></param>
		private void FMOD_ERRCHECK(FMOD.RESULT result)
		{
			if (result != FMOD.RESULT.OK)
			{
				MessageBox.Show(string.Concat(new object[]
				{
					"FMOD error! ",
					result,
					" - ",
					FMOD.Error.String(result)
				}));
			}
		}
		/// <summary>
		/// Output the config
		/// </summary>
		/// <param name="xmlData"></param>
		internal void SaveToXml(ref XmlNode xmlData)
		{
			Xml.SetValue(xmlData, "NumberOfBands", m_mapOfColorOrganBands.Count.ToString());

			XmlDocument doc = xmlData.FirstChild.OwnerDocument;

			// start a new section for the color organ bands
			XmlNode xmlColorOrganBands = Xml.GetEmptyNodeAlways(xmlData, m_xmlName_listOfColorOrganBands);

			// save the data for each color organ band
			foreach (var colorOrganBand in m_mapOfColorOrganBands)
			{
				XmlNode newXmlNode = doc.CreateNode("element", m_xmlName_ColorOrganBand, "");
				// tell the band to output its settings
				colorOrganBand.Value.SaveToXml(ref newXmlNode);

				xmlColorOrganBands.AppendChild(newXmlNode);
			} // end build color organ band list
		} // SaveToXml

		/// <summary>
		/// Output the channel values for all of the color organ bands
		/// </summary>
		internal void SetChans()
		{
			foreach (var band in m_mapOfColorOrganBands)
			{
				band.Value.SetChans();
			} // process each band
		} // SetChans

		/// <summary>
		/// Create a new band with the default data.
		/// </summary>
		internal ColorOrganBand CreateBand()
		{
			ColorOrganBand temp = new ColorOrganBand(m_mapOfFrequencyBands, m_sequence, this);

			// create at least one Color Band that encompases all of the frequency bands
			m_mapOfColorOrganBands.Add(temp.ID, temp);

			return temp;
		} // CreateBand

		/// <summary>
		/// Create a new band with the default data.
		/// </summary>
		internal ColorOrganBand CreateBand(ColorOrganBand template)
		{
			ColorOrganBand temp = new ColorOrganBand(template);

			// create at least one Color Band that encompases all of the frequency bands
			m_mapOfColorOrganBands.Add(temp.ID, temp);

			return temp;
		} // CreateBand

		/// <summary>
		/// Delete a color organ band
		/// </summary>
		/// <param name="ID"></param>
		internal void DeleteBand(string ID)
		{
			// is this band in our list?
			if (true == m_mapOfColorOrganBands.ContainsKey(ID))
			{
				// remove the band
				m_mapOfColorOrganBands.Remove(ID);
			} // end delete band
		} // DeleteBand

		/// <summary>
		/// Clear all of the output channel values
		/// </summary>
		internal void ClearChans()
		{
			// save the data for each color organ band
			foreach (var colorOrganBand in m_mapOfColorOrganBands)
			{
				// tell the band to clear its outputs
				colorOrganBand.Value.ClearChans();
			} // end build color organ band list
		} // ClearChans

		/// <summary>
		/// Create a default set of color organ bands
		/// </summary>
		/// <param name="firstChanNumber">-1 means no channels assigned</param>
		/// <param name="numChans"></param>
		internal void createDefaultColorOrganBandSet(Int32 firstChanNumber, Int32 numChans)
		{
			ColorOrganBand band = null;
			Double frequencyStepPerBand = 31.0 / numChans;
			Double currentFrequencyStep = 0.0;
			Double currentFrequencyBand = 0.0;

			do
			{
				if (((firstChanNumber + numChans) > m_sequence.ChannelCount) && (-1 != firstChanNumber))
				{
					MessageBox.Show("Too many channels requested. The number of outputs is greater than the number of channels available above the starting channel", "ERROR");
					break;
				}

				if (numChans > (m_frequencyArray.Length))
				{
					MessageBox.Show("Too many channels requested. The number of outputs is greater than the number of available frequencies", "ERROR");
					break;
				}

				// clear the existing channels
				m_mapOfColorOrganBands.Clear();

				// create the needed channels
				for (int chanCount = 0; chanCount < numChans; chanCount++)
				{
					band = new ColorOrganBand(m_mapOfFrequencyBands, m_sequence, this, false);

					// This is a bit of a hack: prevent duplicates due to going too fast
					while (true == m_mapOfColorOrganBands.ContainsKey(band.ID))
					{
						band = new ColorOrganBand(m_mapOfFrequencyBands, m_sequence, this, false);
					}

					// set the band name
					band.Name = m_frequencyArray[Convert.ToInt32(currentFrequencyBand)].ToString();

					// adjust the top of this band
					currentFrequencyBand += frequencyStepPerBand;

					// add frequencies
					while ((currentFrequencyBand > currentFrequencyStep) && (31 > currentFrequencyStep))
					{
						// set the frequency to an active state
						band.SelectFrequency(m_frequencyArray[Convert.ToInt32(currentFrequencyStep)]);

						// advance to the next step
						currentFrequencyStep += 1.0;
					} // end add frequencies

					// set the trigger limits
					band.minBinVariableRange = Convert.ToSingle(band.Avg * 0.1);
					band.maxBinVariableRange = Convert.ToSingle((((band.Peak - band.Avg) / 4) * 3) + band.Avg);

					// make sure the channels get cleared before each write operation
					band.clearChannelsOnWrite = true;

					// do we need to activate an output channel for this band?
					if (-1 != firstChanNumber)
					{
						int chanNum = (firstChanNumber + chanCount) - 1;
#if VIXEN_VERSION_2_5
							ulong chanId = m_sequence.Channels[chanNum].ID;
#else
						ulong chanId = Convert.ToUInt64(m_sequence.Channels[chanNum].GetHashCode());
#endif
						band.selectChannel(chanId);
						m_sequence.Channels[chanNum].Name = "CO: " + band.Name;

						// set up some inter channel color contrast
						m_sequence.Channels[chanNum].Color = (0 == (chanCount & 0x01)) ? System.Drawing.Color.White : System.Drawing.Color.LightBlue;
					} // end need to turn on a channel

					// add the new band to the list of bands
					m_mapOfColorOrganBands.Add(band.ID, band);
				} // end generate bands
			} while (false);
		} // createDefaultSet

	} // ColorOrgan
} // ColorOrgan
