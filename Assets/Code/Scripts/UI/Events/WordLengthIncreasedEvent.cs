using Wordy.Events;

namespace Wordy.UI.Events
{
    public class WordLengthIncreasedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new WordLengthIncreasedEvent();
            e.Trigger();
        }
    }
}