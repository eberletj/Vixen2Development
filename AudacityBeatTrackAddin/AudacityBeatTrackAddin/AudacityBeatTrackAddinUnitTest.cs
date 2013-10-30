using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing;

namespace AudacityBeatTrackAddin
{
	[TestFixture]
	public class AudacityBeatTrackAddinUnitTest
	{
		[Test]
		public void TestBeatTrackImport()
		{
			var colors = new List<Color>
			{
				Color.Yellow,Color.Gold, Color.Goldenrod, Color.SaddleBrown,Color.CadetBlue,Color.BlueViolet 
			};

			string line;
			StringBuilder data = new StringBuilder();
			using (var sr = new StreamReader(File.Open(@"C:\Users\tony.eberle\Google Drive\Christmas Software\Vixen 2.5.0.9\Data\Beat Tracks\Winter-Wonderland-edit-beat-track.txt", FileMode.Open)))
			//using (var sr = new StreamReader(File.Open(@"C:\Users\Tony\Google Drive\Christmas Software\xlights show 2013\Jingle Bells Bing Crosby Beat Track.txt", FileMode.Open)))
			{
				while ((line = sr.ReadLine()) != null)
				{
					data.AppendLine(line);
				}
			}
			string beats = data.ToString();
			const string pattern = @"(\d*\.\d*)\s(\d*\.\d*)\s(\d)";
			MatchCollection matches = Regex.Matches(beats, pattern);
			int numBeats = Convert.ToInt32(matches.Cast<Match>().Max(x => x.Groups[3].Value));
			var marks = new List<MarkCollection>(numBeats);
			for (int i = 0; i < numBeats; i++)
			{
				MarkCollection markscoll = new MarkCollection();
				markscoll.MarkColor = colors[i];
				markscoll.Id = i + 1;
				marks.Add(markscoll);
			}

			foreach (Match match in matches)
			{
				TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(match.Groups[1].Value));
				int beatnumber = Convert.ToInt32(match.Groups[3].Value);
				marks[beatnumber - 1].Marks.Add(time);
			}

			float value = (float)23 / 1000;

			CalculateStuff(marks);
			figuretime(marks);

		}

		[Test]
		public void TestBarTrackImport()
		{
			string line;
			StringBuilder data = new StringBuilder();
			using (var sr = new StreamReader(File.Open(@"C:\Users\tony.eberle\Google Drive\Christmas Software\Vixen 2.5.0.9\Data\Beat Tracks\Winter-Wonderland-edit-beat-track.txt", FileMode.Open)))
			//using (var sr = new StreamReader(File.Open(@"C:\Users\Tony\Google Drive\Christmas Software\xlights show 2013\Jingle Bells Bing Crosby Bar Track.txt", FileMode.Open)))
			{
				while ((line = sr.ReadLine()) != null)
				{
					data.AppendLine(line);
				}
			}
			string beats = data.ToString();
			// Remove the \r so we're just left with a \n (allows importing of Sean's Audacity beat marks
			beats = beats.Replace("\r", "");
			string[] lines = beats.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
			if (lines.Count() > 0)
			{

				MarkCollection markscoll = new MarkCollection() { MarkColor = Color.Yellow, Name = "Audacity Marks" };
				foreach (string str in lines)
				{
					string mark;
					if (str.IndexOf("\t") > 0)
					{
						mark = str.Split('\t')[0].Trim();
					}
					else
					{
						mark = str.Trim().Split(' ')[0].Trim();
					}

					TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(mark));
					markscoll.Marks.Add(time);
				}
			}
		}


		private void figuretime(List<MarkCollection> marks)
		{
			foreach (MarkCollection m in marks)
			{
				for (int i = 0; i < m.Marks.Count; i++)
				{

				}
			}
		}


		private void CalculateStuff(List<MarkCollection> marks)
		{
			int eventperiod = (int)Math.Round(((marks[0].Marks[1].TotalMilliseconds - marks[0].Marks[0].TotalMilliseconds) / 8) / 10, 0);

			double beatsperminute = 0;
			for (int i = 0; i < marks.Count; i++)
			{
				beatsperminute += ((marks[i].Marks[1].TotalSeconds - marks[i].Marks[0].TotalSeconds) / 1000) * 60000;
			}

			beatsperminute = beatsperminute / marks.Count;
		}

	}
}
