using Wordy.Events;
using Wordy.Grids;

namespace Wordy.Words.Events
{
    public class WordRevealedEvent : GameEvent
    {
        public Word Word { get; private set; }

        public static void Trigger(Word word)
        {
            WordRevealedEvent e = new()
            {
                Word = word
            };
            e.Trigger();
        }
    }
}