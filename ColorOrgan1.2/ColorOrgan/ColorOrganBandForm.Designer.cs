namespace ColorOrgan
{
	partial class ColorOrganBandForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.checkBoxFrequencyAll = new System.Windows.Forms.CheckBox();
			this.checkBoxChannelsAll = new System.Windows.Forms.CheckBox();
			this.checkedListBoxChannelList = new System.Windows.Forms.CheckedListBox();
			this.labelPeak = new System.Windows.Forms.Label();
			this.labelAvg = new System.Windows.Forms.Label();
			this.labelPeakValue = new System.Windows.Forms.Label();
			this.labelAvgValue = new System.Windows.Forms.Label();
			this.numericUpDownOffLevel = new System.Windows.Forms.NumericUpDown();
			this.labelOffLevel = new System.Windows.Forms.Label();
			this.labelOnLevel = new System.Windows.Forms.Label();
			this.numericUpDownOnLevel = new System.Windows.Forms.NumericUpDown();
			this.dataGridViewFrequencyBands = new System.Windows.Forms.DataGridView();
			this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Average = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Peak = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonSetLevels = new System.Windows.Forms.Button();
			this.checkBoxClearChannelsOnWrite = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnLevel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrequencyBands)).BeginInit();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(32, 4);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(45, 17);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			// 
			// textBoxName
			// 
			this.textBoxName.AllowDrop = true;
			this.textBoxName.Location = new System.Drawing.Point(35, 25);
			this.textBoxName.MaxLength = 64;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(811, 22);
			this.textBoxName.TabIndex = 2;
			this.textBoxName.WordWrap = false;
			this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
			// 
			// checkBoxFrequencyAll
			// 
			this.checkBoxFrequencyAll.AutoSize = true;
			this.checkBoxFrequencyAll.Location = new System.Drawing.Point(35, 901);
			this.checkBoxFrequencyAll.Name = "checkBoxFrequencyAll";
			this.checkBoxFrequencyAll.Size = new System.Drawing.Size(127, 21);
			this.checkBoxFrequencyAll.TabIndex = 6;
			this.checkBoxFrequencyAll.Text = "All Frequencies";
			this.checkBoxFrequencyAll.UseVisualStyleBackColor = true;
			this.checkBoxFrequencyAll.CheckedChanged += new System.EventHandler(this.checkBoxFrequencyAll_CheckedChanged);
			// 
			// checkBoxChannelsAll
			// 
			this.checkBoxChannelsAll.AutoSize = true;
			this.checkBoxChannelsAll.Location = new System.Drawing.Point(439, 901);
			this.checkBoxChannelsAll.Name = "checkBoxChannelsAll";
			this.checkBoxChannelsAll.Size = new System.Drawing.Size(108, 21);
			this.checkBoxChannelsAll.TabIndex = 7;
			this.checkBoxChannelsAll.Text = "All Channels";
			this.checkBoxChannelsAll.UseVisualStyleBackColor = true;
			this.checkBoxChannelsAll.CheckedChanged += new System.EventHandler(this.checkBoxChannelsAll_CheckedChanged);
			// 
			// checkedListBoxChannelList
			// 
			this.checkedListBoxChannelList.CheckOnClick = true;
			this.checkedListBoxChannelList.FormattingEnabled = true;
			this.checkedListBoxChannelList.Location = new System.Drawing.Point(439, 126);
			this.checkedListBoxChannelList.Name = "checkedListBoxChannelList";
			this.checkedListBoxChannelList.Size = new System.Drawing.Size(429, 769);
			this.checkedListBoxChannelList.TabIndex = 8;
			this.checkedListBoxChannelList.SelectedValueChanged += new System.EventHandler(this.checkedListBoxChannelList_SelectedValueChanged);
			// 
			// labelPeak
			// 
			this.labelPeak.AutoSize = true;
			this.labelPeak.Location = new System.Drawing.Point(430, 56);
			this.labelPeak.Name = "labelPeak";
			this.labelPeak.Size = new System.Drawing.Size(40, 17);
			this.labelPeak.TabIndex = 9;
			this.labelPeak.Text = "Peak";
			// 
			// labelAvg
			// 
			this.labelAvg.AutoSize = true;
			this.labelAvg.Location = new System.Drawing.Point(434, 79);
			this.labelAvg.Name = "labelAvg";
			this.labelAvg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.labelAvg.Size = new System.Drawing.Size(36, 17);
			this.labelAvg.TabIndex = 10;
			this.labelAvg.Text = "Avg ";
			// 
			// labelPeakValue
			// 
			this.labelPeakValue.AutoSize = true;
			this.labelPeakValue.Location = new System.Drawing.Point(476, 56);
			this.labelPeakValue.Name = "labelPeakValue";
			this.labelPeakValue.Size = new System.Drawing.Size(84, 17);
			this.labelPeakValue.TabIndex = 11;
			this.labelPeakValue.Text = "0.00000000";
			this.labelPeakValue.Click += new System.EventHandler(this.labelPeakValue_Click);
			// 
			// labelAvgValue
			// 
			this.labelAvgValue.AutoSize = true;
			this.labelAvgValue.Location = new System.Drawing.Point(476, 82);
			this.labelAvgValue.Name = "labelAvgValue";
			this.labelAvgValue.Size = new System.Drawing.Size(84, 17);
			this.labelAvgValue.TabIndex = 12;
			this.labelAvgValue.Text = "0.00000000";
			this.labelAvgValue.Click += new System.EventHandler(this.labelAvgValue_Click);
			// 
			// numericUpDownOffLevel
			// 
			this.numericUpDownOffLevel.AllowDrop = true;
			this.numericUpDownOffLevel.DecimalPlaces = 8;
			this.numericUpDownOffLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			this.numericUpDownOffLevel.Location = new System.Drawing.Point(638, 79);
			this.numericUpDownOffLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.numericUpDownOffLevel.Name = "numericUpDownOffLevel";
			this.numericUpDownOffLevel.Size = new System.Drawing.Size(96, 22);
			this.numericUpDownOffLevel.TabIndex = 13;
			this.numericUpDownOffLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            524288});
			// 
			// labelOffLevel
			// 
			this.labelOffLevel.AutoSize = true;
			this.labelOffLevel.Location = new System.Drawing.Point(643, 56);
			this.labelOffLevel.Name = "labelOffLevel";
			this.labelOffLevel.Size = new System.Drawing.Size(73, 17);
			this.labelOffLevel.TabIndex = 15;
			this.labelOffLevel.Text = "OFF Level";
			// 
			// labelOnLevel
			// 
			this.labelOnLevel.AutoSize = true;
			this.labelOnLevel.Location = new System.Drawing.Point(758, 56);
			this.labelOnLevel.Name = "labelOnLevel";
			this.labelOnLevel.Size = new System.Drawing.Size(67, 17);
			this.labelOnLevel.TabIndex = 18;
			this.labelOnLevel.Text = "ON Level";
			// 
			// numericUpDownOnLevel
			// 
			this.numericUpDownOnLevel.AllowDrop = true;
			this.numericUpDownOnLevel.DecimalPlaces = 8;
			this.numericUpDownOnLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
			this.numericUpDownOnLevel.Location = new System.Drawing.Point(750, 80);
			this.numericUpDownOnLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.numericUpDownOnLevel.Name = "numericUpDownOnLevel";
			this.numericUpDownOnLevel.Size = new System.Drawing.Size(96, 22);
			this.numericUpDownOnLevel.TabIndex = 16;
			this.numericUpDownOnLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            524288});
			// 
			// dataGridViewFrequencyBands
			// 
			this.dataGridViewFrequencyBands.AllowUserToAddRows = false;
			this.dataGridViewFrequencyBands.AllowUserToDeleteRows = false;
			this.dataGridViewFrequencyBands.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFrequencyBands.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewFrequencyBands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFrequencyBands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.Frequency,
            this.Average,
            this.Peak});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewFrequencyBands.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewFrequencyBands.Location = new System.Drawing.Point(35, 109);
			this.dataGridViewFrequencyBands.MultiSelect = false;
			this.dataGridViewFrequencyBands.Name = "dataGridViewFrequencyBands";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFrequencyBands.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewFrequencyBands.RowTemplate.Height = 24;
			this.dataGridViewFrequencyBands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewFrequencyBands.Size = new System.Drawing.Size(387, 786);
			this.dataGridViewFrequencyBands.TabIndex = 19;
			this.dataGridViewFrequencyBands.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFrequencyBands_CellValueChanged);
			this.dataGridViewFrequencyBands.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewFrequencyBands_CurrentCellDirtyStateChanged);
			// 
			// Selected
			// 
			this.Selected.FalseValue = "false";
			this.Selected.Frozen = true;
			this.Selected.HeaderText = " ";
			this.Selected.Name = "Selected";
			this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Selected.ToolTipText = "Add to band";
			this.Selected.TrueValue = "true";
			// 
			// Frequency
			// 
			this.Frequency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Frequency.DividerWidth = 5;
			this.Frequency.Frozen = true;
			this.Frequency.HeaderText = "Frequency";
			this.Frequency.Name = "Frequency";
			this.Frequency.ReadOnly = true;
			this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Frequency.Width = 86;
			// 
			// Average
			// 
			this.Average.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Average.DividerWidth = 2;
			this.Average.Frozen = true;
			this.Average.HeaderText = "Average";
			this.Average.Name = "Average";
			this.Average.ReadOnly = true;
			this.Average.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Average.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Average.Width = 69;
			// 
			// Peak
			// 
			this.Peak.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Peak.DividerWidth = 2;
			this.Peak.Frozen = true;
			this.Peak.HeaderText = "Peak";
			this.Peak.Name = "Peak";
			this.Peak.ReadOnly = true;
			this.Peak.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Peak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Peak.Width = 48;
			// 
			// buttonSetLevels
			// 
			this.buttonSetLevels.Location = new System.Drawing.Point(318, 56);
			this.buttonSetLevels.Name = "buttonSetLevels";
			this.buttonSetLevels.Size = new System.Drawing.Size(104, 43);
			this.buttonSetLevels.TabIndex = 20;
			this.buttonSetLevels.Text = "Set Levels";
			this.buttonSetLevels.UseVisualStyleBackColor = true;
			this.buttonSetLevels.Click += new System.EventHandler(this.buttonSetLevels_Click);
			// 
			// checkBoxClearChannelsOnWrite
			// 
			this.checkBoxClearChannelsOnWrite.AutoSize = true;
			this.checkBoxClearChannelsOnWrite.Location = new System.Drawing.Point(35, 56);
			this.checkBoxClearChannelsOnWrite.Name = "checkBoxClearChannelsOnWrite";
			this.checkBoxClearChannelsOnWrite.Size = new System.Drawing.Size(183, 21);
			this.checkBoxClearChannelsOnWrite.TabIndex = 21;
			this.checkBoxClearChannelsOnWrite.Text = "Clear Channels on Write";
			this.checkBoxClearChannelsOnWrite.UseVisualStyleBackColor = true;
			// 
			// ColorOrganBandForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(880, 735);
			this.Controls.Add(this.checkBoxClearChannelsOnWrite);
			this.Controls.Add(this.buttonSetLevels);
			this.Controls.Add(this.dataGridViewFrequencyBands);
			this.Controls.Add(this.labelOnLevel);
			this.Controls.Add(this.numericUpDownOnLevel);
			this.Controls.Add(this.labelOffLevel);
			this.Controls.Add(this.numericUpDownOffLevel);
			this.Controls.Add(this.labelAvgValue);
			this.Controls.Add(this.labelPeakValue);
			this.Controls.Add(this.labelAvg);
			this.Controls.Add(this.labelPeak);
			this.Controls.Add(this.checkedListBoxChannelList);
			this.Controls.Add(this.checkBoxChannelsAll);
			this.Controls.Add(this.checkBoxFrequencyAll);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Name = "ColorOrganBandForm";
			this.Text = "Edit Color Organ Band ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorOrganBandForm_FormClosing);
			this.Load += new System.EventHandler(this.ColorOrganBandForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnLevel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrequencyBands)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.CheckBox checkBoxFrequencyAll;
		private System.Windows.Forms.CheckBox checkBoxChannelsAll;
		private System.Windows.Forms.CheckedListBox checkedListBoxChannelList;
		private System.Windows.Forms.Label labelPeak;
		private System.Windows.Forms.Label labelAvg;
		private System.Windows.Forms.Label labelPeakValue;
		private System.Windows.Forms.Label labelAvgValue;
		private System.Windows.Forms.NumericUpDown numericUpDownOffLevel;
		private System.Windows.Forms.Label labelOffLevel;
		private System.Windows.Forms.Label labelOnLevel;
		private System.Windows.Forms.NumericUpDown numericUpDownOnLevel;
		private System.Windows.Forms.DataGridView dataGridViewFrequencyBands;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
		private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
		private System.Windows.Forms.DataGridViewTextBoxColumn Average;
		private System.Windows.Forms.DataGridViewTextBoxColumn Peak;
		private System.Windows.Forms.Button buttonSetLevels;
		private System.Windows.Forms.CheckBox checkBoxClearChannelsOnWrite;
	}
}