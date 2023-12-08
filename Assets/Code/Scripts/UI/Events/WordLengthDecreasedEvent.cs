using Wordy.Events;

namespace Wordy.UI.Events
{
    public class WordLengthDecreasedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new WordLengthDecreasedEvent();
            e.Trigger();
        }
    }
}