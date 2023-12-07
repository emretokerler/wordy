namespace Wordy.Grids
{
    [System.Serializable]
    public class Cell
    {
        public CellController CellController;
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Letter { get; set; }

        public Cell(int x, int y, char letter)
        {
            X = x;
            Y = y;
            Letter = letter;
        }
    }
}