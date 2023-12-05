using Wordy.Events;

namespace Wordy.UI.Events
{
    public class RefreshClickedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new RefreshClickedEvent();
            e.Trigger();
        }
    }
}