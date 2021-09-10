using LiveSplit.Model;
using LiveSplit.Model.Comparisons;
using LiveSplit.TimeFormatters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace LiveSplit.UI.Components
{
    public class DualTimer : IComponent
    {
        public Timer InternalComponent { get; set; }
        public AlternateTimer AlternateTimer { get; set; }

        public DualTimerSettings Settings { get; set; }
        public GraphicsCache Cache { get; set; }

        public float PaddingTop => 0f;
        public float PaddingLeft => 7f;
        public float PaddingBottom => 0f;
        public float PaddingRight => 7f;

        public float VerticalHeight => Settings.Height;

        public float HorizontalWidth => Settings.Width;

        public float MinimumWidth => 20;

        public float MinimumHeight => 20;

        public IDictionary<string, Action> ContextMenuControls => null;

        public DualTimer(LiveSplitState state)
        {
            InternalComponent = new Timer();
            AlternateTimer = new AlternateTimer();
            Settings = new DualTimerSettings()
            {
                CurrentState = state
            };
            Cache = new GraphicsCache();
        }

        public void DrawGeneral(Graphics g, LiveSplitState state, float width, float height)
        {
            Timer.DrawBackground(g, InternalComponent.TimerColor, Settings.BackgroundColor, Settings.BackgroundColor2, width, height, Settings.BackgroundGradient);

            InternalComponent.Settings.ShowGradient = Settings.TimerShowGradient;
            InternalComponent.Settings.OverrideSplitColors = Settings.OverrideTimerColors;
            InternalComponent.Settings.TimerColor = Settings.TimerColor;
            InternalComponent.Settings.DigitsFormat = Settings.DigitsFormat;
            InternalComponent.Settings.Accuracy = Settings.Accuracy;
            InternalComponent.Settings.DecimalsSize = Settings.DecimalsSize;
            AlternateTimer.Settings.ShowGradient = Settings.AlternateTimerShowGradient;
            AlternateTimer.Settings.OverrideSplitColors = true;
            AlternateTimer.Settings.TimerColor = Settings.AlternateTimerColor;
            AlternateTimer.Settings.DigitsFormat = Settings.AlternateDigitsFormat;
            AlternateTimer.Settings.Accuracy = Settings.AlternateAccuracy;
            AlternateTimer.Settings.DecimalsSize = Settings.AlternateTimerDecimalsSize;
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            DrawGeneral(g, state, width, VerticalHeight);
            var oldMatrix = g.Transform;
            InternalComponent.Settings.TimerHeight = (VerticalHeight - 7f) * ((100f - Settings.AlternateTimerSizeRatio) / 100f);
            InternalComponent.DrawVertical(g, state, width, clipRegion);
            g.Transform = oldMatrix;
            g.TranslateTransform(0, (VerticalHeight - 7f) * ((100f - Settings.AlternateTimerSizeRatio) / 100f));
            AlternateTimer.Settings.TimerHeight = VerticalHeight * (Settings.AlternateTimerSizeRatio / 100f);
            AlternateTimer.DrawVertical(g, state, width, clipRegion);
            g.Transform = oldMatrix;
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawGeneral(g, state, HorizontalWidth, height);
            var oldMatrix = g.Transform;
            InternalComponent.Settings.TimerWidth = HorizontalWidth;
            InternalComponent.DrawHorizontal(g, state, height * ((100f - Settings.AlternateTimerSizeRatio) / 100f), clipRegion);
            g.Transform = oldMatrix;
            g.TranslateTransform(0, height * ((100f - Settings.AlternateTimerSizeRatio) / 100f));
            AlternateTimer.DrawHorizontal(g, state, height * (Settings.AlternateTimerSizeRatio / 100f), clipRegion);
            AlternateTimer.Settings.TimerWidth = HorizontalWidth;
            g.Transform = oldMatrix;
        }

        public string ComponentName => "Dual Timer";

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            var timingMethod = state.CurrentTimingMethod;
            if (Settings.TimingMethod == "Real Time")
                timingMethod = TimingMethod.RealTime;
            else if (Settings.TimingMethod == "Game Time")
                timingMethod = TimingMethod.GameTime;

            var formatter = new AlternateTimeFormatter(Settings.AlternateTimeAccuracy);

            TimeSpan? altTime = null;
            if (AlternateTimer != null)
                altTime = AlternateTimer.GetTime(state, timingMethod);

            AlternateTimer.Settings.TimingMethod = Settings.TimingMethod;
            InternalComponent.Settings.TimingMethod = Settings.TimingMethod;
            AlternateTimer.Update(null, state, width, height, mode);
            InternalComponent.Update(null, state, width, height, mode);

            Cache.Restart();
            Cache["AlternateTimerText"] = AlternateTimer.BigTextLabel.Text + AlternateTimer.SmallTextLabel.Text;
            Cache["InternalComponentText"] = InternalComponent.BigTextLabel.Text + InternalComponent.SmallTextLabel.Text;
            if (InternalComponent.BigTextLabel.Brush != null && invalidator != null)
            {
                if (InternalComponent.BigTextLabel.Brush is LinearGradientBrush)
                    Cache["TimerColor"] = ((LinearGradientBrush)InternalComponent.BigTextLabel.Brush).LinearColors.First().ToArgb();
                else
                    Cache["TimerColor"] = InternalComponent.BigTextLabel.ForeColor.ToArgb();
            }

            if (invalidator != null && (Cache.HasChanged)) //|| FrameCount > 1))
            {
                invalidator.Invalidate(0, 0, width, height);
            }
        }

        public void Dispose()
        {
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
    }
}
