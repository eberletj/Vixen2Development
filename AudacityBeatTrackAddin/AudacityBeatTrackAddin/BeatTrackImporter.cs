using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vixen;
using System.IO;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;

namespace AudacityBeatTrackAddin
{
	public partial class BeatTrackImporter : Form
	{
		private EventSequence _sequence;
		private int _eventsPerBeat;
		private int _calculatedEventPeriod;
		private int _providedEventPeriod;
		private double _beatsperminute;
		private List<MarkCollection> _beatMarks;
		private MarkCollection _barMarks;
		private int _selectedChannelCount;
		private int _channelNumber;

		static string _lastFolder = string.Empty;

		public BeatTrackImporter(EventSequence sequence)
		{
			InitializeComponent();
			_sequence = sequence;
						
			comboBoxEventsPerBeat.SelectedIndex = 0;
			comboBoxEventsPerBeat.Focus();

			_providedEventPeriod = _sequence.EventPeriod;
			tbSequenceEventPeriod.Text = _providedEventPeriod.ToString();

			PopulateChannelListView();
		}

		private void comboBoxEventsPerBeat_SelectedIndexChanged(object sender, EventArgs e)
		{
			_eventsPerBeat = Int32.Parse(comboBoxEventsPerBeat.SelectedItem.ToString());

		}

		private void checkBoxInsertBeats_CheckedChanged(object sender, EventArgs e)
		{
			listViewChannels.Enabled = checkBoxInsertBeats.Checked;
		}

		private void checkBoxUpdateEventPeriod_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxInsertBeats.Enabled = checkBoxUpdateEventPeriod.Checked;

			if (checkBoxUpdateEventPeriod.Checked)
			{
				listViewChannels.Enabled = checkBoxInsertBeats.Checked;
			}
			else
			{
				listViewChannels.Enabled = false;
			}
		}

