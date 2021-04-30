using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class AutoCounterComponentFactory : IComponentFactory
    {
        public string ComponentName => "AutoCounter";

        public string Description => "";

        public ComponentCategory Category => ComponentCategory.Other;

        public IComponent Create(LiveSplitState state) => new AutoCounterComponent(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("0.1");
    }
}
