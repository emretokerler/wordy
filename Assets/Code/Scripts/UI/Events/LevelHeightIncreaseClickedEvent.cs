using Wordy.Events;

namespace Wordy.UI.Events
{
    public class LevelHeightIncreaseClickedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new LevelHeightIncreaseClickedEvent();
            e.Trigger();
        }
    }
}