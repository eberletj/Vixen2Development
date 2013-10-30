using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AudacityBeatTrackAddin
{
	public class MarkCollection
	{
		public MarkCollection()
		{
			Marks = new List<TimeSpan>();
			MarkColor = Color.Black;
			Level = 255;
			ChannelNumber = -1;
		}

		public List<TimeSpan> Marks { get; set; }
		public Color MarkColor { get; set; }
		public int Level { get; set; }
		public int Id { get; set; }
		public int ChannelNumber { get; set; }
		public string Name { get; set; }
		
		public int MarkCount
		{
			get { return Marks.Count; }
		}

		public int IndexOf(TimeSpan time)
		{
			return Marks.IndexOf(time);
		}
	}
}
