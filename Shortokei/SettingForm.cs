using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shortokei
{
    public partial class SettingForm : Form
    {
        private Setting setting = Setting.GetInstance();

        // ガジェットサイズ変更監視タイマー
        private Timer changeTimer = new Timer();
        private int counter = 0;
        private bool sizeChange = false;

        public SettingForm()
        {
            InitializeComponent();

            // Initialize
            Initialize();
        }

        private void Initialize()
        {
            // 設定読み込み
            setting.ValueChanged += Setting_ValueChanged;
            setting.ValueChange();

            // 変更タイマー
            changeTimer.Interval = 100;
            changeTimer.Tick += ChangeTimer_Tick;
            changeTimer.Start();
        }

        private void ChangeTimer_Tick(object sender, EventArgs e)
        {
            if (sizeChange)
            {
                if (counter >= 500)
                {
                    sizeChange = false;
                    setting.ValueChange();
                }

                counter += 100;
            }
        }

        private void Setting_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown_Width.Value = setting.Gadget_Width;
            NumericUpDown_Height.Value = setting.Gadget_Height;

            Panel_BackgroundColor1.BackColor = setting.BackgroundColor1.ToRgb();
            Panel_BackgroundColor2.BackColor = setting.BackgroundColor2.ToRgb();

            Panel_TimeBackgroundColor1.BackColor = setting.TimeBackgroundColor1.ToRgb();
            Panel_TimeBackgroundColor2.BackColor = setting.TimeBackgroundColor2.ToRgb();

            Panel_GraphColor1_1.BackColor = setting.GraphColor1_1.ToRgb();
            Panel_GraphColor1_2.BackColor = setting.GraphColor1_2.ToRgb();

            Panel_GraphColor2_1.BackColor = setting.GraphColor2_1.ToRgb();
            Panel_GraphColor2_2.BackColor = setting.GraphColor2_2.ToRgb();

            NumericUpDown_BackgroundColor1.Value = setting.BackgroundColor1.A;
            NumericUpDown_BackgroundColor2.Value = setting.BackgroundColor2.A;
            NumericUpDown_TimeBackgroundColor1.Value = setting.TimeBackgroundColor1.A;
            NumericUpDown_TimeBackgroundColor2.Value = setting.TimeBackgroundColor2.A;
            NumericUpDown_GraphColor1_1.Value = setting.GraphColor1_1.A;
            NumericUpDown_GraphColor1_2.Value = setting.GraphColor1_2.A;
            NumericUpDown_GraphColor2_1.Value = setting.GraphColor2_1.A;
            NumericUpDown_GraphColor2_2.Value = setting.GraphColor2_2.A;

            Panel_TimeStringColor.BackColor = setting.TimeStringColor.ToRgb();
            Panel_TimeEndStringColor.BackColor = setting.TimeEndStringColor.ToRgb();
            Panel_TimeDescriptionStringColor.BackColor = setting.TimeDescriptionStringColor.ToRgb();
            Panel_EndStringColor.BackColor = setting.EndStringColor.ToRgb();

            CheckBox_Division.Checked = setting.Division;
            CheckBox_WindowSnap.Checked = setting.Gadget_WindowSnap;
            CheckBox_TimeLock.Checked = setting.TimeLock;
            CheckBox_Antialias.Checked = setting.Antialias;

            Label_EndStringFontValue.Text = $"{setting.EndStringFont.FontFamily.Name}, {setting.EndStringFont.Size}pt";
            ToolTip_Description.SetToolTip(Label_EndStringFontValue, $"{setting.EndStringFont.FontFamily.Name}, {setting.EndStringFont.Size}pt");
            Label_TimeDescriptionFontValue.Text = $"{setting.TimeDescriptionFont.FontFamily.Name}, {setting.TimeDescriptionFont.Size}pt";
            ToolTip_Description.SetToolTip(Label_TimeDescriptionFontValue, $"{setting.TimeDescriptionFont.FontFamily.Name}, {setting.TimeDescriptionFont.Size}pt");
            Label_TimeStringFontValue.Text = $"{setting.TimeStringFont.FontFamily.Name}, {setting.TimeStringFont.Size}pt";
            ToolTip_Description.SetToolTip(Label_TimeStringFontValue, $"{setting.TimeStringFont.FontFamily.Name}, {setting.TimeStringFont.Size}pt");

            NumericUpDown_Time_1.Value = setting.SelectTime1;
            NumericUpDown_Time_2.Value = setting.SelectTime2;
        }

        private void Panel_Color_Click(object sender, EventArgs e)
        {
            using (var cd = new ColorDialog())
            {
                var panel = (Panel)sender;

                // 背景色の適応
                cd.Color = panel.BackColor;

                // ダイアログ
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    if (panel.Name == "Panel_BackgroundColor1")
                    {
                        setting.BackgroundColor1
                            = Color.FromArgb(setting.BackgroundColor1.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_BackgroundColor2")
                    {
                        setting.BackgroundColor2
                           = Color.FromArgb(setting.BackgroundColor2.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_TimeBackgroundColor1")
                    {
                        setting.TimeBackgroundColor1
                            = Color.FromArgb(setting.TimeBackgroundColor1.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_TimeBackgroundColor2")
                    {
                        setting.TimeBackgroundColor2
                            = Color.FromArgb(setting.TimeBackgroundColor2.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_GraphColor1_1")
                    {
                        setting.GraphColor1_1
                            = Color.FromArgb(setting.GraphColor1_1.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_GraphColor1_2")
                    {
                        setting.GraphColor1_2
                            = Color.FromArgb(setting.GraphColor1_2.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_GraphColor2_1")
                    {
                        setting.GraphColor2_1
                            = Color.FromArgb(setting.GraphColor2_1.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_GraphColor2_2")
                    {
                        setting.GraphColor2_2
                            = Color.FromArgb(setting.GraphColor2_2.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_TimeStringColor")
                    {
                        setting.TimeStringColor
                            = Color.FromArgb(setting.TimeStringColor.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_TimeEndStringColor")
                    {
                        setting.TimeEndStringColor
                            = Color.FromArgb(setting.TimeEndStringColor.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_TimeDescriptionStringColor")
                    {
                        setting.TimeDescriptionStringColor
                            = Color.FromArgb(setting.TimeDescriptionStringColor.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }
                    else if (panel.Name == "Panel_EndStringColor")
                    {
                        setting.EndStringColor
                            = Color.FromArgb(setting.EndStringColor.A, cd.Color.R, cd.Color.G, cd.Color.B);
                    }

                    // 更新
                    setting.ValueChange();
                }
            }
        }

        private void NumericUpDown_Color_ValueChanged(object sender, EventArgs e)
        {
            var numeric = (NumericUpDown)sender;

            if (numeric.Name == "NumericUpDown_BackgroundColor1")
            {
                setting.BackgroundColor1
                    = Color.FromArgb(
                    (int)NumericUpDown_BackgroundColor1.Value,
                    setting.BackgroundColor1.R,
                    setting.BackgroundColor1.G,
                    setting.BackgroundColor1.B);
            }
            else if (numeric.Name == "NumericUpDown_BackgroundColor2")
            {
                setting.BackgroundColor2
                    = Color.FromArgb(
                    (int)NumericUpDown_BackgroundColor2.Value,
                    setting.BackgroundColor2.R,
                    setting.BackgroundColor2.G,
                    setting.BackgroundColor2.B);
            }
            else if (numeric.Name == "NumericUpDown_TimeBackgroundColor1")
            {
                setting.TimeBackgroundColor1
                   = Color.FromArgb(
                   (int)NumericUpDown_TimeBackgroundColor1.Value,
                   setting.TimeBackgroundColor1.R,
                   setting.TimeBackgroundColor1.G,
                   setting.TimeBackgroundColor1.B);
            }
            else if (numeric.Name == "NumericUpDown_TimeBackgroundColor2")
            {
                setting.TimeBackgroundColor2
                  = Color.FromArgb(
                   (int)NumericUpDown_TimeBackgroundColor2.Value,
                   setting.TimeBackgroundColor2.R,
                   setting.TimeBackgroundColor2.G,
                   setting.TimeBackgroundColor2.B);
            }
            else if (numeric.Name == "NumericUpDown_GraphColor1_1")
            {
                setting.GraphColor1_1
                    = Color.FromArgb(
                 (int)NumericUpDown_GraphColor1_1.Value,
                  setting.GraphColor1_1.R,
                  setting.GraphColor1_1.G,
                  setting.GraphColor1_1.B);
            }
            else if (numeric.Name == "NumericUpDown_GraphColor1_2")
            {
                setting.GraphColor1_2
                  = Color.FromArgb(
                  (int)NumericUpDown_GraphColor1_2.Value,
                  setting.GraphColor1_2.R,
                  setting.GraphColor1_2.G,
                  setting.GraphColor1_2.B);
            }
            else if (numeric.Name == "NumericUpDown_GraphColor2_1")
            {
                setting.GraphColor2_1
                   = Color.FromArgb(
                   (int)NumericUpDown_GraphColor2_1.Value,
                   setting.GraphColor2_1.R,
                   setting.GraphColor2_1.G,
                   setting.GraphColor2_1.B);
            }
            else if (numeric.Name == "NumericUpDown_GraphColor2_2")
            {
                setting.GraphColor2_2
                  = Color.FromArgb(
                   (int)NumericUpDown_GraphColor2_2.Value,
                   setting.GraphColor2_2.R,
                   setting.GraphColor2_2.G,
                   setting.GraphColor2_2.B);
            }
            else if (numeric.Name == "NumericUpDown_Time_1")
            {
                setting.SelectTime1 =
                 (int)NumericUpDown_Time_1.Value;
            }
            else if (numeric.Name == "NumericUpDown_Time_2")
            {
                setting.SelectTime2 =
                 (int)NumericUpDown_Time_2.Value;
            }

            // 更新
            setting.ValueChange();
        }

        private void Button_Default_Click(object sender, EventArgs e)
        {
            setting.DefaultValue();
        }

        private void Label_Font_Click(object sender, EventArgs e)
        {
            using (var cd = new FontDialog())
            {
                var label = (Label)sender;

                if (label.Name == "Label_TimeStringFontValue")
                {
                    cd.Font = setting.TimeStringFont;
                }
                else if (label.Name == "Label_TimeDescriptionFontValue")
                {
                    cd.Font = setting.TimeDescriptionFont;
                }
                else if (label.Name == "Label_EndStringFontValue")
                {
                    cd.Font = setting.EndStringFont;
                }

                // ダイアログ
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    if (label.Name == "Label_TimeStringFontValue")
                    {
                        setting.TimeStringFont = cd.Font;
                    }
                    else if (label.Name == "Label_TimeDescriptionFontValue")
                    {
                        setting.TimeDescriptionFont = cd.Font;
                    }
                    else if (label.Name == "Label_EndStringFontValue")
                    {
                        setting.EndStringFont = cd.Font;
                    }
                }

                // 更新
                setting.ValueChange();
            }
        }

        private void NumericUpDown_Size_ValueChanged(object sender, EventArgs e)
        {
            setting.Gadget_Height =
                (int)NumericUpDown_Height.Value;
            setting.Gadget_Width =
                (int)NumericUpDown_Width.Value;

            counter = 0;
            sizeChange = true;
        }

        private void CheckBox_TimeLock_CheckedChanged(object sender, EventArgs e)
        {
            // 時刻に合わせる
            setting.TimeLock = CheckBox_TimeLock.Checked;

            // 更新
            setting.ValueChange();
        }

        private void CheckBox_Division_CheckedChanged(object sender, EventArgs e)
        {
            // 目盛りを付ける
            setting.Division = CheckBox_Division.Checked;

            // 更新
            setting.ValueChange();
        }

        private void CheckBox_WindowSnap_CheckedChanged(object sender, EventArgs e)
        {
            // ウィンドウスナップ
            setting.Gadget_WindowSnap = CheckBox_WindowSnap.Checked;

            // 更新
            setting.ValueChange();
        }

        private void CheckBox_Finished_CheckedChanged(object sender, EventArgs e)
        {
            // 目盛りを付ける
            setting.Finished = CheckBox_Finished.Checked;

            // 更新
            setting.ValueChange();
        }
        
        private void CheckBox_Antialias_CheckedChanged(object sender, EventArgs e)
        {
            // アンチエイリアス
            setting.Antialias = CheckBox_Antialias.Checked;

            // 更新
            setting.ValueChange();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
