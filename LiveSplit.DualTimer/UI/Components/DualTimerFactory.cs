using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class DualTimerFactory : IComponentFactory
    {
        public string ComponentName => "Dual Timer";

        public string Description => "Displays both real time and game time.";

        public ComponentCategory Category => ComponentCategory.Timer;

        public IComponent Create(LiveSplitState state) => new DualTimer(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("1.0");
    }
}
