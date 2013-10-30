namespace AudacityBeatTrackAddin
{
	partial class BeatTrackImporter
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioAudacityBeats = new System.Windows.Forms.RadioButton();
			this.buttonImportAudacity = new System.Windows.Forms.Button();
			this.radioBeats = new System.Windows.Forms.RadioButton();
			this.radioBars = new System.Windows.Forms.RadioButton();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupBoxTapTempo = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSequenceEventPeriod = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonCalculateBPMandEventPeriod = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbBPM = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbCaluclatedEventPeriod = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBoxEventsPerBeat = new System.Windows.Forms.ComboBox();
			this.groupBoxMarks = new System.Windows.Forms.GroupBox();
			this.listViewMarks = new System.Windows.Forms.ListView();
			this.Times = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBoxChannels = new System.Windows.Forms.GroupBox();
			this.listViewChannels = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBoxActions = new System.Windows.Forms.GroupBox();
			this.checkBoxInsertBeats = new System.Windows.Forms.CheckBox();
			this.checkBoxUpdateEventPeriod = new System.Windows.Forms.CheckBox();
			this.buttonReset = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBoxTapTempo.SuspendLayout();
			this.groupBoxMarks.SuspendLayout();
			this.groupBoxChannels.SuspendLayout();
			this.groupBoxActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioAudacityBeats);
			this.groupBox1.Controls.Add(this.buttonImportAudacity);
			this.groupBox1.Controls.Add(this.radioBeats);
			this.groupBox1.Controls.Add(this.radioBars);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 154);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Audacity Beat Type";
			// 
			// radioAudacityBeats
			// 
			this.radioAudacityBeats.AutoSize = true;
			this.radioAudacityBeats.Location = new System.Drawing.Point(6, 65);
			this.radioAudacityBeats.Name = "radioAudacityBeats";
			this.radioAudacityBeats.Size = new System.Drawing.Size(96, 17);
			this.radioAudacityBeats.TabIndex = 12;
			this.radioAudacityBeats.Text = "Audacity Beats";
			this.radioAudacityBeats.UseVisualStyleBackColor = true;
			// 
			// buttonImportAudacity
			// 
			this.buttonImportAudacity.Location = new System.Drawing.Point(36, 105);
			this.buttonImportAudacity.Name = "buttonImportAudacity";
			this.buttonImportAudacity.Size = new System.Drawing.Size(226, 27);
			this.buttonImportAudacity.TabIndex = 11;
			this.buttonImportAudacity.Text = "Import Audacity Beat Marks";
			this.buttonImportAudacity.UseVisualStyleBackColor = true;
			this.buttonImportAudacity.Click += new System.EventHandler(this.buttonImportAudacity_Click);
			// 
			// radioBeats
			// 
			this.radioBeats.AutoSize = true;
			this.radioBeats.Location = new System.Drawing.Point(6, 42);
			this.radioBeats.Name = "radioBeats";
			this.radioBeats.Size = new System.Drawing.Size(150, 17);
			this.radioBeats.TabIndex = 3;
			this.radioBeats.Text = "Vamp Beat Tracker: Beats";
			this.radioBeats.UseVisualStyleBackColor = true;
			// 
			// radioBars
			// 
			this.radioBars.AutoSize = true;
			this.radioBars.Checked = true;
			this.radioBars.Location = new System.Drawing.Point(6, 19);
			this.radioBars.Name = "radioBars";
			this.radioBars.Size = new System.Drawing.Size(144, 17);
			this.radioBars.TabIndex = 2;
			this.radioBars.TabStop = true;
			this.radioBars.Text = "Vamp Beat Tracker: Bars";
			this.radioBars.UseVisualStyleBackColor = true;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(553, 418);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 24;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Enabled = false;
			this.buttonOK.Location = new System.Drawing.Point(634, 418);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 23;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// groupBoxTapTempo
			// 
			this.groupBoxTapTempo.Controls.Add(this.label2);
			this.groupBoxTapTempo.Controls.Add(this.tbSequenceEventPeriod);
			this.groupBoxTapTempo.Controls.Add(this.label3);
			this.groupBoxTapTempo.Controls.Add(this.buttonCalculateBPMandEventPeriod);
			this.groupBoxTapTempo.Controls.Add(this.label1);
			this.groupBoxTapTempo.Controls.Add(this.label8);
			this.groupBoxTapTempo.Controls.Add(this.tbBPM);
			this.groupBoxTapTempo.Controls.Add(this.label7);
			this.groupBoxTapTempo.Controls.Add(this.tbCaluclatedEventPeriod);
			this.groupBoxTapTempo.Controls.Add(this.label6);
			this.groupBoxTapTempo.Controls.Add(this.label5);
			this.groupBoxTapTempo.Controls.Add(this.comboBoxEventsPerBeat);
			this.groupBoxTapTempo.Location = new System.Drawing.Point(12, 172);
			this.groupBoxTapTempo.Name = "groupBoxTapTempo";
			this.groupBoxTapTempo.Size = new System.Drawing.Size(312, 157);
			this.groupBoxTapTempo.TabIndex = 26;
			this.groupBoxTapTempo.TabStop = false;
			this.groupBoxTapTempo.Text = "Tempo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(252, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "ms";
			// 
			// tbSequenceEventPeriod
			// 
			this.tbSequenceEventPeriod.Location = new System.Drawing.Point(146, 99);
			this.tbSequenceEventPeriod.Name = "tbSequenceEventPeriod";
			this.tbSequenceEventPeriod.ReadOnly = true;
			this.tbSequenceEventPeriod.Size = new System.Drawing.Size(100, 20);
			this.tbSequenceEventPeriod.TabIndex = 20;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Sequence Event Length:";
			// 
			// buttonCalculateBPMandEventPeriod
			// 
			this.buttonCalculateBPMandEventPeriod.Location = new System.Drawing.Point(36, 128);
			this.buttonCalculateBPMandEventPeriod.Name = "buttonCalculateBPMandEventPeriod";
			this.buttonCalculateBPMandEventPeriod.Size = new System.Drawing.Size(226, 23);
			this.buttonCalculateBPMandEventPeriod.TabIndex = 18;
			this.buttonCalculateBPMandEventPeriod.Text = "Calculate BPM and Event Period";
			this.buttonCalculateBPMandEventPeriod.UseVisualStyleBackColor = true;
			this.buttonCalculateBPMandEventPeriod.Click += new System.EventHandler(this.buttonCalculateBPMandEventPeriod_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tempo:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(252, 76);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(20, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "ms";
			// 
			// tbBPM
			// 
			this.tbBPM.Location = new System.Drawing.Point(146, 20);
			this.tbBPM.Name = "tbBPM";
			this.tbBPM.ReadOnly = true;
			this.tbBPM.Size = new System.Drawing.Size(100, 20);
			this.tbBPM.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(252, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "BPM";
			// 
			// tbCaluclatedEventPeriod
			// 
			this.tbCaluclatedEventPeriod.Location = new System.Drawing.Point(146, 73);
			this.tbCaluclatedEventPeriod.Name = "tbCaluclatedEventPeriod";
			this.tbCaluclatedEventPeriod.ReadOnly = true;
			this.tbCaluclatedEventPeriod.Size = new System.Drawing.Size(100, 20);
			this.tbCaluclatedEventPeriod.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 76);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(127, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Calculated Event Length:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(64, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Events / Beat:";
			// 
			// comboBoxEventsPerBeat
			// 
			this.comboBoxEventsPerBeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEventsPerBeat.FormattingEnabled = true;
			this.comboBoxEventsPerBeat.Items.AddRange(new object[] {
            "4",
            "8",
            "12"});
			this.comboBoxEventsPerBeat.Location = new System.Drawing.Point(146, 46);
			this.comboBoxEventsPerBeat.Name = "comboBoxEventsPerBeat";
			this.comboBoxEventsPerBeat.Size = new System.Drawing.Size(100, 21);
			this.comboBoxEventsPerBeat.TabIndex = 9;
			this.comboBoxEventsPerBeat.SelectedIndexChanged += new System.EventHandler(this.comboBoxEventsPerBeat_SelectedIndexChanged);
			// 
			// groupBoxMarks
			// 
			this.groupBoxMarks.Controls.Add(this.listViewMarks);
			this.groupBoxMarks.Location = new System.Drawing.Point(330, 12);
			this.groupBoxMarks.Name = "groupBoxMarks";
			this.groupBoxMarks.Size = new System.Drawing.Size(129, 400);
			this.groupBoxMarks.TabIndex = 27;
			this.groupBoxMarks.TabStop = false;
			this.groupBoxMarks.Text = "Marks";
			// 
			// listViewMarks
			// 
			this.listViewMarks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Times});
			this.listViewMarks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listViewMarks.HideSelection = false;
			this.listViewMarks.Location = new System.Drawing.Point(6, 19);
			this.listViewMarks.Name = "listViewMarks";
			this.listViewMarks.Size = new System.Drawing.Size(116, 375);
			this.listViewMarks.TabIndex = 8;
			this.listViewMarks.UseCompatibleStateImageBehavior = false;
			this.listViewMarks.View = System.Windows.Forms.View.Details;
			// 
			// Times
			// 
			this.Times.Width = 90;
			// 
			// groupBoxChannels
			// 
			this.groupBoxChannels.Controls.Add(this.listViewChannels);
			this.groupBoxChannels.Location = new System.Drawing.Point(465, 12);
			this.groupBoxChannels.Name = "groupBoxChannels";
			this.groupBoxChannels.Size = new System.Drawing.Size(244, 400);
			this.groupBoxChannels.TabIndex = 28;
			this.groupBoxChannels.TabStop = false;
			this.groupBoxChannels.Text = "Channels";
			// 
			// listViewChannels
			// 
			this.listViewChannels.CheckBoxes = true;
			this.listViewChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listViewChannels.Enabled = false;
			this.listViewChannels.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.listViewChannels.HideSelection = false;
			this.listViewChannels.Location = new System.Drawing.Point(6, 19);
			this.listViewChannels.Name = "listViewChannels";
			this.listViewChannels.Size = new System.Drawing.Size(232, 375);
			this.listViewChannels.TabIndex = 8;
			this.listViewChannels.UseCompatibleStateImageBehavior = false;
			this.listViewChannels.View = System.Windows.Forms.View.Details;
			this.listViewChannels.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewChannels_ItemCheck);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 256;
			// 
			// groupBoxActions
			// 
			this.groupBoxActions.Controls.Add(this.checkBoxInsertBeats);
			this.groupBoxActions.Controls.Add(this.checkBoxUpdateEventPeriod);
			this.groupBoxActions.Location = new System.Drawing.Point(12, 335);
			this.groupBoxActions.Name = "groupBoxActions";
			this.groupBoxActions.Size = new System.Drawing.Size(312, 77);
			this.groupBoxActions.TabIndex = 29;
			this.groupBoxActions.TabStop = false;
			this.groupBoxActions.Text = "Sequence Actions";
			// 
			// checkBoxInsertBeats
			// 
			this.checkBoxInsertBeats.AutoSize = true;
			this.checkBoxInsertBeats.Enabled = false;
			this.checkBoxInsertBeats.Location = new System.Drawing.Point(10, 42);
			this.checkBoxInsertBeats.Name = "checkBoxInsertBeats";
			this.checkBoxInsertBeats.Size = new System.Drawing.Size(148, 17);
			this.checkBoxInsertBeats.TabIndex = 1;
			this.checkBoxInsertBeats.Text = "Insert Beats on Channel:  ";
			this.checkBoxInsertBeats.UseVisualStyleBackColor = true;
			this.checkBoxInsertBeats.CheckedChanged += new System.EventHandler(this.checkBoxInsertBeats_CheckedChanged);
			// 
			// checkBoxUpdateEventPeriod
			// 
			this.checkBoxUpdateEventPeriod.AutoSize = true;
			this.checkBoxUpdateEventPeriod.Enabled = false;
			this.checkBoxUpdateEventPeriod.Location = new System.Drawing.Point(10, 19);
			this.checkBoxUpdateEventPeriod.Name = "checkBoxUpdateEventPeriod";
			this.checkBoxUpdateEventPeriod.Size = new System.Drawing.Size(140, 17);
			this.checkBoxUpdateEventPeriod.TabIndex = 0;
			this.checkBoxUpdateEventPeriod.Text = "Update Event Period to ";
			this.checkBoxUpdateEventPeriod.UseVisualStyleBackColor = true;
			this.checkBoxUpdateEventPeriod.CheckedChanged += new System.EventHandler(this.checkBoxUpdateEventPeriod_CheckedChanged);
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(12, 418);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 23);
			this.buttonReset.TabIndex = 30;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// BeatTrackImporter
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(722, 453);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.groupBoxActions);
			this.Controls.Add(this.groupBoxChannels);
			this.Controls.Add(this.groupBoxMarks);
			this.Controls.Add(this.groupBoxTapTempo);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox1);
			this.Name = "BeatTrackImporter";
			this.Text = "BeatTrack Importer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBoxTapTempo.ResumeLayout(false);
			this.groupBoxTapTempo.PerformLayout();
			this.groupBoxMarks.ResumeLayout(false);
			this.groupBoxChannels.ResumeLayout(false);
			this.groupBoxActions.ResumeLayout(false);
			this.groupBoxActions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioBeats;
		private System.Windows.Forms.RadioButton radioBars;
		private System.Windows.Forms.Button buttonImportAudacity;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.GroupBox groupBoxTapTempo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbBPM;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbCaluclatedEventPeriod;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBoxEventsPerBeat;
		private System.Windows.Forms.GroupBox groupBoxMarks;
		private System.Windows.Forms.ListView listViewMarks;
		private System.Windows.Forms.ColumnHeader Times;
		private System.Windows.Forms.GroupBox groupBoxChannels;
		private System.Windows.Forms.ListView listViewChannels;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button buttonCalculateBPMandEventPeriod;
		private System.Windows.Forms.GroupBox groupBoxActions;
		private System.Windows.Forms.CheckBox checkBoxInsertBeats;
		private System.Windows.Forms.CheckBox checkBoxUpdateEventPeriod;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.RadioButton radioAudacityBeats;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSequenceEventPeriod;
		private System.Windows.Forms.Label label3;
	}
}