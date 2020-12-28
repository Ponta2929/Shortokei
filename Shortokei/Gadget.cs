using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Shortokei
{
    public partial class Gadget : LayeredWindow
    {
        private Setting setting = Setting.GetInstance();

        // マウスキャプチャ
        private int x, y;

        // 描画サーフェイス
        private Bitmap surface;

        private Pen pen_border;

        // 指定時間用
        private int counter, counter2;

        // 指定チェック
        private bool gadget_topmost;

        // Zオーダー格納
        private int order;


        public Gadget()
        {
            InitializeComponent();

            // Initialize
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                // 設定読み込み
                setting.FileDeserialize($"{Application.StartupPath}\\setting.xml");
                Left = setting.Gadget_X;
                Top = setting.Gadget_Y;
            }
            catch
            {

            }

            setting.ValueChanged += (s, e) => UpdateGadget();

            // 初期化を行います。
            pen_border = new Pen(Color.FromArgb(128, 128, 128, 128));

            // 描画更新
            Timer_Update.Start();

            // 表示
            UpdateGadget();
        }

        private void Timer_Update_Tick(object sender, EventArgs e)
        {
            // 1分ごとにガジェットを更新する。
            if (DateTime.Now.Second == 0)
                UpdateGadget();

            // 全面表示(常に手前に表示する)
            if (setting.Gadget_Selection_TopMost)
            {
                if (setting.TimeLock)
                {
                    // 現在時刻(秒)
                    var time =
                        (DateTime.Now.Hour * 60 * 60) +
                        (DateTime.Now.Minute * 60) +
                        DateTime.Now.Second;

                    if (time % setting.SelectTime1 == 0)
                        gadget_topmost = true;
                }
                else
                {
                    if (counter > setting.SelectTime1)
                        gadget_topmost = true;

                    counter++;
                }

                // ガジェットを最前面にする。
                if (gadget_topmost)
                {
                    if (TopMost == false)
                    {
                        order = GetWindowOrder(Handle);

                        // ガジェット最前面
                        TopMost = true;
                    }

                    if (counter2 > setting.SelectTime2)
                    {
                        gadget_topmost = TopMost = false;

                        // ガジェットの位置を戻す
                        SetWindowOrder(Handle, order);

                        // カウンター初期化
                        counter = counter2 = 0;
                    }

                    counter2++;
                }
            }
        }

        #region マウス移動

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !setting.Gadget_MoveLock)
            {
                // Position
                var left = Left + e.X - x;
                var top = Top + e.Y - y;
                var hit = false;

                if (setting.Gadget_WindowSnap)
                {
                    var screen = Screen.AllScreens;

                    for (var i = 0; i < screen.Length; i++)
                    {
                        var work = screen[i].WorkingArea;

                        // Screenサイズ
                        var height = work.Y + work.Height;
                        var width = work.X + work.Width;

                        if (work.Y < top + 10 && work.Y > top - 10)
                        {
                            Top = work.Y;
                            // hit = true;
                        }
                        else if (height < top + Height + 10 && height > top + Height - 10)
                        {
                            Top = height - Height;
                            // hit = true;
                        }
                        else
                        {
                            Top = top;
                        }

                        if (work.X < left + 10 && work.X > left - 10)
                        {
                            Left = work.X;
                            hit = true;
                        }
                        else if (width < left + Width + 10 && width > left + Width - 10)
                        {
                            Left = width - Width;
                            hit = true;
                        }
                        else
                        {
                            Left = left;
                        }

                        if (hit)
                            break;
                    }
                }
                else
                {
                    Top = top;
                    Left = left;
                }
            }

            base.OnMouseMove(e);
        }

        #endregion

        /// <summary>
        /// 画面を更新します。
        /// </summary>
        public void UpdateGadget()
        {
            // サーフェイス作成
            if (surface == null || surface.Height != setting.Gadget_Height || surface.Width != setting.Gadget_Width)
            {
                surface = new Bitmap(setting.Gadget_Width, setting.Gadget_Height);
            }

            using (var g = Graphics.FromImage(surface))
            {
                // アンチエイリアスON
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // 画面消去
                g.Clear(Color.Transparent);

                // 今
                var now = DateTime.Now;

                // グラデーション用
                var a1 = (setting.GraphColor1_1.A - setting.GraphColor2_1.A) / 1440f * (now.Minute + (now.Hour * 60));
                var a2 = (setting.GraphColor1_2.A - setting.GraphColor2_2.A) / 1440f * (now.Minute + (now.Hour * 60));
                var r1 = (setting.GraphColor1_1.R - setting.GraphColor2_1.R) / 1440f * (now.Minute + (now.Hour * 60));
                var r2 = (setting.GraphColor1_2.R - setting.GraphColor2_2.R) / 1440f * (now.Minute + (now.Hour * 60));
                var g1 = (setting.GraphColor1_1.G - setting.GraphColor2_1.G) / 1440f * (now.Minute + (now.Hour * 60));
                var g2 = (setting.GraphColor1_2.G - setting.GraphColor2_2.G) / 1440f * (now.Minute + (now.Hour * 60));
                var b1 = (setting.GraphColor1_1.B - setting.GraphColor2_1.B) / 1440f * (now.Minute + (now.Hour * 60));
                var b2 = (setting.GraphColor1_2.B - setting.GraphColor2_2.B) / 1440f * (now.Minute + (now.Hour * 60));

                // ウィンドウ描画
                var window = new Rectangle(1, 1, surface.Width - 3, surface.Height - 3);
                g.DrawCurveRectangle(pen_border, new Rectangle(0, 0, surface.Width - 1, surface.Height - 1), 8);

                using (var brush_window = new LinearGradientBrush(g.VisibleClipBounds, setting.BackgroundColor1, setting.BackgroundColor2, LinearGradientMode.Vertical))
                {
                    g.FillCurveRectangle(brush_window, window, 8);
                }

                // 描画位置の規制
                g.Clip = new Region(DrawPath(window, 8));

                using (var brush_bar = new LinearGradientBrush(g.VisibleClipBounds,
                    Color.FromArgb(setting.GraphColor1_1.A - (int)a1,
                        setting.GraphColor1_1.R - (int)r1,
                        setting.GraphColor1_1.G - (int)g1,
                        setting.GraphColor1_1.B - (int)b1),
                        Color.FromArgb(setting.GraphColor1_2.A - (int)a2,
                        setting.GraphColor1_2.R - (int)r2,
                        setting.GraphColor1_2.G - (int)g2,
                        setting.GraphColor1_2.B - (int)b2),
                        LinearGradientMode.Vertical))
                {
                    g.FillCurveRectangle(brush_bar, new Rectangle(1, 1, (surface.Width - 3) * (now.Minute + (now.Hour * 60)) / 1440, surface.Height - 3), 8);
                }
                g.ResetClip();

                // 文字サイズ
                SizeF s_size;

                // 時間描画
                for (int i = 0; i < 24; i++)
                {
                    // 描画文字のサイズを取得
                    s_size = g.MeasureString(i.ToString(), setting.TimeStringFont, 1000, new StringFormat());

                    if (i < now.Hour)
                    {
                        // 取得したサイズを適応して描画
                        using (var timeEnd = new SolidBrush(setting.TimeEndStringColor))
                        {
                            g.DrawString(i.ToString(), setting.TimeStringFont, timeEnd, new PointF((surface.Width / 24f * i) + (surface.Width / 24f / 2f) - (s_size.Width / 2f), ((surface.Height / 3f) * 3f) - ((s_size.Height / 3f) * 3f)));
                        }

                        if (setting.Finished)
                        {
                            // 描画文字のサイズを取得
                            s_size = g.MeasureString("×", setting.EndStringFont, 1000, new StringFormat());

                            // 取得したサイズを適応して描画
                            using (var EndString = new SolidBrush(setting.EndStringColor))
                            {
                                g.DrawString("×", setting.EndStringFont, EndString, new PointF((surface.Width / 24f * i) + (surface.Width / 24f / 2f) - (s_size.Width / 2f), ((surface.Height / 3f) * 3f) - ((s_size.Height / 3f) * 3f)));
                            }
                        }
                    }
                    else
                    {
                        // 取得したサイズを適応して描画 
                        using (var TimeString = new SolidBrush(setting.TimeStringColor))
                        {
                            g.DrawString(i.ToString(), setting.TimeStringFont, TimeString, new PointF((surface.Width / 24f * i) + (surface.Width / 24f / 2f) - (s_size.Width / 2f), ((surface.Height / 3f) * 3f) - ((s_size.Height / 3f) * 3f)));
                        }
                    }
                }


                // 文字サイズ
                s_size = g.MeasureString(now.ToString("HH:mm"), setting.TimeDescriptionFont, 1000, new StringFormat());

                var time_rect = new Rectangle((int)Range(surface.Width - s_size.Width - 4, 2, (((surface.Width - 3) * (now.Minute + now.Hour * 60) / 1440) - (s_size.Width / 2)) - 2), (int)((surface.Height / 3) - (s_size.Height / 3)) - 2, (int)Range(surface.Width - s_size.Width, 2, s_size.Width + 2), (int)s_size.Height + 2);

                // 時間描画 
                using (var brush_time = new LinearGradientBrush(time_rect, setting.TimeBackgroundColor1, setting.TimeBackgroundColor2, LinearGradientMode.Vertical))
                {
                    g.FillCurveRectangle(brush_time, time_rect, 8);
                }

                g.DrawCurveRectangle(pen_border, time_rect, 8);

                using (var TimeDesc = new SolidBrush(setting.TimeDescriptionStringColor))
                {
                    g.DrawString(now.ToString("HH:mm"), setting.TimeDescriptionFont, TimeDesc, new PointF(Range(surface.Width - s_size.Width - 2, 4, ((surface.Width - 3) * (now.Minute + now.Hour * 60) / 1440) - (s_size.Width / 2)), (surface.Height / 3) - (s_size.Height / 3)));
                }

                if (setting.Division)
                {
                    for (var i = 1; i < 24; i++)
                    {
                        g.DrawLine(Pens.Silver, new Point((int)(surface.Width / 24f * i), surface.Height - 4), new Point((int)(surface.Width / 24f * i), surface.Height - 2));
                    }
                }

                // 枠
                g.DrawCurveRectangle(Pens.WhiteSmoke, window, 8);
            }

            // 画像のセット
            SetLayeredWindow(surface);
        }

        private float Range(float max, float min, float value)
        {
            if (max < value)
                return max;
            else if (min > value)
                return min;
            return value;
        }

        private GraphicsPath DrawPath(Rectangle rect, int curve)
        {
            var gp = new GraphicsPath();

            // パスの追加
            gp.StartFigure();
            gp.AddArc(rect.Right - curve, rect.Top, 8, 8, 270, 90); // 右上
            gp.AddArc(rect.Right - curve, rect.Bottom - curve, 8, 8, 0, 90); // 右上
            gp.AddArc(rect.Left, rect.Bottom - curve, 8, 8, 90, 90); // 右上
            gp.AddArc(rect.Left, rect.Top, 8, 8, 180, 90); // 右上
            gp.CloseFigure();

            // 戻り値
            return gp;
        }

        /// <summary>
        /// ウィンドウのオーダーを取得します。
        /// </summary>
        /// <param name="handle">オーダーを取得するウィンドウハンドル</param>
        /// <returns></returns>
        private int GetWindowOrder(IntPtr handle)
        {
            var count = 0;

            var window = Win32API.GetWindow(handle, Win32API.GW_HWNDFIRST);

            while (true)
            {
                window = Win32API.GetWindow(window, Win32API.GW_HWNDNEXT);

                if (window == handle)
                    break;

                count++;
            }

            return count;
        }

        /// <summary>
        /// ウィンドウのオーダーを設定します。
        /// </summary>
        /// <param name="handle">オーダーを設定するウィンドウハンドル</param>
        /// <param name="order">ウィンドウ番号</param>
        private void SetWindowOrder(IntPtr handle, int order)
        {
            var count = 0;

            var window = Win32API.GetWindow(handle, Win32API.GW_HWNDFIRST);

            while (true)
            {
                window = Win32API.GetWindow(window, Win32API.GW_HWNDNEXT);

                if (count == order + 1)
                {
                    Win32API.SetWindowPos(handle, window, 0, 0, 0, 0, Win32API.SWP_NOSIZE | Win32API.SWP_NOMOVE);

                    // 終わり
                    break;
                }
                count++;
            }
        }

        private void NotifyIcon_Main_MouseClick(object sender, MouseEventArgs e)
        {
            this.Activate();
        }

        private void ToolStripMenuItem_Lock_CheckedChanged(object sender, EventArgs e)
        {
            // ガジェットを移動不可にする
            setting.Gadget_MoveLock = ToolStripMenuItem_Lock.Checked;
        }

        private void ToolStripMenuItem_TopMost_Click(object sender, EventArgs e)
        {
            // 常に手前に表示する
            setting.Gadget_Selection_TopMost = ToolStripMenuItem_Timing.Checked = false;
            TopMost = setting.Gadget_TopMost = ToolStripMenuItem_TopMost.Checked;
        }

        private void ToolStripMenuItem_Timing_Click(object sender, EventArgs e)
        {
            // 常に手前に表示する[指定]
            TopMost = setting.Gadget_TopMost = ToolStripMenuItem_TopMost.Checked = false;
            setting.Gadget_Selection_TopMost = ToolStripMenuItem_Timing.Checked;
        }

        private void ToolStripMenuItem_Setting_Click(object sender, EventArgs e)
        {
            // 画面を閉じる
            new SettingForm().Show(this);
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            NotifyIcon_Main.Visible = false;

            try
            {
                setting.Gadget_X = Left;
                setting.Gadget_Y = Top;
                setting.FileSerialize($"{Application.StartupPath}\\setting.xml");
            }
            catch
            {

            }

            // Exit
            Application.Exit();
        }
    }
}
