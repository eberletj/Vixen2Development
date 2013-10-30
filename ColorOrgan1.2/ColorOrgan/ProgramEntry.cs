using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using Vixen;

namespace ColorOrgan
{
	public class ProgramEntry : IAddIn, ILoadable, IPlugIn
	{
		private XmlNode m_dataNode;

		public LoadableDataLocation DataLocationPreference
		{
			get
			{
				return 0;
			}
		}
		public string Author
		{
			get
			{
				return "Martin Mueller";
			}
		}
		public string Description
		{
			get
			{
				return "Color Organ";
			}
		}
		public string Name
		{
			get
			{
				return "Color Organ";
			}
		}

		/// <summary>
		/// Main entry point
		/// </summary>
		/// <param name="sequence"></param>
		/// <returns></returns>
		public bool Execute(EventSequence sequence)
		{
			if (sequence == null)
			{
				throw new Exception("Color Organ add-in requires a sequence.");
			}
			if (sequence.Audio == null)
			{
				throw new Exception("Color Organ add-in requires the sequence to have audio assigned.");
			}

			// find out which version of vixen we are running on
			Process currentProcess = Process.GetCurrentProcess();
#if VIXEN_VERSION_2_1
			if(( 2 != currentProcess.MainModule.FileVersionInfo.FileMajorPart ) ||
			   ( 1 != currentProcess.MainModule.FileVersionInfo.FileMinorPart )   )
			{
				throw new Exception("Color Organ add-in does not support this version of Vixen.");
			}
#elif VIXEN_VERSION_2_5
			if (( 2 != currentProcess.MainModule.FileVersionInfo.FileMajorPart) ||
			    ( 5 != currentProcess.MainModule.FileVersionInfo.FileMinorPart)   )
			{
				throw new Exception("Color Organ add-in does not support this version of Vixen.");
			}
#else
#error "Unsupported Vixen build version"
#endif

			ColorOrgan colorOrgan = new ColorOrgan(ref m_dataNode, sequence);
			ColorOrganForm colorOrganDialog = new ColorOrganForm(ref colorOrgan);
			colorOrganDialog.ShowDialog();

			// output the color organ info
//			m_dataNode.RemoveAll();
			colorOrgan.SaveToXml(ref m_dataNode);

			colorOrganDialog.Dispose();
			return true;
		}
		public void Loading(XmlNode dataNode)
		{
			m_dataNode = dataNode;
		}
		public void Unloading()
		{
		}
		public override string ToString()
		{
			return Name;
		}
	}
}
