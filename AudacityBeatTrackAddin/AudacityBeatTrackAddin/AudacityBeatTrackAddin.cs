using System;
using System.Collections.Generic;
using System.Text;
using Vixen;
using System.Windows.Forms;

namespace AudacityBeatTrackAddin
{
	public class AudacityBeatTrackAddin : IAddIn
	{
		//  Contributions were provided by Jonathan Reinhart from the Tap Tempo dll
		//  Contributions were provided by the Vixen 3 development team
		//  code can be used and distributed freely
		//  Please give the coders their proper acknowledgement.
		public bool Execute(EventSequence sequence)
		{
			if (sequence == null)
			{
				throw new Exception("Audacity Beat Track requires a sequence to be open.");
			}
			BeatTrackImporter dialog = new BeatTrackImporter(sequence);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.UpdateEventPeriod)
				{
					sequence.EventPeriod = dialog.CaluclatedEventPeriod;
					MessageBox.Show(String.Format("{1} has updated the sequence Event Period to {0} ms.", dialog.CaluclatedEventPeriod, this.Name),
							this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				if (dialog.InsertBeats)
				{
					float offset = 0;
					if (dialog.UpdateEventPeriod)
					{
						//convert this to milliseconds
						offset = (float)dialog.CaluclatedEventPeriod / 1000;
					}
					else
					{
						offset = (float)sequence.EventPeriod / 1000;
					}

					foreach (TimeSpan ts in dialog.Marks)
					{

						int location = (int)(ts.TotalSeconds / offset);
						if (location < sequence.TotalEventPeriods)
						{
							sequence.EventValues[dialog.ChannelNumber, location] = 0xFF;
						}

					}
				}
				return true;
			}
			return false;
		}

		public LoadableDataLocation DataLocationPreference
		{
			get { return LoadableDataLocation.Sequence; }
		}

		public void Loading(System.Xml.XmlNode dataNode)
		{

		}

		public void Unloading()
		{

		}

		#region Properties
		public string Author
		{
			get { return "Tony Eberle"; }
		}

		public string Description
		{
			get { return "Adds Audacity Beat Tracks to Vixen"; }
		}

		public string Name
		{
			get { return "Audacity Beat Track"; }
		}
		#endregion
	}
}
