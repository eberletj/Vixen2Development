namespace GenericSerial
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;
    using Vixen;

    internal class SetupDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private CheckBox checkBoxFooter;
        private CheckBox checkBoxHeader;
        private ComboBox comboBoxBaud;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private XmlNode m_setupNode;
        private NumericUpDown numericUpDownPort;
        private TextBox textBoxFooter;
        private TextBox textBoxHeader;

        public SetupDialog(XmlNode setupNode)
        {
            this.InitializeComponent();
            this.m_setupNode = setupNode;
            string innerText = Xml.GetNodeAlways(this.m_setupNode, "Name").InnerText;
            this.numericUpDownPort.Value = (innerText.Length > 3) ? int.Parse(innerText.Substring(3)) : 1;
            innerText = Xml.GetNodeAlways(this.m_setupNode, "Baud").InnerText;
            this.comboBoxBaud.SelectedIndex = this.comboBoxBaud.Items.IndexOf(innerText);
            XmlNode nodeAlways = Xml.GetNodeAlways(this.m_setupNode, "Header");
            if (nodeAlways.Attributes["checked"] != null)
            {
                this.checkBoxHeader.Checked = bool.Parse(nodeAlways.Attributes["checked"].Value);
            }
            this.textBoxHeader.Text = nodeAlways.InnerText;
            nodeAlways = Xml.GetNodeAlways(this.m_setupNode, "Footer");
            if (nodeAlways.Attributes["checked"] != null)
            {
                this.checkBoxFooter.Checked = bool.Parse(nodeAlways.Attributes["checked"].Value);
            }
            this.textBoxFooter.Text = nodeAlways.InnerText;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Xml.SetValue(this.m_setupNode, "Name", "COM" + ((int) this.numericUpDownPort.Value).ToString());
            Xml.SetValue(this.m_setupNode, "Baud", this.comboBoxBaud.Text.ToString());
            Xml.SetAttribute(this.m_setupNode, "Header", "checked", this.checkBoxHeader.Checked.ToString()).InnerText = this.textBoxHeader.Text;
            Xml.SetAttribute(this.m_setupNode, "Footer", "checked", this.checkBoxFooter.Checked.ToString()).InnerText = this.textBoxFooter.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFooter = new System.Windows.Forms.TextBox();
            this.checkBoxFooter = new System.Windows.Forms.CheckBox();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.checkBoxHeader = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxBaud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Items.AddRange(new object[] {
            "2400",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaud.Location = new System.Drawing.Point(157, 22);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(79, 21);
            this.comboBoxBaud.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud";
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(52, 23);
            this.numericUpDownPort.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownPort.TabIndex = 1;
            this.numericUpDownPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(115, 231);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(196, 231);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxFooter);
            this.groupBox2.Controls.Add(this.checkBoxFooter);
            this.groupBox2.Controls.Add(this.textBoxHeader);
            this.groupBox2.Controls.Add(this.checkBoxHeader);
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 138);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Packet Data";
            // 
            // textBoxFooter
            // 
            this.textBoxFooter.Location = new System.Drawing.Point(32, 107);
            this.textBoxFooter.Name = "textBoxFooter";
            this.textBoxFooter.Size = new System.Drawing.Size(204, 20);
            this.textBoxFooter.TabIndex = 3;
            // 
            // checkBoxFooter
            // 
            this.checkBoxFooter.AutoSize = true;
            this.checkBoxFooter.Location = new System.Drawing.Point(13, 84);
            this.checkBoxFooter.Name = "checkBoxFooter";
            this.checkBoxFooter.Size = new System.Drawing.Size(110, 17);
            this.checkBoxFooter.TabIndex = 2;
            this.checkBoxFooter.Text = "Send a text footer";
            this.checkBoxFooter.UseVisualStyleBackColor = true;
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Location = new System.Drawing.Point(32, 49);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.Size = new System.Drawing.Size(204, 20);
            this.textBoxHeader.TabIndex = 1;
            // 
            // checkBoxHeader
            // 
            this.checkBoxHeader.AutoSize = true;
            this.checkBoxHeader.Location = new System.Drawing.Point(13, 26);
            this.checkBoxHeader.Name = "checkBoxHeader";
            this.checkBoxHeader.Size = new System.Drawing.Size(116, 17);
            this.checkBoxHeader.TabIndex = 0;
            this.checkBoxHeader.Text = "Send a text header";
            this.checkBoxHeader.UseVisualStyleBackColor = true;
            // 
            // SetupDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(283, 266);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetupDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

