using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shortokei
{
	partial class Gadget
	{
		private NotifyIcon NotifyIcon_Main = new NotifyIcon();
		private ContextMenuStrip ContextMenuStrip_Main = new ContextMenuStrip();
		private ToolStripMenuItem ToolStripMenuItem_Setting = new ToolStripMenuItem();
		private ToolStripMenuItem ToolStripMenuItem_Lock = new ToolStripMenuItem();
		private ToolStripMenuItem ToolStripMenuItem_TopMost = new ToolStripMenuItem();
		private ToolStripMenuItem ToolStripMenuItem_Timing = new ToolStripMenuItem();
		private ToolStripMenuItem ToolStripMenuItem_Exit = new ToolStripMenuItem();
		private ToolStripSeparator ToolStripSeparator_1 = new ToolStripSeparator();
		private ToolStripSeparator ToolStripSeparator_2 = new ToolStripSeparator();
		private Timer updateTimer = new Timer();

		private void InitializeComponent()
		{
			NotifyIcon_Main.ContextMenuStrip = this.ContextMenuStrip_Main;
			NotifyIcon_Main.Icon = Properties.Resources.tokei;
			NotifyIcon_Main.Text = "しょーとけい";
			NotifyIcon_Main.Visible = true;
			NotifyIcon_Main.MouseClick += NotifyIcon_Main_MouseClick;

			ContextMenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
			   ToolStripMenuItem_Setting,
			   ToolStripSeparator_1,
			   ToolStripMenuItem_Lock,
			   ToolStripMenuItem_TopMost,
			   ToolStripMenuItem_Timing,
			   ToolStripSeparator_2,
			   ToolStripMenuItem_Exit
			});
			ContextMenuStrip_Main.Name = "ContextMenuStrip_Main";
			ContextMenuStrip_Main.Size = new System.Drawing.Size(213, 126);
			ToolStripMenuItem_Setting.Name = "ToolStripMenuItem_Setting";
			ToolStripMenuItem_Setting.Size = new System.Drawing.Size(212, 22);
			ToolStripMenuItem_Setting.Text = "設定(&S)";
			ToolStripMenuItem_Setting.Click += this.ToolStripMenuItem_Setting_Click;
			ToolStripSeparator_1.Name = "ToolStripSeparator_1";
			ToolStripSeparator_1.Size = new System.Drawing.Size(209, 6);
			ToolStripMenuItem_Lock.CheckOnClick = true;
			ToolStripMenuItem_Lock.Name = "ToolStripMenuItem_Lock";
			ToolStripMenuItem_Lock.Size = new System.Drawing.Size(212, 22);
			ToolStripMenuItem_Lock.Text = "移動ロック(&L)";
			ToolStripMenuItem_Lock.CheckedChanged += this.ToolStripMenuItem_Lock_CheckedChanged;
			ToolStripMenuItem_TopMost.CheckOnClick = true;
			ToolStripMenuItem_TopMost.Name = "ToolStripMenuItem_TopMost";
			ToolStripMenuItem_TopMost.Size = new System.Drawing.Size(212, 22);
			ToolStripMenuItem_TopMost.Text = "常に手前に表示(&A)";
			ToolStripMenuItem_TopMost.Click += ToolStripMenuItem_TopMost_Click;
			ToolStripMenuItem_Timing.CheckOnClick = true;
			ToolStripMenuItem_Timing.Name = "ToolStripMenuItem_Timing";
			ToolStripMenuItem_Timing.Size = new System.Drawing.Size(212, 22);
			ToolStripMenuItem_Timing.Text = "常に手前に表示[指定](&T)";
			ToolStripMenuItem_Timing.Click += ToolStripMenuItem_Timing_Click;
			ToolStripSeparator_2.Name = "ToolStripSeparator_2";
			ToolStripSeparator_2.Size = new System.Drawing.Size(209, 6);
			ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
			ToolStripMenuItem_Exit.Size = new System.Drawing.Size(212, 22);
			ToolStripMenuItem_Exit.Text = "終了(&X)";
			ToolStripMenuItem_Exit.Click += ToolStripMenuItem_Exit_Click;
			updateTimer.Interval = 1000;
			updateTimer.Tick += UpdateTimer_Tick;
		}
	}
}
