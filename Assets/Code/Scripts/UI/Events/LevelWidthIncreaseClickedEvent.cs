using Wordy.Events;

namespace Wordy.UI.Events
{
    public class LevelWidthIncreaseClickedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new LevelWidthIncreaseClickedEvent();
            e.Trigger();
        }
    }
}