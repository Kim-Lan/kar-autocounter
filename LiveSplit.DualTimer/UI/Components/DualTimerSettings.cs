using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class DualTimerSettings : UserControl
    {
        public float Height { get; set; }
        public float Width { get; set; }
        public float AlternateTimerSizeRatio { get; set; }

        public LiveSplitState CurrentState { get; set; }

        public bool TimerShowGradient { get; set; }
        public bool OverrideTimerColors { get; set; }
        public bool AlternateTimerShowGradient { get; set; }

        public float DecimalsSize { get; set; }
        public float AlternateTimerDecimalsSize { get; set; }

        public Color TimerColor { get; set; }
        public Color AlternateTimerColor { get; set; }
        public Color AlternateLabelColor { get; set; }
        public Color AlternateTimeColor { get; set; }

        public Color BackgroundColor { get; set; }
        public Color BackgroundColor2 { get; set; }

        public DeltasGradientType BackgroundGradient { get; set; }
        public string GradientString
        {
            get { return TimerSettings.GetBackgroundTypeString(BackgroundGradient); }
            set { BackgroundGradient = (DeltasGradientType)Enum.Parse(typeof(DeltasGradientType), value.Replace(" ", "")); }
        }

        private string timerFormat
        {
            get
            {
                return DigitsFormat + Accuracy;
            }
            set
            {
                var decimalIndex = value.IndexOf('.');
                if (decimalIndex < 0)
                {
                    DigitsFormat = value;
                    Accuracy = "";
                }
                else
                {
                    DigitsFormat = value.Substring(0, decimalIndex);
                    Accuracy = value.Substring(decimalIndex);
                }
            }
        }
        public string DigitsFormat { get; set; }
        public string Accuracy { get; set; }
        private string AlternateTimerFormat
        {
            get
            {
                return AlternateDigitsFormat + AlternateAccuracy;
            }
            set
            {
                var decimalIndex = value.IndexOf('.');
                if (decimalIndex < 0)
                {
                    AlternateDigitsFormat = value;
                    AlternateAccuracy = "";
                }
                else
                {
                    AlternateDigitsFormat = value.Substring(0, decimalIndex);
                    AlternateAccuracy = value.Substring(decimalIndex);
                }
            }
        }
        public string AlternateDigitsFormat { get; set; }
        public string AlternateAccuracy { get; set; }
        public TimeAccuracy AlternateTimeAccuracy { get; set; }

        public string TimingMethod { get; set; }

        public LayoutMode Mode { get; set; }

        public DualTimerSettings()
        {
            InitializeComponent();

            Height = 75;
            Width = 200;
            AlternateTimerSizeRatio = 40;

            TimerShowGradient = true;
            OverrideTimerColors = false;
            AlternateTimerShowGradient = true;

            TimerColor = Color.FromArgb(170, 170, 170);
            AlternateTimerColor = Color.FromArgb(170, 170, 170);
            AlternateLabelColor = Color.FromArgb(255, 255, 255);
            AlternateTimeColor = Color.FromArgb(255, 255, 255);

            DigitsFormat = "1";
            Accuracy = ".23";
            AlternateDigitsFormat = "1";
            AlternateAccuracy = ".23";
            AlternateTimeAccuracy = TimeAccuracy.Hundredths;

            BackgroundColor = Color.Transparent;
            BackgroundColor2 = Color.Transparent;
            BackgroundGradient = DeltasGradientType.Plain;

            DecimalsSize = 35f;
            AlternateTimerDecimalsSize = 35f;

            TimingMethod = "Current Timing Method";

            chkShowGradientAlternateTimer.DataBindings.Add("Checked", this, "AlternateTimerShowGradient", false, DataSourceUpdateMode.OnPropertyChanged);
            chkShowGradientTimer.DataBindings.Add("Checked", this, "TimerShowGradient", false, DataSourceUpdateMode.OnPropertyChanged);
            chkOverrideTimerColors.DataBindings.Add("Checked", this, "OverrideTimerColors", false, DataSourceUpdateMode.OnPropertyChanged);
            btnTimerColor.DataBindings.Add("BackColor", this, "TimerColor", false, DataSourceUpdateMode.OnPropertyChanged);
            btnAlternateTimerColor.DataBindings.Add("BackColor", this, "AlternateTimerColor", false, DataSourceUpdateMode.OnPropertyChanged);
            trkAlternateTimerRatio.DataBindings.Add("Value", this, "AlternateTimerSizeRatio", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbGradientType.DataBindings.Add("SelectedItem", this, "GradientString", false, DataSourceUpdateMode.OnPropertyChanged);
            btnColor1.DataBindings.Add("BackColor", this, "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            btnColor2.DataBindings.Add("BackColor", this, "BackgroundColor2", false, DataSourceUpdateMode.OnPropertyChanged);
            trkDecimalsSize.DataBindings.Add("Value", this, "DecimalsSize", false, DataSourceUpdateMode.OnPropertyChanged);
            trkAlternateDecimalsSize.DataBindings.Add("Value", this, "AlternateTimerDecimalsSize", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbDigitsFormat.DataBindings.Add("SelectedItem", this, "DigitsFormat", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbAccuracy.DataBindings.Add("SelectedItem", this, "Accuracy", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbAlternateDigitsFormat.DataBindings.Add("SelectedItem", this, "AlternateDigitsFormat", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbAlternateAccuracy.DataBindings.Add("SelectedItem", this, "AlternateAccuracy", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbTimingMethod.DataBindings.Add("SelectedItem", this, "TimingMethod", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        void cmbTimingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimingMethod = cmbTimingMethod.SelectedItem.ToString();
        }

        void cmbAlternateDigitsFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlternateDigitsFormat = cmbAlternateDigitsFormat.SelectedItem.ToString();
        }

        void cmbAlternateAccuracy_SelectedIndexChanged(object sender, EventArgs e)
        {
            AlternateAccuracy = cmbAlternateAccuracy.SelectedItem.ToString();
        }

        void cmbDigitsFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DigitsFormat = cmbDigitsFormat.SelectedItem.ToString();
        }

        void cmbAccuracy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Accuracy = cmbAccuracy.SelectedItem.ToString();
        }

        void chkOverrideTimerColors_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = btnTimerColor.Enabled = chkOverrideTimerColors.Checked;
        }

        void cmbGradientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedText = cmbGradientType.SelectedItem.ToString();
            btnColor1.Visible = selectedText != "Plain" && !selectedText.Contains("Delta");
            btnColor2.Visible = !selectedText.Contains("Delta");
            btnColor2.DataBindings.Clear();
            btnColor2.DataBindings.Add("BackColor", this, btnColor1.Visible ? "BackgroundColor2" : "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            GradientString = cmbGradientType.SelectedItem.ToString();
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            Version version = SettingsHelper.ParseVersion(element["Version"]);

            Height = SettingsHelper.ParseFloat(element["Height"]);
            Width = SettingsHelper.ParseFloat(element["Width"]);
            AlternateTimerSizeRatio = SettingsHelper.ParseFloat(element["AlternateTimerSizeRatio"]);
            TimerShowGradient = SettingsHelper.ParseBool(element["TimerShowGradient"]);
            AlternateTimerShowGradient = SettingsHelper.ParseBool(element["AlternateTimerShowGradient"]);
            TimerColor = SettingsHelper.ParseColor(element["TimerColor"]);
            AlternateTimerColor = SettingsHelper.ParseColor(element["AlternateTimerColor"]);
            AlternateLabelColor = SettingsHelper.ParseColor(element["AlternateLabelColor"]);
            AlternateTimeColor = SettingsHelper.ParseColor(element["AlternateTimeColor"]);
            TimingMethod = SettingsHelper.ParseString(element["TimingMethod"], "Current Timing Method");
            DecimalsSize = SettingsHelper.ParseFloat(element["DecimalsSize"], 35f);
            AlternateTimerDecimalsSize = SettingsHelper.ParseFloat(element["AlternateTimerDecimalsSize"], 35f);
            BackgroundColor = SettingsHelper.ParseColor(element["BackgroundColor"], Color.Transparent);
            BackgroundColor2 = SettingsHelper.ParseColor(element["BackgroundColor2"], Color.Transparent);
            GradientString = SettingsHelper.ParseString(element["BackgroundGradient"], DeltasGradientType.Plain.ToString());

            AlternateTimeAccuracy = SettingsHelper.ParseEnum<TimeAccuracy>(element["AlternateTimeAccuracy"]);
            OverrideTimerColors = SettingsHelper.ParseBool(element["OverrideTimerColors"]);
            timerFormat = element["TimerFormat"].InnerText;
            AlternateTimerFormat = element["AlternateTimerFormat"].InnerText;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
            SettingsHelper.CreateSetting(document, parent, "Height", Height) ^
            SettingsHelper.CreateSetting(document, parent, "Width", Width) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimerSizeRatio", AlternateTimerSizeRatio) ^
            SettingsHelper.CreateSetting(document, parent, "TimerShowGradient", TimerShowGradient) ^
            SettingsHelper.CreateSetting(document, parent, "OverrideTimerColors", OverrideTimerColors) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimerShowGradient", AlternateTimerShowGradient) ^
            SettingsHelper.CreateSetting(document, parent, "TimerFormat", timerFormat) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimerFormat", AlternateTimerFormat) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimeAccuracy", AlternateTimeAccuracy) ^
            SettingsHelper.CreateSetting(document, parent, "TimerColor", TimerColor) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimerColor", AlternateTimerColor) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateLabelColor", AlternateLabelColor) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimeColor", AlternateTimeColor) ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundColor", BackgroundColor) ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundColor2", BackgroundColor2) ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundGradient", BackgroundGradient) ^
            SettingsHelper.CreateSetting(document, parent, "TimingMethod", TimingMethod) ^
            SettingsHelper.CreateSetting(document, parent, "DecimalsSize", DecimalsSize) ^
            SettingsHelper.CreateSetting(document, parent, "AlternateTimerDecimalsSize", AlternateTimerDecimalsSize);
        }

        private void ColorButtonClick(object sender, EventArgs e)
        {
            SettingsHelper.ColorButtonClick((Button)sender, this);
        }

        void DualTimerSettings_Load(object sender, EventArgs e)
        {
            chkOverrideTimerColors_CheckedChanged(null, null);

            if (Mode == LayoutMode.Horizontal)
            {
                trkSize.DataBindings.Clear();
                trkSize.Minimum = 50;
                trkSize.Maximum = 500;
                trkSize.DataBindings.Add("Value", this, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
                lblSize.Text = "Width:";
            }
            else
            {
                trkSize.DataBindings.Clear();
                trkSize.Minimum = 20;
                trkSize.Maximum = 150;
                trkSize.DataBindings.Add("Value", this, "Height", false, DataSourceUpdateMode.OnPropertyChanged);
                lblSize.Text = "Height:";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
