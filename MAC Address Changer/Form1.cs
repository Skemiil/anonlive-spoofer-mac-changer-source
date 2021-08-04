using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MACAddressTool.Properties;
using Microsoft.Win32;

namespace MACAddressTool
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (NetworkInterface i in from a in NetworkInterface.GetAllNetworkInterfaces()
			where Form1.Adapter.IsValidMac(a.GetPhysicalAddress().GetAddressBytes(), true)
			orderby a.Speed descending
			select a)
			{
				this.AdaptersComboBox.Items.Add(new Form1.Adapter(i));
			}
			this.AdaptersComboBox.SelectedIndex = 0;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002120 File Offset: 0x00000320
		private void UpdateAddresses()
		{
			Form1.Adapter adapter = this.AdaptersComboBox.SelectedItem as Form1.Adapter;
			this.CurrentMacTextBox.Text = adapter.RegistryMac;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002151 File Offset: 0x00000351
		private void AdaptersComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateAddresses();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000215B File Offset: 0x0000035B
		private void RandomButton_Click(object sender, EventArgs e)
		{
			this.CurrentMacTextBox.Text = Form1.Adapter.GetNewMac();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002170 File Offset: 0x00000370
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			bool flag = !Form1.Adapter.IsValidMac(this.CurrentMacTextBox.Text, false);
			bool flag2 = flag;
			if (flag2)
			{
				MessageBox.Show("Entered MAC-address is not valid; will not update.", "Invalid MAC-address specified", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				this.SetRegistryMac(this.CurrentMacTextBox.Text);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021C3 File Offset: 0x000003C3
		private void ClearButton_Click(object sender, EventArgs e)
		{
			this.SetRegistryMac("");
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021D4 File Offset: 0x000003D4
		private void SetRegistryMac(string mac)
		{
			Form1.Adapter adapter = this.AdaptersComboBox.SelectedItem as Form1.Adapter;
			bool flag = adapter.SetRegistryMac(mac);
			bool flag2 = flag;
			if (flag2)
			{
				Thread.Sleep(100);
				this.UpdateAddresses();
				MessageBox.Show("Done! Please Close This Program To Continue With AnonLive Spoofer!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002151 File Offset: 0x00000351
		private void RereadButton_Click(object sender, EventArgs e)
		{
			this.UpdateAddresses();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002224 File Offset: 0x00000424
		private void CurrentMacTextBox_TextChanged(object sender, EventArgs e)
		{
			this.UpdateButton.Enabled = Form1.Adapter.IsValidMac(this.CurrentMacTextBox.Text, false);
		}

		// Token: 0x02000005 RID: 5
		public class Adapter
		{
			// Token: 0x06000013 RID: 19 RVA: 0x000026F9 File Offset: 0x000008F9
			public Adapter(ManagementObject a, string aname, string cname, int n)
			{
				this.adapter = a;
				this.adaptername = aname;
				this.customname = cname;
				this.devnum = n;
			}

			// Token: 0x06000014 RID: 20 RVA: 0x00002720 File Offset: 0x00000920
			public Adapter(NetworkInterface i) : this(i.Description)
			{
			}

			// Token: 0x06000015 RID: 21 RVA: 0x00002730 File Offset: 0x00000930
			public Adapter(string aname)
			{
				this.adaptername = aname;
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from win32_networkadapter where Name='" + this.adaptername + "'");
				ManagementObjectCollection source = managementObjectSearcher.Get();
				this.adapter = source.Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
				try
				{
					Match match = Regex.Match(this.adapter.Path.RelativePath, "\\\"(\\d+)\\\"$");
					this.devnum = int.Parse(match.Groups[1].Value);
				}
				catch
				{
					return;
				}
				this.customname = (from i in NetworkInterface.GetAllNetworkInterfaces()
				where i.Description == this.adaptername
				select " (" + i.Name + ")").FirstOrDefault<string>();
			}

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000016 RID: 22 RVA: 0x00002814 File Offset: 0x00000A14
			public NetworkInterface ManagedAdapter
			{
				get
				{
					return (from nic in NetworkInterface.GetAllNetworkInterfaces()
					where nic.Description == this.adaptername
					select nic).FirstOrDefault<NetworkInterface>();
				}
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000017 RID: 23 RVA: 0x00002844 File Offset: 0x00000A44
			public string Mac
			{
				get
				{
					string result;
					try
					{
						result = BitConverter.ToString(this.ManagedAdapter.GetPhysicalAddress().GetAddressBytes()).Replace("-", "").ToUpper();
					}
					catch
					{
						result = null;
					}
					return result;
				}
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000018 RID: 24 RVA: 0x0000289C File Offset: 0x00000A9C
			public string RegistryKey
			{
				get
				{
					return string.Format("SYSTEM\\ControlSet001\\Control\\Class\\{{4D36E972-E325-11CE-BFC1-08002BE10318}}\\{0:D4}", this.devnum);
				}
			}

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000019 RID: 25 RVA: 0x000028C4 File Offset: 0x00000AC4
			public string RegistryMac
			{
				get
				{
					string result;
					try
					{
						using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, false))
						{
							result = registryKey.GetValue("NetworkAddress").ToString();
						}
					}
					catch
					{
						result = null;
					}
					return result;
				}
			}

			// Token: 0x0600001A RID: 26 RVA: 0x00002930 File Offset: 0x00000B30
			public bool SetRegistryMac(string value)
			{
				bool flag = false;
				bool result;
				try
				{
					bool flag2 = value.Length > 0 && !Form1.Adapter.IsValidMac(value, false);
					bool flag3 = flag2;
					if (flag3)
					{
						throw new Exception(value + " is not a valid mac address");
					}
					using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, true))
					{
						bool flag4 = registryKey == null;
						bool flag5 = flag4;
						if (flag5)
						{
							throw new Exception("Failed to open the registry key");
						}
						bool flag6 = registryKey.GetValue("AdapterModel") as string != this.adaptername && registryKey.GetValue("DriverDesc") as string != this.adaptername;
						bool flag7 = flag6;
						if (flag7)
						{
							throw new Exception("Adapter not found in registry");
						}
						string format = (value.Length > 0) ? "Changing MAC-adress of adapter {0} from {1} to {2}. Proceed?" : "Clearing custom MAC-address of adapter {0}. Proceed?";
						DialogResult dialogResult = MessageBox.Show(string.Format(format, this.ToString(), this.Mac, value), "Change MAC-address?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag8 = dialogResult != DialogResult.Yes;
						bool flag9 = flag8;
						if (flag9)
						{
							result = false;
						}
						else
						{
							uint num = (uint)this.adapter.InvokeMethod("Disable", null);
							bool flag10 = num > 0U;
							bool flag11 = flag10;
							if (flag11)
							{
								throw new Exception("Failed to disable network adapter.");
							}
							flag = true;
							bool flag12 = value.Length > 0;
							bool flag13 = flag12;
							if (flag13)
							{
								registryKey.SetValue("NetworkAddress", value, RegistryValueKind.String);
							}
							else
							{
								registryKey.DeleteValue("NetworkAddress");
							}
							result = true;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					result = false;
				}
				finally
				{
					bool flag14 = flag;
					bool flag15 = flag14;
					if (flag15)
					{
						uint num2 = (uint)this.adapter.InvokeMethod("Enable", null);
						bool flag16 = num2 > 0U;
						bool flag17 = flag16;
						if (flag17)
						{
							MessageBox.Show("Failed to re-enable network adapter.");
						}
					}
				}
				return result;
			}

			// Token: 0x0600001B RID: 27 RVA: 0x00002B74 File Offset: 0x00000D74
			public override string ToString()
			{
				return this.adaptername + this.customname;
			}

			// Token: 0x0600001C RID: 28 RVA: 0x00002B98 File Offset: 0x00000D98
			public static string GetNewMac()
			{
				Random random = new Random();
				byte[] array = new byte[6];
				random.NextBytes(array);
//				array[0] = (array[0] | 2);
//				array[0] = (array[0] & 254);
				return Form1.Adapter.MacToString(array);
			}

			// Token: 0x0600001D RID: 29 RVA: 0x00002BDC File Offset: 0x00000DDC
			public static bool IsValidMac(string mac, bool actual)
			{
				bool flag = mac.Length != 12;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = mac != mac.ToUpper();
					bool flag4 = flag3;
					if (flag4)
					{
						result = false;
					}
					else
					{
						bool flag5 = !Regex.IsMatch(mac, "^[0-9A-F]*$");
						bool flag6 = flag5;
						if (flag6)
						{
							result = false;
						}
						else if (actual)
						{
							result = true;
						}
						else
						{
							char c = mac[1];
							result = (c == '2' || c == '6' || c == 'A' || c == 'E');
						}
					}
				}
				return result;
			}

			// Token: 0x0600001E RID: 30 RVA: 0x00002C7C File Offset: 0x00000E7C
			public static bool IsValidMac(byte[] bytes, bool actual)
			{
				return Form1.Adapter.IsValidMac(Form1.Adapter.MacToString(bytes), actual);
			}

			// Token: 0x0600001F RID: 31 RVA: 0x00002C9C File Offset: 0x00000E9C
			public static string MacToString(byte[] bytes)
			{
				return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
			}

			// Token: 0x04000009 RID: 9
			public ManagementObject adapter;

			// Token: 0x0400000A RID: 10
			public string adaptername;

			// Token: 0x0400000B RID: 11
			public string customname;

			// Token: 0x0400000C RID: 12
			public int devnum;
		}
	}
}
