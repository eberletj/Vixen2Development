namespace TapTempo
{
    partial class MainDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbBPM = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.tbMsPerBeat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEventsPerBeat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEventPeriod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBegin = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPlayStop = new System.Windows.Forms.Button();
            this.groupBoxTapTempo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.lblAudio = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.comboBoxBeatChannel = new System.Windows.Forms.ComboBox();
            this.checkBoxInsertBeats = new System.Windows.Forms.CheckBox();
            this.checkBoxUpdateEventPeriod = new System.Windows.Forms.CheckBox();
            this.groupBoxTapTempo.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tempo:";
            // 
            // tbBPM
            // 
            this.tbBPM.Location = new System.Drawing.Point(98, 20);
            this.tbBPM.Name = "tbBPM";
            this.tbBPM.ReadOnly = true;
            this.tbBPM.Size = new System.Drawing.Size(100, 20);
            this.tbBPM.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(207, 174);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tbMsPerBeat
            // 
            this.tbMsPerBeat.Location = new System.Drawing.Point(98, 46);
            this.tbMsPerBeat.Name = "tbMsPerBeat";
            this.tbMsPerBeat.ReadOnly = true;
            this.tbMsPerBeat.Size = new System.Drawing.Size(100, 20);
            this.tbMsPerBeat.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ms / Beat:";
            // 
            // comboBoxEventsPerBeat
            // 
            this.comboBoxEventsPerBeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventsPerBeat.FormattingEnabled = true;
            this.comboBoxEventsPerBeat.Items.AddRange(new object[] {
            "8",
            "12"});
            this.comboBoxEventsPerBeat.Location = new System.Drawing.Point(98, 85);
            this.comboBoxEventsPerBeat.Name = "comboBoxEventsPerBeat";
            this.comboBoxEventsPerBeat.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEventsPerBeat.TabIndex = 9;
            this.comboBoxEventsPerBeat.SelectedIndexChanged += new System.EventHandler(this.comboBoxEventsPerBeat_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Events / Beat:";
            // 
            // tbEventPeriod
            // 
            this.tbEventPeriod.Location = new System.Drawing.Point(98, 112);
            this.tbEventPeriod.Name = "tbEventPeriod";
            this.tbEventPeriod.ReadOnly = true;
            this.tbEventPeriod.Size = new System.Drawing.Size(100, 20);
            this.tbEventPeriod.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Event Length:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "BPM";
            // 
            // lblBegin
            // 
            this.lblBegin.AutoSize = true;
            this.lblBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBegin.Location = new System.Drawing.Point(21, 179);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(166, 13);
            this.lblBegin.TabIndex = 14;
            this.lblBegin.Text = "Begin tapping when ready...";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(238, 414);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(157, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "ms";
            // 
            // btnPlayStop
            // 
            this.btnPlayStop.Location = new System.Drawing.Point(207, 39);
            this.btnPlayStop.Name = "btnPlayStop";
            this.btnPlayStop.Size = new System.Drawing.Size(75, 23);
            this.btnPlayStop.TabIndex = 18;
            this.btnPlayStop.Text = "Play Audio";
            this.btnPlayStop.UseVisualStyleBackColor = true;
            this.btnPlayStop.Click += new System.EventHandler(this.btnPlayStop_Click);
            // 
            // groupBoxTapTempo
            // 
            this.groupBoxTapTempo.Controls.Add(this.label10);
            this.groupBoxTapTempo.Controls.Add(this.label1);
            this.groupBoxTapTempo.Controls.Add(this.label8);
            this.groupBoxTapTempo.Controls.Add(this.tbBPM);
            this.groupBoxTapTempo.Controls.Add(this.btnReset);
            this.groupBoxTapTempo.Controls.Add(this.lblBegin);
            this.groupBoxTapTempo.Controls.Add(this.label7);
            this.groupBoxTapTempo.Controls.Add(this.tbEventPeriod);
            this.groupBoxTapTempo.Controls.Add(this.label4);
            this.groupBoxTapTempo.Controls.Add(this.label6);
            this.groupBoxTapTempo.Controls.Add(this.tbMsPerBeat);
            this.groupBoxTapTempo.Controls.Add(this.label5);
            this.groupBoxTapTempo.Controls.Add(this.comboBoxEventsPerBeat);
            this.groupBoxTapTempo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTapTempo.Name = "groupBoxTapTempo";
            this.groupBoxTapTempo.Size = new System.Drawing.Size(301, 209);
            this.groupBoxTapTempo.TabIndex = 19;
            this.groupBoxTapTempo.TabStop = false;
            this.groupBoxTapTempo.Text = "Tap Tempo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Use either CTRL key to tap out the tempo.";
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Controls.Add(this.lblAudio);
            this.groupBoxAudio.Controls.Add(this.label9);
            this.groupBoxAudio.Controls.Add(this.btnPlayStop);
            this.groupBoxAudio.Location = new System.Drawing.Point(12, 227);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Size = new System.Drawing.Size(301, 71);
            this.groupBoxAudio.TabIndex = 20;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "Audio";
            // 
            // lblAudio
            // 
            this.lblAudio.AutoSize = true;
            this.lblAudio.Location = new System.Drawing.Point(51, 20);
            this.lblAudio.Name = "lblAudio";
            this.lblAudio.Size = new System.Drawing.Size(41, 13);
            this.lblAudio.TabIndex = 1;
            this.lblAudio.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Audio:";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.comboBoxBeatChannel);
            this.groupBoxActions.Controls.Add(this.checkBoxInsertBeats);
            this.groupBoxActions.Controls.Add(this.checkBoxUpdateEventPeriod);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 304);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(301, 104);
            this.groupBoxActions.TabIndex = 21;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Sequence Actions";
            // 
            // comboBoxBeatChannel
            // 
            this.comboBoxBeatChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBeatChannel.Enabled = false;
            this.comboBoxBeatChannel.FormattingEnabled = true;
            this.comboBoxBeatChannel.Location = new System.Drawing.Point(34, 65);
            this.comboBoxBeatChannel.Name = "comboBoxBeatChannel";
            this.comboBoxBeatChannel.Size = new System.Drawing.Size(244, 21);
            this.comboBoxBeatChannel.TabIndex = 2;
            // 
            // checkBoxInsertBeats
            // 
            this.checkBoxInsertBeats.AutoSize = true;
            this.checkBoxInsertBeats.Location = new System.Drawing.Point(10, 42);
            this.checkBoxInsertBeats.Name = "checkBoxInsertBeats";
            this.checkBoxInsertBeats.Size = new System.Drawing.Size(142, 17);
            this.checkBoxInsertBeats.TabIndex = 1;
            this.checkBoxInsertBeats.Text = "Insert Beats on Channel:";
            this.checkBoxInsertBeats.UseVisualStyleBackColor = true;
            this.checkBoxInsertBeats.CheckedChanged += new System.EventHandler(this.checkBoxInsertBeats_CheckedChanged);
            // 
            // checkBoxUpdateEventPeriod
            // 
            this.checkBoxUpdateEventPeriod.AutoSize = true;
            this.checkBoxUpdateEventPeriod.Checked = true;
            this.checkBoxUpdateEventPeriod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpdateEventPeriod.Location = new System.Drawing.Point(10, 19);
            this.checkBoxUpdateEventPeriod.Name = "checkBoxUpdateEventPeriod";
            this.checkBoxUpdateEventPeriod.Size = new System.Drawing.Size(125, 17);
            this.checkBoxUpdateEventPeriod.TabIndex = 0;
            this.checkBoxUpdateEventPeriod.Text = "Update Event Period";
            this.checkBoxUpdateEventPeriod.UseVisualStyleBackColor = true;
            this.checkBoxUpdateEventPeriod.CheckedChanged += new System.EventHandler(this.checkBoxUpdateEventPeriod_CheckedChanged);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 451);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxAudio);
            this.Controls.Add(this.groupBoxTapTempo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tap Tempo";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainDialog_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDialog_FormClosing);
            this.groupBoxTapTempo.ResumeLayout(false);
            this.groupBoxTapTempo.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBPM;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbMsPerBeat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEventsPerBeat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEventPeriod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPlayStop;
        private System.Windows.Forms.GroupBox groupBoxTapTempo;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.Label lblAudio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.CheckBox checkBoxUpdateEventPeriod;
        private System.Windows.Forms.ComboBox comboBoxBeatChannel;
        private System.Windows.Forms.CheckBox checkBoxInsertBeats;
        private System.Windows.Forms.Label label10;
    }
}

