namespace Wordy.Grids
{
    public class Grid
    {
        protected Cell[,] cells;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            cells = new Cell[width, height];
            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y] = new Cell(x, y , ' ');
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return null;
            }
            return cells[x, y];
        }

    }
}