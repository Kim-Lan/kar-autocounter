using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class AlternateTimer : Timer
    {
        public override TimeSpan? GetTime(LiveSplitState state, TimingMethod method)
        {
            if (state.CurrentPhase == TimerPhase.NotRunning)
                return state.Run.Offset;
            else if (method == TimingMethod.RealTime)
                return state.CurrentTime[TimingMethod.GameTime];
            else
                return state.CurrentTime[TimingMethod.RealTime];
        }
    }
}