		private void listViewChannels_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			ListView lv = (ListView)sender;
			if (e.NewValue == CheckState.Checked)
			{
				checkBoxInsertBeats.Text = string.Format("Insert Beats on Channel:  {0}", lv.Items[e.Index].Text);
				_channelNumber = e.Index;
			}
			//else
			//{
			//    //remove the item we just unchecked
			//    //string text = "is assigned to:  " + lv.Items[e.Index].Text;
			//    //int index = selectedChannelRichTextBox.Find(text);
			//}
		}

		private void buttonImportAudacity_Click(object sender, EventArgs e)
		{
			_selectedChannelCount = 0;
			if (radioAudacityBeats.Checked || radioBars.Checked)
			{
				LoadBarLabels();
			}
			else
			{
				LoadBeatLabels();
			}
		}

		private void buttonCalculateBPMandEventPeriod_Click(object sender, EventArgs e)
		{
			buttonOK.Enabled = true;
			checkBoxInsertBeats.Enabled = true;
			checkBoxUpdateEventPeriod.Enabled = true;

			CalculateEventPeriod();
			CalculateBeatsPerMinute();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			tbBPM.Text = String.Empty;
			tbCaluclatedEventPeriod.Text = String.Empty;

			_beatsperminute = 0;
			_calculatedEventPeriod = 0;
			_selectedChannelCount = 0;

			checkBoxUpdateEventPeriod.Checked = false;
			checkBoxInsertBeats.Checked = false;

			buttonOK.Enabled = false;
			checkBoxInsertBeats.Enabled = false;
			checkBoxUpdateEventPeriod.Enabled = false;

			ClearOutCheckedItemsInListview();

		}

		private void ClearOutCheckedItemsInListview()
		{
			foreach (ListViewItem item in listViewChannels.CheckedItems)
			{
					item.Checked = false;
			}
		}

		private void CalculateEventPeriod()
		{
			//(int)Math.Round(((_beatMarks[0].Marks[1].TotalMilliseconds - _beatMarks[0].Marks[0].TotalMilliseconds) / _eventsPerBeat) / 10, 0);

			if (radioBars.Checked || radioBeats.Checked)
				_calculatedEventPeriod = (int)Math.Round((((_beatMarks[0].Marks[_beatMarks[0].Marks.Count - 1].TotalSeconds - _beatMarks[0].Marks[0].TotalSeconds) / 1000) * 60000 / _beatMarks[0].Marks.Count) / EventsPerBeat);
			else
				_calculatedEventPeriod = (int)Math.Round(((_beatMarks[0].Marks[_beatMarks[0].Marks.Count - 1].TotalSeconds - _beatMarks[0].Marks[0].TotalSeconds) / 1000) * 60000 / _beatMarks[0].Marks.Count);


			if (_calculatedEventPeriod < 25)
			{
				MessageBox.Show(String.Format("Event Period {0} is less than Vixen minumum of 25, so we will set to 25",_calculatedEventPeriod), "Vixen Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
				_calculatedEventPeriod = 25;
			}

			tbCaluclatedEventPeriod.Text = _calculatedEventPeriod.ToString();
			
			if (_calculatedEventPeriod > 0)
			{
				buttonOK.Enabled = true;
			}
			else
			{
				buttonOK.Enabled = false;
			}
		}

		private void CalculateBeatsPerMinute()
		{
			if (radioAudacityBeats.Checked)
			{
				tbBPM.Text = "No BPM information";
			}
			else
			{
				_beatsperminute = 0;

				_beatsperminute = ((_beatMarks[0].Marks[1].TotalSeconds - _beatMarks[0].Marks[0].TotalSeconds) / 1000) * 60000;

				tbBPM.Text = _beatsperminute.ToString();
			}
		}

		private void LoadBarLabels()
		{
			openFileDialog.DefaultExt = ".txt";
			openFileDialog.Filter = @"Audacity Bar Labels|*.txt|All Files|*.*";
			openFileDialog.FilterIndex = 0;
			openFileDialog.InitialDirectory = _lastFolder;
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				_lastFolder = Path.GetDirectoryName(openFileDialog.FileName);
				try
				{
					String everything;
					using (StreamReader sr = new StreamReader(openFileDialog.FileName))
					{
						everything = sr.ReadToEnd();
					}
					// Remove the \r so we're just left with a \n (allows importing of Sean's Audacity beat marks
					everything = everything.Replace("\r", "");
					string[] lines = everything.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
					if (lines.Count() > 0)
					{
						_beatMarks = new List<MarkCollection>(1);
						_barMarks = new MarkCollection() { MarkColor = Color.Yellow, Name = "Audacity Marks" };


						foreach (string line in lines)
						{
							string mark;
							if (line.IndexOf("\t") > 0)
							{
								mark = line.Split('\t')[0].Trim();
							}
							else
							{
								mark = line.Trim().Split(' ')[0].Trim();
							}

							TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(mark));
							_barMarks.Marks.Add(time);
						}
						_beatMarks.Add(_barMarks);
						PopulateMarkListFromMarkCollection();
					}
				}
				catch (Exception ex)
				{
					string msg = "There was an error importing the Audacity bar marks: " + ex.Message;
					MessageBox.Show(msg, @"Audacity Import Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}
			}
		}

		private void LoadBeatLabels()
		{
			var colors = new List<Color>
			{
				Color.Yellow,Color.Gold, Color.Goldenrod, Color.SaddleBrown,Color.CadetBlue,Color.BlueViolet 
			};

			openFileDialog.DefaultExt = ".txt";
			openFileDialog.Filter = @"Audacity Beat Labels|*.txt|All Files|*.*";
			openFileDialog.FilterIndex = 0;
			openFileDialog.InitialDirectory = _lastFolder;
			openFileDialog.FileName = "";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				_lastFolder = Path.GetDirectoryName(openFileDialog.FileName);
				try
				{
					string line;
					StringBuilder data = new StringBuilder();
					using (var sr = new StreamReader(openFileDialog.FileName))
					{
						while ((line = sr.ReadLine()) != null)
						{
							data.Append(line);
						}
					}
					string beats = data.ToString();
					const string pattern = @"(\d*\.\d*)\s(\d*\.\d*)\s(\d)";
					MatchCollection matches = Regex.Matches(beats, pattern);
					int numBeats = Convert.ToInt32(matches.Cast<Match>().Max(x => x.Groups[3].Value));
					_beatMarks = new List<MarkCollection>(numBeats);
					for (int i = 0; i < numBeats; i++)
					{
						MarkCollection markscoll = new MarkCollection() { MarkColor = colors[i],  Name = string.Format("Audacity Beat {0} Marks", i + 1)  };
						_beatMarks.Add(markscoll);
					}

					foreach (Match match in matches)
					{
						TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(match.Groups[1].Value));
						int beatnumber = Convert.ToInt32(match.Groups[3].Value);
						_beatMarks[beatnumber - 1].Marks.Add(time);
					}

						PopulateMarkListFromMarkCollection();
						//UpdateRange(_beatMarks.Count);
				}
				catch (Exception ex)
				{
					string msg = "There was an error importing the Audacity beat marks: " + ex.Message;
					MessageBox.Show(msg, @"Audacity Import Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				}
			}
		}

		private void PopulateChannelListView()
		{
			int i = 1;
			foreach (Channel channel in _sequence.Channels)
			{
				listViewChannels.Items.Add(String.Format("{0,-3}: {1}", i++, channel));
			}
		}

		private void PopulateMarkListFromMarkCollection()
		{
			listViewMarks.BeginUpdate();
			listViewMarks.Items.Clear();

			if(_beatMarks != null)
			{
				foreach (MarkCollection collection in _beatMarks)
				{
					collection.Marks.Sort();
					foreach (TimeSpan time in collection.Marks)
					{
						ListViewItem item = new ListViewItem(String.Format("{0:m:ss.fff}", new DateTime(time.Ticks))) { Tag = time };
						listViewMarks.Items.Add(item);
					}
				}
			}

			listViewMarks.EndUpdate();
		}

		//private void UpdateRange(int numOfCollctions)
		//{
		//    if (numOfCollctions > 1)
		//    {
		//        checkBoxInsertBeats.Text = string.Format("Insert Beats on {0} Channels", numOfCollctions);
		//    }
		//    else
		//    {
		//        checkBoxInsertBeats.Text = string.Format("Insert Beats on {0} Channel", numOfCollctions);
		//    }
		//}

		public bool UpdateEventPeriod
		{
			get { return checkBoxUpdateEventPeriod.Checked; }
		}

		public int CaluclatedEventPeriod
		{
			get { return _calculatedEventPeriod; }
		}

		public bool InsertBeats
		{
			get { return checkBoxInsertBeats.Checked; }
		}

		public int EventsPerBeat
		{
			get { return _eventsPerBeat; }
		}

		public int ChannelNumber
		{
			get { return _channelNumber; }
		}

		public List<TimeSpan> Marks
		{
			get
			{
				List<TimeSpan> ts = new List<TimeSpan>();
				if (_beatMarks != null)
				{
					foreach (MarkCollection collection in _beatMarks)
					{
						collection.Marks.Sort();
						foreach (TimeSpan time in collection.Marks)
						{
							ts.Add(time);
						}
					}
					ts.Sort();
				}
				return ts;
			}
		}
	}
}
