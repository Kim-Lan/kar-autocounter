using LiveSplit.Model;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public class AutoCounterComponent : IComponent
    {
        protected ComponentRendererComponent InternalComponent { get; set; }
        protected IList<IComponent> Components { get; set; }
        protected IList<ItemTrackerComponent> ItemComponents { get; set; }

        public float PaddingTop => 0f;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingBottom => 0f;
        public float PaddingRight => InternalComponent.PaddingRight;

        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumWidth => InternalComponent.MinimumWidth;
        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumHeight => InternalComponent.MinimumHeight;

        public AutoCounterComponentSettings Settings { get; set; }
        
        public LiveSplitState CurrentState { get; set; }

        public string ComponentName => "AutoCounter";

        public IDictionary<string, Action> ContextMenuControls => null;

        public AutoCounterComponent(LiveSplitState state)
        {
            Settings = new AutoCounterComponentSettings(state);
            CurrentState = state;
            
            Components = new List<IComponent>();
            ItemComponents = new List<ItemTrackerComponent>();
            InternalComponent = new ComponentRendererComponent();
            InternalComponent.VisibleComponents = Components;
            RebuildComponentList();

            Settings.SettingsChanged += Settings_SettingsChanged;
        }

        void Settings_SettingsChanged(object sender, EventArgs e)
        {
            RebuildComponentList();
        }

        private void RebuildComponentList()
        {
            Components.Clear();
            ItemComponents.Clear();

            int count = Settings.ItemList.Count;
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                    Components.Add(new SeparatorComponent());

                ItemTracker item = Settings.ItemList[i];
                var itemComponent = new ItemTrackerComponent(CurrentState, Settings, item);
                Components.Add(itemComponent);
                ItemComponents.Add(itemComponent);

                if (i < count - 2)
                    Components.Add(new ThinSeparatorComponent());
            }
        }

        public void SetCount(string name, int count)
        {
            foreach (ItemTrackerComponent component in ItemComponents)
            {
                component.SetCount(name, count);
            }
        }

        private void DrawBackground(Graphics g, float width, float height)
        {
            g.FillRectangle(new SolidBrush(Settings.BackgroundColor), 0, 0, width, height);
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            DrawBackground(g, HorizontalWidth, height);
            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            DrawBackground(g, width, VerticalHeight);
            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (invalidator != null)
                InternalComponent.Update(invalidator, state, width, height, mode);
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
            RebuildComponentList();
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();

        public void Dispose() { }
    }
}
