namespace MACAddressTool
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002244 File Offset: 0x00000444
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			bool flag2 = flag;
			if (flag2)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002280 File Offset: 0x00000480
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::MACAddressTool.Form1));
			this.RandomButton = new global::System.Windows.Forms.Button();
			this.CurrentMacTextBox = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.AdaptersComboBox = new global::System.Windows.Forms.ComboBox();
			this.UpdateButton = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.RandomButton.Location = new global::System.Drawing.Point(230, 69);
			this.RandomButton.Name = "RandomButton";
			this.RandomButton.Size = new global::System.Drawing.Size(169, 21);
			this.RandomButton.TabIndex = 0;
			this.RandomButton.Text = "Generate Random MAC";
			this.RandomButton.UseVisualStyleBackColor = true;
			this.RandomButton.Click += new global::System.EventHandler(this.RandomButton_Click);
			this.CurrentMacTextBox.Location = new global::System.Drawing.Point(128, 69);
			this.CurrentMacTextBox.Name = "CurrentMacTextBox";
			this.CurrentMacTextBox.Size = new global::System.Drawing.Size(96, 20);
			this.CurrentMacTextBox.TabIndex = 1;
			this.CurrentMacTextBox.TextChanged += new global::System.EventHandler(this.CurrentMacTextBox_TextChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(110, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Current MAC address:";
			this.AdaptersComboBox.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AdaptersComboBox.ForeColor = global::System.Drawing.Color.Black;
			this.AdaptersComboBox.FormattingEnabled = true;
			this.AdaptersComboBox.Location = new global::System.Drawing.Point(15, 13);
			this.AdaptersComboBox.Name = "AdaptersComboBox";
			this.AdaptersComboBox.Size = new global::System.Drawing.Size(373, 21);
			this.AdaptersComboBox.TabIndex = 5;
			this.AdaptersComboBox.SelectedIndexChanged += new global::System.EventHandler(this.AdaptersComboBox_SelectedIndexChanged);
			this.UpdateButton.Location = new global::System.Drawing.Point(121, 109);
			this.UpdateButton.Name = "UpdateButton";
			this.UpdateButton.Size = new global::System.Drawing.Size(151, 37);
			this.UpdateButton.TabIndex = 6;
			this.UpdateButton.Text = "Update Mac Address";
			this.UpdateButton.UseVisualStyleBackColor = true;
			this.UpdateButton.Click += new global::System.EventHandler(this.UpdateButton_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::MACAddressTool.Properties.Resources._1;
			base.ClientSize = new global::System.Drawing.Size(404, 176);
			base.Controls.Add(this.UpdateButton);
			base.Controls.Add(this.AdaptersComboBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.CurrentMacTextBox);
			base.Controls.Add(this.RandomButton);
			this.ForeColor = global::System.Drawing.Color.Black;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form1";
			this.Text = "Mac Address Spoofer by AnonLive v1.1 cracked by Skemiil";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.Button RandomButton;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.TextBox CurrentMacTextBox;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.ComboBox AdaptersComboBox;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Button UpdateButton;
	}
}
