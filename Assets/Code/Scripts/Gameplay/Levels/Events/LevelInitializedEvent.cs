using Wordy.Events;

namespace Wordy.Levels.Events
{
    public class LevelInitializedEvent : GameEvent
    {
        public LevelBase Level { get; private set; }

        public static void Trigger(LevelBase level)
        {
            LevelInitializedEvent e = new()
            {
                Level = level
            };

            e.Trigger();
        }
    }
}