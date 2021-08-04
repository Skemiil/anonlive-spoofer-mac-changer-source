using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MACAddressTool.Properties
{
	// Token: 0x02000004 RID: 4
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000265A File Offset: 0x0000085A
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002664 File Offset: 0x00000864
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("MACAddressTool.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000026AC File Offset: 0x000008AC
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000026C3 File Offset: 0x000008C3
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000026CC File Offset: 0x000008CC
		internal static Bitmap _1
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("1", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x04000007 RID: 7
		private static ResourceManager resourceMan;

		// Token: 0x04000008 RID: 8
		private static CultureInfo resourceCulture;
	}
}
