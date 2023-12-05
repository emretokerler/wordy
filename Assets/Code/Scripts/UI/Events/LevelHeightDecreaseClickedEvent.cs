using Wordy.Events;

namespace Wordy.UI.Events
{
    public class LevelHeightDecreaseClickedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new LevelHeightDecreaseClickedEvent();
            e.Trigger();
        }
    }
}