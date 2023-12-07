using Wordy.Events;
using Wordy.Grids;

public class CellUnhighlightedEvent : GameEvent
{
    public CellController Cell { get; private set; }

    public static void Trigger(CellController cell)
    {
        CellUnhighlightedEvent e = new()
        {
            Cell = cell
        };
        e.Trigger();
    }
}
