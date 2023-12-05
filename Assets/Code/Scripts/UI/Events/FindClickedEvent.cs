using Wordy.Events;

namespace Wordy.UI.Events
{
    public class FindClickedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new FindClickedEvent();
            e.Trigger();
        }
    }
}