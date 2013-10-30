namespace ColorOrgan
{
	public partial class ColorOrganForm
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
			this.labelNumberOfColorGroups = new System.Windows.Forms.Label();
			this.buttonNewColorGroup = new System.Windows.Forms.Button();
			this.buttonEditColorGroup = new System.Windows.Forms.Button();
			this.buttonDeleteColorGroup = new System.Windows.Forms.Button();
			this.buttonSetChans = new System.Windows.Forms.Button();
			this.listBoxColorBands = new System.Windows.Forms.ListBox();
			this.buttonClearChannels = new System.Windows.Forms.Button();
			this.buttonCopy = new System.Windows.Forms.Button();
			this.buttonDefaults = new System.Windows.Forms.Button();
			this.numericUpDownStartChan = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownNumBands = new System.Windows.Forms.NumericUpDown();
			this.labelStartChan = new System.Windows.Forms.Label();
			this.labelNumBands = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartChan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumBands)).BeginInit();
			this.SuspendLayout();
			// 
			// labelNumberOfColorGroups
			// 
			this.labelNumberOfColorGroups.AutoSize = true;
			this.labelNumberOfColorGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumberOfColorGroups.Location = new System.Drawing.Point(44, 30);
			this.labelNumberOfColorGroups.Name = "labelNumberOfColorGroups";
			this.labelNumberOfColorGroups.Size = new System.Drawing.Size(75, 13);
			this.labelNumberOfColorGroups.TabIndex = 1;
			this.labelNumberOfColorGroups.Text = "Color Bands";
			// 
			// buttonNewColorGroup
			// 
			this.buttonNewColorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonNewColorGroup.Location = new System.Drawing.Point(224, 48);
			this.buttonNewColorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.buttonNewColorGroup.Name = "buttonNewColorGroup";
			this.buttonNewColorGroup.Size = new System.Drawing.Size(93, 32);
			this.buttonNewColorGroup.TabIndex = 3;
			this.buttonNewColorGroup.Text = "Add New";
			this.buttonNewColorGroup.UseVisualStyleBackColor = true;
			this.buttonNewColorGroup.Click += new System.EventHandler(this.buttonNewColorGroup_Click);
			// 
			// buttonEditColorGroup
			// 
			this.buttonEditColorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEditColorGroup.Location = new System.Drawing.Point(224, 132);
			this.buttonEditColorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.buttonEditColorGroup.Name = "buttonEditColorGroup";
			this.buttonEditColorGroup.Size = new System.Drawing.Size(93, 32);
			this.buttonEditColorGroup.TabIndex = 4;
			this.buttonEditColorGroup.Text = "Edit";
			this.buttonEditColorGroup.UseVisualStyleBackColor = true;
			this.buttonEditColorGroup.Click += new System.EventHandler(this.buttonEditColorGroup_Click);
			// 
			// buttonDeleteColorGroup
			// 
			this.buttonDeleteColorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDeleteColorGroup.Location = new System.Drawing.Point(224, 168);
			this.buttonDeleteColorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.buttonDeleteColorGroup.Name = "buttonDeleteColorGroup";
			this.buttonDeleteColorGroup.Size = new System.Drawing.Size(93, 32);
			this.buttonDeleteColorGroup.TabIndex = 5;
			this.buttonDeleteColorGroup.Text = "Delete";
			this.buttonDeleteColorGroup.UseVisualStyleBackColor = true;
			this.buttonDeleteColorGroup.Click += new System.EventHandler(this.buttonDeleteColorGroup_Click);
			// 
			// buttonSetChans
			// 
			this.buttonSetChans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSetChans.Location = new System.Drawing.Point(224, 216);
			this.buttonSetChans.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSetChans.Name = "buttonSetChans";
			this.buttonSetChans.Size = new System.Drawing.Size(93, 32);
			this.buttonSetChans.TabIndex = 6;
			this.buttonSetChans.Text = "Set Chans";
			this.buttonSetChans.UseVisualStyleBackColor = true;
			this.buttonSetChans.Click += new System.EventHandler(this.buttonSetChans_Click);
			// 
			// listBoxColorBands
			// 
			this.listBoxColorBands.FormattingEnabled = true;
			this.listBoxColorBands.Location = new System.Drawing.Point(46, 48);
			this.listBoxColorBands.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxColorBands.Name = "listBoxColorBands";
			this.listBoxColorBands.Size = new System.Drawing.Size(165, 407);
			this.listBoxColorBands.TabIndex = 7;
			this.listBoxColorBands.DoubleClick += new System.EventHandler(this.buttonEditColorGroup_Click);
			// 
			// buttonClearChannels
			// 
			this.buttonClearChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonClearChannels.Location = new System.Drawing.Point(224, 252);
			this.buttonClearChannels.Margin = new System.Windows.Forms.Padding(2);
			this.buttonClearChannels.Name = "buttonClearChannels";
			this.buttonClearChannels.Size = new System.Drawing.Size(93, 32);
			this.buttonClearChannels.TabIndex = 8;
			this.buttonClearChannels.Text = "Clear Chans";
			this.buttonClearChannels.UseVisualStyleBackColor = true;
			this.buttonClearChannels.Click += new System.EventHandler(this.buttonClearChannels_Click);
			// 
			// buttonCopy
			// 
			this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCopy.Location = new System.Drawing.Point(224, 84);
			this.buttonCopy.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(93, 32);
			this.buttonCopy.TabIndex = 9;
			this.buttonCopy.Text = "Copy";
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			// 
			// buttonDefaults
			// 
			this.buttonDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDefaults.Location = new System.Drawing.Point(224, 364);
			this.buttonDefaults.Margin = new System.Windows.Forms.Padding(2);
			this.buttonDefaults.Name = "buttonDefaults";
			this.buttonDefaults.Size = new System.Drawing.Size(93, 32);
			this.buttonDefaults.TabIndex = 10;
			this.buttonDefaults.Text = "Auto Build";
			this.buttonDefaults.UseVisualStyleBackColor = true;
			this.buttonDefaults.Click += new System.EventHandler(this.buttonDefaults_Click);
			// 
			// numericUpDownStartChan
			// 
			this.numericUpDownStartChan.Location = new System.Drawing.Point(224, 417);
			this.numericUpDownStartChan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownStartChan.Name = "numericUpDownStartChan";
			this.numericUpDownStartChan.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownStartChan.TabIndex = 11;
			this.numericUpDownStartChan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDownNumBands
			// 
			this.numericUpDownNumBands.Location = new System.Drawing.Point(224, 465);
			this.numericUpDownNumBands.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.numericUpDownNumBands.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNumBands.Name = "numericUpDownNumBands";
			this.numericUpDownNumBands.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownNumBands.TabIndex = 12;
			this.numericUpDownNumBands.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
			// 
			// labelStartChan
			// 
			this.labelStartChan.AutoSize = true;
			this.labelStartChan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStartChan.Location = new System.Drawing.Point(224, 398);
			this.labelStartChan.Name = "labelStartChan";
			this.labelStartChan.Size = new System.Drawing.Size(79, 13);
			this.labelStartChan.TabIndex = 13;
			this.labelStartChan.Text = "Start Chan #";
			// 
			// labelNumBands
			// 
			this.labelNumBands.AutoSize = true;
			this.labelNumBands.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNumBands.Location = new System.Drawing.Point(224, 449);
			this.labelNumBands.Name = "labelNumBands";
			this.labelNumBands.Size = new System.Drawing.Size(71, 13);
			this.labelNumBands.TabIndex = 14;
			this.labelNumBands.Text = "Num Bands";
			// 
			// ColorOrganForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(358, 497);
			this.Controls.Add(this.labelNumBands);
			this.Controls.Add(this.labelStartChan);
			this.Controls.Add(this.numericUpDownNumBands);
			this.Controls.Add(this.numericUpDownStartChan);
			this.Controls.Add(this.buttonDefaults);
			this.Controls.Add(this.buttonCopy);
			this.Controls.Add(this.buttonClearChannels);
			this.Controls.Add(this.listBoxColorBands);
			this.Controls.Add(this.buttonSetChans);
			this.Controls.Add(this.buttonDeleteColorGroup);
			this.Controls.Add(this.buttonEditColorGroup);
			this.Controls.Add(this.buttonNewColorGroup);
			this.Controls.Add(this.labelNumberOfColorGroups);
			this.Name = "ColorOrganForm";
			this.Text = "ColorOrgan";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartChan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumBands)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelNumberOfColorGroups;
		private System.Windows.Forms.Button buttonNewColorGroup;
		private System.Windows.Forms.Button buttonEditColorGroup;
		private System.Windows.Forms.Button buttonDeleteColorGroup;
		private System.Windows.Forms.Button buttonSetChans;
		private System.Windows.Forms.ListBox listBoxColorBands;
		private System.Windows.Forms.Button buttonClearChannels;
		private System.Windows.Forms.Button buttonCopy;
		private System.Windows.Forms.Button buttonDefaults;
		private System.Windows.Forms.NumericUpDown numericUpDownStartChan;
		private System.Windows.Forms.NumericUpDown numericUpDownNumBands;
		private System.Windows.Forms.Label labelStartChan;
		private System.Windows.Forms.Label labelNumBands;

	}
}