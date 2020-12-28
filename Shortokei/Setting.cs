using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Shortokei
{
    public class Setting : Serializer<Setting>
    {
        #region Singleton

        /// <summary>
        /// インスタンス
        /// </summary>
        private static Setting instance;

        /// <summary>
        /// インスタンスを取得します。
        /// </summary>
        /// <returns></returns>
        public static Setting GetInstance() => instance ?? (instance = new Setting());

        #endregion

        // FontConverter
        private static FontConverter fontConverter = new FontConverter();

        public event EventHandler ValueChanged;

        public int Gadget_Width { get; set; } = 400;
        public int Gadget_Height { get; set; } = 30;
        public int Gadget_X { get; set; }
        public int Gadget_Y { get; set; }

        public bool Gadget_MoveLock { get; set; } = false;

        public bool Gadget_WindowSnap { get; set; } = false;
        public bool Gadget_TopMost { get; set; } = false;
        public bool Gadget_Selection_TopMost { get; set; } = false;
        public int SelectTime1 { get; set; } = 1800;
        public int SelectTime2 { get; set; } = 60;
        public bool TimeLock { get; set; } = false;

        public bool Antialias { get; set; } = true;

        public ColorEx BackgroundColor1 { get; set; } = Color.FromArgb(200, 255, 255, 255);
        public ColorEx BackgroundColor2 { get; set; } = Color.FromArgb(20, 245, 245, 245);

        public ColorEx TimeBackgroundColor1 { get; set; } = Color.FromArgb(200, 255, 255, 255);
        public ColorEx TimeBackgroundColor2 { get; set; } = Color.FromArgb(200, 255, 255, 255);

        public ColorEx GraphColor1_1 { get; set; } = Color.FromArgb(128, 127, 191, 255);
        public ColorEx GraphColor1_2 { get; set; } = Color.FromArgb(128, 107, 171, 235);

        public ColorEx GraphColor2_1 { get; set; } = Color.FromArgb(128, 255, 127, 191);
        public ColorEx GraphColor2_2 { get; set; } = Color.FromArgb(128, 235, 107, 171);

        public ColorEx TimeStringColor { get; set; } = Color.Black;
        public ColorEx TimeEndStringColor { get; set; } = Color.DarkGray;
        public ColorEx TimeDescriptionStringColor { get; set; } = Color.Black;
        public ColorEx EndStringColor { get; set; } = Color.DarkBlue;

        public bool Division { get; set; } = false;

        public bool Finished { get; set; } = false;

        public string TimeString
        { get => fontConverter.ConvertToString(TimeStringFont); set => TimeStringFont = (Font)fontConverter.ConvertFromString(value); }

        public string TimeDescription
        { get => fontConverter.ConvertToString(TimeDescriptionFont); set => TimeDescriptionFont = (Font)fontConverter.ConvertFromString(value); }

        public string EndString
        { get => fontConverter.ConvertToString(EndStringFont); set => EndStringFont = (Font)fontConverter.ConvertFromString(value); }

        [XmlIgnore]
        public Font TimeStringFont { get; set; } = new Font("MS UI Gothic", 8);

        [XmlIgnore]
        public Font TimeDescriptionFont { get; set; } = new Font("MS UI Gothic", 8);

        [XmlIgnore]
        public Font EndStringFont { get; set; } = new Font("MS UI Gothic", 10);

        public void ValueChange() => ValueChanged?.Invoke(this, EventArgs.Empty);

        public void DefaultValue()
        {
            Gadget_Width = 400;
            Gadget_Height = 30;
            Gadget_MoveLock = false;
            Gadget_WindowSnap = false;
            Gadget_TopMost = false;
            Gadget_Selection_TopMost = false;
            SelectTime1 = 1800;
            SelectTime2 = 60;
            TimeLock = false;
            BackgroundColor1 = Color.FromArgb(200, 255, 255, 255);
            BackgroundColor2 = Color.FromArgb(20, 245, 245, 245);
            TimeBackgroundColor1 = Color.FromArgb(200, 255, 255, 255);
            TimeBackgroundColor2 = Color.FromArgb(200, 255, 255, 255);
            GraphColor1_1 = Color.FromArgb(128, 127, 191, 255);
            GraphColor1_2 = Color.FromArgb(128, 107, 171, 235);
            GraphColor2_1 = Color.FromArgb(128, 255, 127, 191);
            GraphColor2_2 = Color.FromArgb(128, 235, 107, 171);
            TimeStringColor = Color.Black;
            TimeEndStringColor = Color.DarkGray;
            TimeDescriptionStringColor = Color.Black;
            EndStringColor = Color.DarkBlue;
            Division = false;
            TimeStringFont = new Font("MS UI Gothic", 8);
            TimeDescriptionFont = new Font("MS UI Gothic", 8);
            EndStringFont = new Font("MS UI Gothic", 10);

            // 変更通知
            ValueChange();
        }
    }
}

