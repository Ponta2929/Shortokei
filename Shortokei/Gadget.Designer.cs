namespace Shortokei
{
    partial class Gadget
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer_Update = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuStrip_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Lock = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_TopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Timing = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon_Main = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_Update
            // 
            this.Timer_Update.Enabled = true;
            this.Timer_Update.Interval = 1000;
            this.Timer_Update.Tick += new System.EventHandler(this.Timer_Update_Tick);
            // 
            // ContextMenuStrip_Main
            // 
            this.ContextMenuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Setting,
            this.ToolStripSeparator_1,
            this.ToolStripMenuItem_Lock,
            this.ToolStripMenuItem_TopMost,
            this.ToolStripMenuItem_Timing,
            this.ToolStripSeparator_2,
            this.ToolStripMenuItem_Exit});
            this.ContextMenuStrip_Main.Name = "ContextMenuStrip_Main";
            this.ContextMenuStrip_Main.Size = new System.Drawing.Size(199, 126);
            // 
            // ToolStripMenuItem_Setting
            // 
            this.ToolStripMenuItem_Setting.Name = "ToolStripMenuItem_Setting";
            this.ToolStripMenuItem_Setting.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_Setting.Text = "設定(&S)";
            this.ToolStripMenuItem_Setting.Click += new System.EventHandler(this.ToolStripMenuItem_Setting_Click);
            // 
            // ToolStripSeparator_1
            // 
            this.ToolStripSeparator_1.Name = "ToolStripSeparator_1";
            this.ToolStripSeparator_1.Size = new System.Drawing.Size(195, 6);
            // 
            // ToolStripMenuItem_Lock
            // 
            this.ToolStripMenuItem_Lock.CheckOnClick = true;
            this.ToolStripMenuItem_Lock.Name = "ToolStripMenuItem_Lock";
            this.ToolStripMenuItem_Lock.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_Lock.Text = "移動ロック(&L)";
            this.ToolStripMenuItem_Lock.CheckedChanged += new System.EventHandler(this.ToolStripMenuItem_Lock_CheckedChanged);
            // 
            // ToolStripMenuItem_TopMost
            // 
            this.ToolStripMenuItem_TopMost.CheckOnClick = true;
            this.ToolStripMenuItem_TopMost.Name = "ToolStripMenuItem_TopMost";
            this.ToolStripMenuItem_TopMost.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_TopMost.Text = "常に手前に表示(&A)";
            this.ToolStripMenuItem_TopMost.Click += new System.EventHandler(this.ToolStripMenuItem_TopMost_Click);
            // 
            // ToolStripMenuItem_Timing
            // 
            this.ToolStripMenuItem_Timing.CheckOnClick = true;
            this.ToolStripMenuItem_Timing.Name = "ToolStripMenuItem_Timing";
            this.ToolStripMenuItem_Timing.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_Timing.Text = "常に手前に表示[指定](&T)";
            this.ToolStripMenuItem_Timing.Click += new System.EventHandler(this.ToolStripMenuItem_Timing_Click);
            // 
            // ToolStripSeparator_2
            // 
            this.ToolStripSeparator_2.Name = "ToolStripSeparator_2";
            this.ToolStripSeparator_2.Size = new System.Drawing.Size(195, 6);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_Exit.Text = "終了(&X)";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // NotifyIcon_Main
            // 
            this.NotifyIcon_Main.ContextMenuStrip = this.ContextMenuStrip_Main;
            this.NotifyIcon_Main.Icon = global::Shortokei.Properties.Resources.tokei;
            this.NotifyIcon_Main.Text = "しょーとけい";
            this.NotifyIcon_Main.Visible = true;
            this.NotifyIcon_Main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_Main_MouseClick);
            // 
            // Gadget
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Gadget";
            this.ContextMenuStrip_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer_Update;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setting;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Lock;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_TopMost;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Timing;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.NotifyIcon NotifyIcon_Main;
    }
}
