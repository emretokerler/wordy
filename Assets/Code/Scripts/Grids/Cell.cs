namespace Wordy.Grids
{
    public class Cell
    {
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