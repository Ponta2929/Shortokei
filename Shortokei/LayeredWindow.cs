using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shortokei
{
    public class LayeredWindow : Form
    {
        public LayeredWindow()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
        }

        /// <summary>
        /// レイヤード ウィンドウを設定します。
        /// </summary>
        /// <param name="srcBitmap">表示する画像</param>
        public void SetLayeredWindow(Bitmap srcBitmap)
        {
            // デバイスコンテキストを取得
            var screenDc = IntPtr.Zero;
            var memDc = IntPtr.Zero;
            var hBitmap = IntPtr.Zero;
            var hOldBitmap = IntPtr.Zero;

            try
            {
                screenDc = Win32API.GetDC(IntPtr.Zero);
                memDc = Win32API.CreateCompatibleDC(screenDc);
                hBitmap = srcBitmap.GetHbitmap(Color.FromArgb(0));
                hOldBitmap = Win32API.SelectObject(memDc, hBitmap);

                // BLENDFUNCTION を初期化
                var blend = new Win32API.BLENDFUNCTION()
                {
                    BlendOp = Win32API.AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = Win32API.AC_SRC_ALPHA,
                };

                // レイヤードウィンドウを更新
                Size = new Size(srcBitmap.Width, srcBitmap.Height);
                var pptDst = new Point(this.Left, this.Top);
                var psize = new Size(this.Width, this.Height);
                var pptSrc = new Point(0, 0);

                // 更新
                Win32API.UpdateLayeredWindow(this.Handle, screenDc, ref pptDst, ref psize, memDc, ref pptSrc, 0, ref blend, Win32API.ULW_ALPHA);
            }
            finally
            {
                if (screenDc != IntPtr.Zero)
                {
                    Win32API.ReleaseDC(IntPtr.Zero, screenDc);
                }
                if (hBitmap != IntPtr.Zero)
                {
                    Win32API.SelectObject(memDc, hOldBitmap);
                    Win32API.DeleteObject(hBitmap);
                }
                if (memDc != IntPtr.Zero)
                {
                    Win32API.DeleteDC(memDc);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_LAYERED = 0x00080000;
                const int WS_BORDER = 0x00800000;
                const int WS_DLGFRAME = 0x00400000;
                const int WS_THICKFRAME = 0x00040000;
                const int CS_DROPSHADOW = 0x00020000;

                var cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_LAYERED;
                if (this.FormBorderStyle != FormBorderStyle.None)
                {
                    cp.Style = cp.Style & (~WS_BORDER);
                    cp.Style = cp.Style & (~WS_DLGFRAME);
                    cp.Style = cp.Style & (~WS_THICKFRAME);
                    cp.ClassStyle = cp.ClassStyle & (~CS_DROPSHADOW);
                }

                return cp;
            }
        }
    }
}
