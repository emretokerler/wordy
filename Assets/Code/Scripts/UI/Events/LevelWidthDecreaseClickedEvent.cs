using Wordy.Events;

namespace Wordy.UI.Events
{
    public class LevelWidthDecreaseClickedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new LevelWidthDecreaseClickedEvent();
            e.Trigger();
        }
    }
}