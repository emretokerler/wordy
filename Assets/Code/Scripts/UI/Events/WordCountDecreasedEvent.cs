using Wordy.Events;

namespace Wordy.UI.Events
{
    public class WordCountDecreasedEvent : GameEvent
    {
        public static void Trigger()
        {
            var e = new WordCountDecreasedEvent();
            e.Trigger();
        }
    }
}