using Wordy.Events;

namespace Wordy.Services.Events
{
    public class AllServicesLoadedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new AllServicesLoadedEvent();
            e.Trigger();
        }
    }
}