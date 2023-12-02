namespace Wordy.Grids
{
    [System.Serializable]
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Letter { get; private set; }
        public bool IsHighlighted;

        public Cell(int x, int y, char letter)
        {
            X = x;
            Y = y;
            Letter = letter;
            IsHighlighted = false;
        }
    }
}