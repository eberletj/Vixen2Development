using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Vixen;
using Vixen.Dialogs;

namespace ColorOrgan
{
	public partial class ColorOrganForm : Form
	{
		#region __Data

		/// <summary>
		/// reference to the class that holds data that we need to display and manipulate
		/// </summary>
		private ColorOrgan m_colorOrgan = null;

		/// <summary>
		/// current list of defined color organ bands
		/// </summary>
		Dictionary<int, ColorOrganBand> m_mapOfColorOrganBands = new Dictionary<int, ColorOrganBand>();

		#endregion __Data

		public ColorOrganForm(ref ColorOrgan colorOrgan)
		{
			InitializeComponent();

			// save the reference to the color organ data.
			m_colorOrgan = colorOrgan;

			// set up the list using the latest data from 
			populateColorOrganBandSelectList();

			numericUpDownStartChan.Maximum = m_colorOrgan.numChans;
		} // ColorOrganForm

		/// <summary>
		/// This function updates the Color Organ band list based on information stored in the color organ object
		/// </summary>
		public void populateColorOrganBandSelectList()
		{
			List<string> bandNames = new List<string>();
			m_mapOfColorOrganBands.Clear();

			// build a list of band names
			int index = 0;
			foreach (var band in m_colorOrgan.MapOfColorOrganBands)
			{
				// add the name to the list
				bandNames.Add( band.Value.Name );
				m_mapOfColorOrganBands.Add(index++, band.Value);
			} // end build a list of band names

			// turn off the list box
			listBoxColorBands.Enabled = false;

			// populate the data
			listBoxColorBands.DataSource = null;
			listBoxColorBands.DataSource = bandNames;

			// turn on the list box
			listBoxColorBands.Enabled = true;
			listBoxColorBands.Refresh();

		} // ColorOrganForm

		/// <summary>
		/// Add a new band to the list of bands and open a dialog for it
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonNewColorGroup_Click(object sender, EventArgs e)
		{
			ColorOrganBand band = m_colorOrgan.CreateBand();
			populateColorOrganBandSelectList();

			ColorOrganForm temp = this;
			ColorOrganBandForm cobf = new ColorOrganBandForm(ref band, ref temp);
			cobf.Show();
		}  // buttonNewColorGroup_Click

		/// <summary>
		/// User has pressed edit or double clicked an entry in the table
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonEditColorGroup_Click(object sender, EventArgs e)
		{
			do
			{
				// are there any bands to edit?
				if (0 == m_mapOfColorOrganBands.Count)
				{
					break;
				} // end no bands to edit

				ColorOrganBand band = m_mapOfColorOrganBands[listBoxColorBands.SelectedIndex];
				ColorOrganForm temp = this;
				ColorOrganBandForm cobf = new ColorOrganBandForm(ref band, ref temp);
				cobf.Show();

			} while (false);
		} // buttonEditColorGroup_Click

		/// <summary>
		/// Remove a band from the list of bands
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDeleteColorGroup_Click(object sender, EventArgs e)
		{
			// are there any bands to delete?
			if (0 < m_mapOfColorOrganBands.Count)
			{
				// get the band to be deleted
				ColorOrganBand band = m_mapOfColorOrganBands[listBoxColorBands.SelectedIndex];

				// tell the color organ to delete the band
				m_colorOrgan.DeleteBand(band.ID);

				// update the display list
				populateColorOrganBandSelectList();
			}
		} // buttonDeleteColorGroup_Click

		/// <summary>
		/// User has requested that the channels be updated for all color organ bands
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSetChans_Click(object sender, EventArgs e)
		{
			m_colorOrgan.SetChans();
		} // buttonSetChans_Click

		/// <summary>
		/// User has requested that the output channels should be cleared. Ignores setting in the CO Band
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonClearChannels_Click(object sender, EventArgs e)
		{
			m_colorOrgan.ClearChans();
		} // buttonClearChannels_Click

		/// <summary>
		/// user has requested that we make a copy of the current band
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonCopy_Click(object sender, EventArgs e)
		{
			do
			{
				// are there any bands to copy?
				if (0 == m_mapOfColorOrganBands.Count)
				{
					break;
				} // end no bands to copy

				ColorOrganBand destinationBand = m_colorOrgan.CreateBand(m_mapOfColorOrganBands[listBoxColorBands.SelectedIndex]);

				// copy to body of the data
				populateColorOrganBandSelectList();

				ColorOrganForm temp = this;
				ColorOrganBandForm cobf = new ColorOrganBandForm(ref destinationBand, ref temp);
				cobf.Show();

			} while (false);
		} // buttonCopy_Click

		/// <summary>
		/// This function will prompt the user for a starting channel and then create 
		/// a spectrum analyzer default setup using 31 output channels
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDefaults_Click(object sender, EventArgs e)
		{
			m_colorOrgan.createDefaultColorOrganBandSet(Convert.ToInt32(numericUpDownStartChan.Value), Convert.ToInt32(numericUpDownNumBands.Value));
			populateColorOrganBandSelectList();
		} // buttonDefaults_Click

		private void foo()
		{
		}

	} // class ColorOrganForm
} // ColorOrgan
