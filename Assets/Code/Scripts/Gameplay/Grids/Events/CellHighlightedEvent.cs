using Wordy.Events;
using Wordy.Grids;

public class CellHighlightedEvent : GameEvent
{
    public CellController Cell { get; private set; }

    public static void Trigger(CellController cell)
    {
        CellHighlightedEvent e = new()
        {
            Cell = cell
        };
        e.Trigger();
    }
}
