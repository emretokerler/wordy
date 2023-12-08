using Wordy.Events;

namespace Wordy.UI.Events
{
    public class WordCountIncreasedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new WordCountIncreasedEvent();
            e.Trigger();
        }
    }
}