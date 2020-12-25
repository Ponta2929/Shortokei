using System.Drawing;
using System.Drawing.Drawing2D;


namespace Shortokei
{
    /// <summary>
    /// System.Drawing.Graphicsクラスを拡張します。
    /// </summary>
    internal static class GraphicsExtensions
    {
        /// <summary>
        /// 丸角線を描画します。
        /// </summary>
        public static void DrawCurveRectangle(this Graphics g, Pen p, Rectangle rect, int curve)
        {
            // 変形作成
            using (var gp = new GraphicsPath())
            {
                // パスの追加
                gp.StartFigure();
                gp.AddArc(rect.Right - curve, rect.Top, curve, curve, 270, 90); // 右上
                gp.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90); // 右上
                gp.AddArc(rect.Left, rect.Bottom - curve, curve, curve, 90, 90); // 右上
                gp.AddArc(rect.Left, rect.Top, curve, curve, 180, 90); // 右上
                gp.CloseFigure();

                // 描画
                g.DrawPath(p, gp);
            }
        }

        /// <summary>
        /// 丸角線を描画します。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        public static void FillCurveRectangle(this Graphics g, Brush b, Rectangle rect, int curve)
        {
            // 変形作成
            using (var gp = new GraphicsPath())
            {
                // パスの追加
                gp.StartFigure();
                gp.AddArc(rect.Right - curve, rect.Top, curve, curve, 270, 90); // 右上
                gp.AddArc(rect.Right - curve, rect.Bottom - curve, curve, curve, 0, 90); // 右上
                gp.AddArc(rect.Left, rect.Bottom - curve, curve, curve, 90, 90); // 右上
                gp.AddArc(rect.Left, rect.Top, curve, curve, 180, 90); // 右上
                gp.CloseFigure();

                // 描画
                g.FillPath(b, gp);
            }
        }
    }
}
