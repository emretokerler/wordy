namespace Wordy.Grids
{
    public class Grid
    {
        public Cell[,] Cells;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            Initialize();
        }

        void Initialize()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cells[x, y] = new Cell(x, y, ' ');
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return null;
            }
            return Cells[x, y];
        }
    }
}