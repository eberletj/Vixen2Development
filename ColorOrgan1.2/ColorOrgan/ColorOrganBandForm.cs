using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ColorOrgan
{
	public partial class ColorOrganBandForm: Form
	{
		#region __Data

		ColorOrganBand m_colorOrganBand = null;
		ColorOrganForm m_parentForm = null;
		Dictionary<int, ColorOrganChannel> m_colorOrganChannelList = new Dictionary<int, ColorOrganChannel>();
		Dictionary<int, ColorOrganFrequencyBand> m_colorOrganFrequencyList = new Dictionary<int, ColorOrganFrequencyBand>();

		#endregion __Data

		public ColorOrganBandForm( ref ColorOrganBand colorOrganBand, ref ColorOrganForm parentForm )
		{
			InitializeComponent();

			// save the reference to this band
			m_colorOrganBand = colorOrganBand;

			m_parentForm = parentForm;

			// set up the table grid
			dataGridViewFrequencyBands.CellValueChanged -= dataGridViewFrequencyBands_CellValueChanged;
			dataGridViewFrequencyBands.AllowUserToOrderColumns = false;
			dataGridViewFrequencyBands.AllowUserToAddRows = false;
			dataGridViewFrequencyBands.AllowUserToDeleteRows = false;
			dataGridViewFrequencyBands.Enabled = true;
			dataGridViewFrequencyBands.CellValueChanged += dataGridViewFrequencyBands_CellValueChanged;

		} // ColorOrganBandForm

		/// <summary>
		/// Convert the Color Organ band config into display information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ColorOrganBandForm_Load(object sender, EventArgs e)
		{
			int index = 0;
			m_parentForm.Enabled = false;

			// display the name of the color organ group
			textBoxName.Enabled = false;
			textBoxName.Text = m_colorOrganBand.Name;
			textBoxName.Enabled = true;
			textBoxName.Refresh();

			// put up the list of currently configured channels
			index = 0;
			bool allChannelsAreMembers = true;
			foreach (var channel in m_colorOrganBand.ChannelList)
			{
				// add the channel to the display list
				checkedListBoxChannelList.Items.Add(channel.Value.Name, channel.Value.Member);
				m_colorOrganChannelList.Add(index++, channel.Value);
				if (false == channel.Value.Member)
				{
					allChannelsAreMembers = false;
				}
			} // process all of the available channels

			// set the all channels checkbox
			checkBoxChannelsAll.CheckedChanged -= checkBoxChannelsAll_CheckedChanged;
			checkBoxChannelsAll.Checked = allChannelsAreMembers;
			checkBoxChannelsAll.CheckedChanged += checkBoxChannelsAll_CheckedChanged;

			labelPeakValue.Text = (0 < m_colorOrganBand.Peak) ? m_colorOrganBand.Peak.ToString("0.00000000") : "0.00000000";
			labelAvgValue.Text  = (0 < m_colorOrganBand.Avg)  ? m_colorOrganBand.Avg.ToString("0.00000000") : "0.00000000";
			numericUpDownOffLevel.Value = Convert.ToDecimal(m_colorOrganBand.minBinVariableRange);
			numericUpDownOnLevel.Value = Convert.ToDecimal(m_colorOrganBand.maxBinVariableRange);

			// build the list of frequencies in use by this band.
			dataGridViewFrequencyBands.CellValueChanged -= dataGridViewFrequencyBands_CellValueChanged;
			dataGridViewFrequencyBands.Rows.Clear();
			index = 0;
			foreach (var cofb in m_colorOrganBand.listOfFrequencyBands)
			{
				m_colorOrganFrequencyList.Add(index++, cofb.Value);
				dataGridViewFrequencyBands.Rows.Add( ((true == cofb.Value.Member) ? true : false), 
													 cofb.Value.Name,
													 cofb.Value.Avg.ToString("0.00000000"),
													 cofb.Value.Peak.ToString("0.00000000"));
			}
			dataGridViewFrequencyBands.CellValueChanged += dataGridViewFrequencyBands_CellValueChanged;

			checkBoxClearChannelsOnWrite.Checked = m_colorOrganBand.clearChannelsOnWrite;

			// set the all frequency checked box
			updateAllFrequencyChecked();
		} // ColorOrganBandForm_Load

		/// <summary>
		/// Send any configuration changes back to the color organ band object.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ColorOrganBandForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_parentForm.Enabled = true;
			m_parentForm.populateColorOrganBandSelectList();

			// Convert the list of frequency bands back to something the band object can use
			for (int index = 0; index < m_colorOrganFrequencyList.Count; index++)
			{
				m_colorOrganFrequencyList[index].Member = Convert.ToBoolean(dataGridViewFrequencyBands.Rows[index].Cells["Selected"].Value);
			} // end read each entry and update the config

			// Convert the list of channels back to something the band object can use
			for (int index = 0; index < checkedListBoxChannelList.Items.Count; index++)
			{
				m_colorOrganChannelList[index].Member = checkedListBoxChannelList.GetItemChecked(index);
			} // end read each entry and update the config

			// save the peak level setting
			m_colorOrganBand.minBinVariableRange = Convert.ToSingle(numericUpDownOffLevel.Value);
			m_colorOrganBand.maxBinVariableRange = Convert.ToSingle(numericUpDownOnLevel.Value);

			// save the overwrite state
			m_colorOrganBand.clearChannelsOnWrite = checkBoxClearChannelsOnWrite.Checked;

		} // ColorOrganBandForm_FormClosing

		/// <summary>
		/// update the name of the color organ group
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxName_TextChanged(object sender, EventArgs e)
		{
			// did the name really change?
			m_colorOrganBand.Name = textBoxName.Text;
		} // textBoxName_TextChanged

		/// <summary>
		/// Set all of the checkbox values to the same value as the 'all' value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBoxFrequencyAll_CheckedChanged(object sender, EventArgs e)
		{
			dataGridViewFrequencyBands.CellValueChanged -= dataGridViewFrequencyBands_CellValueChanged;
			int index = 0;
			foreach( var cofb in m_colorOrganFrequencyList )
			{
				dataGridViewFrequencyBands.Rows[index++].Cells[0].Value = checkBoxFrequencyAll.Checked;
				cofb.Value.Member = checkBoxFrequencyAll.Checked;
			} // process each frequency
			dataGridViewFrequencyBands.CellValueChanged += dataGridViewFrequencyBands_CellValueChanged;

			// recalculate the energy levels
			m_colorOrganBand.calculatePeak();

			// update the form
			labelPeakValue.Text = (0 < m_colorOrganBand.Peak) ? m_colorOrganBand.Peak.ToString("0.00000000") : "0.00000000";
			labelAvgValue.Text  = (0 < m_colorOrganBand.Avg)  ? m_colorOrganBand.Avg.ToString("0.00000000") : "0.00000000";
		} // checkBoxFrequencyAll_CheckedChanged

		/// <summary>
		/// Set all channel checkbox values to the same value as the master checkbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBoxChannelsAll_CheckedChanged(object sender, EventArgs e)
		{
			for (int index = 0; index < checkedListBoxChannelList.Items.Count; index++)
			{
				checkedListBoxChannelList.SetItemChecked(index, checkBoxChannelsAll.Checked);
			} // process each frequency
		} // checkBoxChannelsAll_CheckedChanged

		/// <summary>
		/// User has clicked the measured Peak value. Auto fill the min/max values
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelPeakValue_Click(object sender, EventArgs e)
		{
			float off = Convert.ToSingle(labelPeakValue.Text) * 0.001f;
			float on = Convert.ToSingle(labelPeakValue.Text) * 0.9f;
			numericUpDownOffLevel.Value = Convert.ToDecimal(off);
			numericUpDownOnLevel.Value = Convert.ToDecimal(on);
		} // labelPeakValue_Click

		/// <summary>
		/// User has clicked the measured Avg value. Auto fill the min/max values
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void labelAvgValue_Click(object sender, EventArgs e)
		{
			float off = Convert.ToSingle(labelAvgValue.Text) * 0.001f;
			float on = Convert.ToSingle(labelAvgValue.Text) * 1.0f;
			numericUpDownOffLevel.Value = Convert.ToDecimal(off);
			numericUpDownOnLevel.Value = Convert.ToDecimal(on);
		} // labelAvgValue_Click

		/// <summary>
		/// Set the levels to something between avg and peak
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSetLevels_Click(object sender, EventArgs e)
		{
			float off = Convert.ToSingle(labelAvgValue.Text) * 0.1f;
			float peak = Convert.ToSingle(labelPeakValue.Text);
			float avg = Convert.ToSingle(labelAvgValue.Text);
			float on = ((peak - avg) / 2) + avg;
			numericUpDownOffLevel.Value = Convert.ToDecimal(off);
			numericUpDownOnLevel.Value = Convert.ToDecimal(on);
		} // buttonSetLevels_Click

		/// <summary>
		/// Handle a check box changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridViewFrequencyBands_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			// Any frequency bands to process?
			if (0 < dataGridViewFrequencyBands.Rows.Count)
			{
				m_colorOrganFrequencyList[e.RowIndex].Member = Convert.ToBoolean(dataGridViewFrequencyBands.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

				// update the ALL frequencies checked box
				updateAllFrequencyChecked();

				// recalculate the energy levels
				m_colorOrganBand.calculatePeak();

				// update the form
				labelPeakValue.Text = (0 < m_colorOrganBand.Peak) ? m_colorOrganBand.Peak.ToString("0.00000000") : "0.00000000";
				labelAvgValue.Text  = (0 < m_colorOrganBand.Avg)  ? m_colorOrganBand.Avg.ToString("0.00000000") : "0.00000000";
			}
		} // dataGridViewFrequencyBands_CellValueChanged

		/// <summary>
		/// Handle a check box changed event sooner than leaving the cell
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridViewFrequencyBands_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dataGridViewFrequencyBands.IsCurrentCellDirty)
			{
				dataGridViewFrequencyBands.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		} // dataGridViewFrequencyBands_CurrentCellDirtyStateChanged

		/// <summary>
		/// Update the all frequency checkbox based on the current membership values
		/// </summary>
		private void updateAllFrequencyChecked()
		{
			bool allMembers = true;
			foreach (var cofb in m_colorOrganBand.listOfFrequencyBands)
			{
				// is this frequency a member
				if(false == cofb.Value.Member)
				{
					allMembers = false;
				} // end found a non member
			} // end scan the members

			// is the new value different than the expected value?
			if( allMembers != checkBoxFrequencyAll.Checked)
			{
				checkBoxFrequencyAll.CheckedChanged -= checkBoxFrequencyAll_CheckedChanged;
				checkBoxFrequencyAll.Checked = allMembers;
				checkBoxFrequencyAll.CheckedChanged += checkBoxFrequencyAll_CheckedChanged;
			} // value needed to be adjusted
		} // updateAllFrequencyChecked

		/// <summary>
		/// update the stored channel information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkedListBoxChannelList_SelectedValueChanged(object sender, EventArgs e)
		{
			bool allChannelsAreMembers = true;
			// Convert the list of channels back to something the band object can use
			for (int index = 0; index < checkedListBoxChannelList.Items.Count; index++)
			{
				// is this channel checked
				if( false == checkedListBoxChannelList.GetItemChecked(index))
				{
					allChannelsAreMembers = false;
				} // channel is NOT checked
			} // end read each entry and update the config

			// set the all channels checkbox
			checkBoxChannelsAll.CheckedChanged -= checkBoxChannelsAll_CheckedChanged;
			checkBoxChannelsAll.Checked = allChannelsAreMembers;
			checkBoxChannelsAll.CheckedChanged += checkBoxChannelsAll_CheckedChanged;
		} // checkedListBoxChannelList_SelectedValueChanged

		private void foo()
		{
		}

	} // ColorOrganBandForm
} // ColorOrgan
