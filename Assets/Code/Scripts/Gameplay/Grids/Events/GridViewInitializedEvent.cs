using Wordy.Events;
using Wordy.Grids;

namespace Wordy.Grids.Events
{
    public class GridViewInitializedEvent : GameEvent
    {
        public GridView GridView { get; private set; }
        public static void Trigger(GridView gridView)
        {
            var e = new GridViewInitializedEvent
            {
                GridView = gridView
            };
            e.Trigger();
        }
    }
}