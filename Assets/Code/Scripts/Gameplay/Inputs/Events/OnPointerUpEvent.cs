using System.Collections.Generic;
using Wordy.Events;
using Wordy.Grids;

namespace Wordy.Gameplay.Inputs.Events
{
    public class OnPointerUpEvent : GameEvent
    {
        public List<CellController> HighlightedCells { get; private set; }
        public static void Trigger(List<CellController> highlightedCells)
        {
            OnPointerUpEvent e = new()
            {
                HighlightedCells = highlightedCells
            };
            e.Trigger();
        }
    }
}