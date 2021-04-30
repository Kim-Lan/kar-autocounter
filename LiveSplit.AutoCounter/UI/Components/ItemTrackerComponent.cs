using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public class ItemTrackerComponent : IComponent
    {
        public ItemTracker Item { get; set; }

        protected SimpleLabel NameLabel { get; set; }
        protected SimpleLabel CountLabel { get; set; }
        protected SimpleLabel GoalLabel { get; set; }
        protected Font NameFont { get; set; }
        protected Font CountFont { get; set; }
        protected Font GoalFont { get; set; }

        public AutoCounterComponentSettings Settings { get; set; }

        public GraphicsCache Cache { get; set; }

        public bool ShowGoal { get; set; }
        public bool DisplayIcon { get; set; }
        protected int IconWidth => DisplayIcon ? (int)(Settings.IconSize + 7.5f) : 0;

        public float PaddingTop { get; set; }
        public float PaddingLeft => 7f;
        public float PaddingBottom { get; set; }
        public float PaddingRight => 7f;

        public IList<SimpleLabel> LabelsList { get; set; }

        public float VerticalHeight { get; set; }
        public float HorizontalWidth { get; set; }
        public float MinimumWidth => 20;
        public float MinimumHeight => 25;

        protected LiveSplitState CurrentState { get; set; }

        public string ComponentName => "ItemTracker";

        public IDictionary<string, Action> ContextMenuControls => null;

        public ItemTrackerComponent(LiveSplitState state, AutoCounterComponentSettings settings, ItemTracker item)
        {
            CurrentState = state;
            Settings = settings;
            Item = item;
            Cache = new GraphicsCache();

            NameLabel = new SimpleLabel()
            {
                HorizontalAlignment = StringAlignment.Near
            };
            CountLabel = new SimpleLabel()
            {
                HorizontalAlignment = StringAlignment.Far
            };
            GoalLabel = new SimpleLabel()
            {
                HorizontalAlignment = StringAlignment.Far
            };
            LabelsList = new List<SimpleLabel>() { CountLabel , GoalLabel };

            VerticalHeight = 31;

            DisplayIcon = Settings.DisplayIcons;
            ShowGoal = Settings.ShowGoal;
        }

        private void DrawGeneral(Graphics g, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            UpdateAll(state);
            g.FillRectangle(new SolidBrush(Settings.BackgroundColor), 0, 0, width, height);

            if (Item != null)
            {
                if (mode == LayoutMode.Vertical)
                {
                    NameLabel.VerticalAlignment = StringAlignment.Center;
                    NameLabel.Y = 0;
                    NameLabel.Height = height;

                    CountLabel.VerticalAlignment = StringAlignment.Center;
                    CountLabel.Y = 0;
                    CountLabel.Height = height;

                    GoalLabel.VerticalAlignment = StringAlignment.Far;
                    GoalLabel.Y = 0;
                    GoalLabel.Height = height;
                }
                else
                {
                    NameLabel.VerticalAlignment = StringAlignment.Near;
                    NameLabel.Y = 0;
                    NameLabel.Height = 50;
                    foreach (var label in LabelsList)
                    {
                        label.VerticalAlignment = StringAlignment.Far;
                        label.Y = height - 50;
                        label.Height = 50;
                    }
                }

                if (Item.Count >= Item.Goal)
                    g.FillRectangle(new SolidBrush(Settings.GoalColor), 0, 0, width, height);

                var icon = Item.Icon;
                if (DisplayIcon && icon != null)
                {
                    var drawWidth = Settings.IconSize;
                    var drawHeight = Settings.IconSize;
                    if (icon.Width > icon.Height)
                    {
                        var ratio = icon.Height / (float)icon.Width;
                        drawHeight *= ratio;
                    }
                    else
                    {
                        var ratio = icon.Width / (float)icon.Height;
                        drawWidth *= ratio;
                    }
                    VerticalHeight = 1.2f * drawHeight;

                    g.DrawImage(
                        icon,
                        7 + (Settings.IconSize - drawWidth) / 2,
                        (height - Settings.IconSize) / 2.0f + (Settings.IconSize - drawHeight) / 2,
                        drawWidth,
                        drawHeight);
                }

                var nameHeight = g.MeasureString("A", NameFont).Height;
                var countHeight = g.MeasureString("A", CountFont).Height;
                var goalHeight = Settings.ShowGoal ? g.MeasureString("A", GoalFont).Height : 0;
                var textHeight = Math.Max(nameHeight, Math.Max(countHeight, goalHeight));
                VerticalHeight = Math.Max(VerticalHeight, 1.2f * textHeight);

                PaddingTop = Math.Max(0, ((VerticalHeight - 0.75f * VerticalHeight) / 2f) - 5);
                PaddingBottom = PaddingTop;

                float countWidth = g.MeasureString("999", CountFont).Width;
                float goalWidth = g.MeasureString("999", GoalFont).Width;
                HorizontalWidth = (DisplayIcon ? IconWidth : 0)
                    + NameLabel.X + NameLabel.ActualWidth
                    + (countWidth > CountLabel.ActualWidth ? countWidth : CountLabel.ActualWidth)
                    + (ShowGoal ? (goalWidth > GoalLabel.ActualWidth ? goalWidth : GoalLabel.ActualWidth) : 0)
                    + 10;

                if (ShowGoal)
                {
                    var goalX = (int)width - 5;
                    goalX -= (int)goalWidth;
                    GoalLabel.Width = goalWidth + 5;
                    GoalLabel.X = width - goalWidth - 10;
                    GoalLabel.Font = GoalFont;
                    GoalLabel.ForeColor = state.LayoutSettings.TextColor;
                    GoalLabel.HasShadow = state.LayoutSettings.DropShadows;
                    GoalLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
                    GoalLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
                    GoalLabel.Draw(g);

                    var countX = goalX + goalWidth + 5 - GoalLabel.ActualWidth;
                    countX -= (int)countWidth;
                    CountLabel.Width = countWidth + 5;
                    CountLabel.X = countX - 10;

                    var nameX = countX + countWidth + 5 - CountLabel.ActualWidth;
                    NameLabel.X = 5 + IconWidth;
                    NameLabel.Width = nameX - IconWidth;
                }
                else
                {
                    NameLabel.X = IconWidth + 5;
                    NameLabel.Width = width - IconWidth - countWidth - 10;
                    CountLabel.X = width - countWidth - 10;
                    CountLabel.Width = countWidth + 5;
                }

                CountLabel.Font = CountFont;
                CountLabel.ForeColor = state.LayoutSettings.TextColor;
                CountLabel.HasShadow = state.LayoutSettings.DropShadows;
                CountLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
                CountLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
                CountLabel.Draw(g);
                
                NameLabel.Font = NameFont;
                NameLabel.ForeColor = state.LayoutSettings.TextColor;
                NameLabel.HasShadow = state.LayoutSettings.DropShadows;
                NameLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
                NameLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
                NameLabel.Draw(g);
            }
            else
            {
                DisplayIcon = Settings.DisplayIcons;
                ShowGoal = Settings.ShowGoal;
            }
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            DrawGeneral(g, state, width, VerticalHeight, LayoutMode.Vertical);
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawGeneral(g, state, HorizontalWidth, height, LayoutMode.Horizontal);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }
        public XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public int GetSettingsHashCode()
        {
            return Settings.GetSettingsHashCode();
        }

        public void SetCount(string name, int count)
        {
            if (Item.Name == name)
            {
                Item.SetCount(count);
                UpdateAll(CurrentState);
            }
        }

        public void UpdateAll(LiveSplitState state)
        {
            NameFont = Settings.OverrideFont ? Settings.NameFont : state.LayoutSettings.TextFont;
            CountFont = Settings.OverrideFont ? Settings.CountFont : state.LayoutSettings.TextFont;
            GoalFont = (ShowGoal && Settings.OverrideFont) ? Settings.GoalFont : state.LayoutSettings.TextFont;

            NameLabel.ForeColor = state.LayoutSettings.TextColor;
            CountLabel.ForeColor = state.LayoutSettings.TextColor;
            GoalLabel.ForeColor = state.LayoutSettings.TextColor;

            if (Item != null)
            {
                NameLabel.Text = Item.Name;
                CountLabel.Text = Item.Count.ToString();
                GoalLabel.Text = ShowGoal ? ("/" + Item.Goal.ToString()) : "";
            }
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            UpdateAll(state);

            if (Item != null)
            {
                Cache.Restart();
                Cache["Icon"] = Item.Icon;
                Cache["DisplayIcon"] = DisplayIcon;
                Cache["ShowGoal"] = ShowGoal;
                Cache["NameLabel"] = NameLabel.Text;
                Cache["CountLabel"] = CountLabel.Text;
                Cache["GoalLabel"] = GoalLabel.Text;
                Cache["NameFont"] = NameFont;
                Cache["CountFont"] = CountFont;
                Cache["GoalFont"] = GoalFont;
                Cache["NameColor"] = NameLabel.ForeColor.ToArgb();
                Cache["CountColor"] = CountLabel.ForeColor.ToArgb();
                Cache["GoalColor"] = GoalLabel.ForeColor.ToArgb();
                Cache["BackColor"] = Settings.BackgroundColor.ToArgb();

                if (invalidator != null && Cache.HasChanged)
                {
                    invalidator.Invalidate(0, 0, width, height);
                }
            }
        }

        public void Dispose() { }
    }
}
