namespace Nebula.Engine.Components
{
    public class Tilemap : Component
    {
        private int[,] tiles;

        public Tilemap(int gridWidth, int gridHeight, int width, int height)
        {
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            Width = width;
            Height = height;
            tiles = new int[Width, Height];
        }

        public int GridWidth { get; }
        public int GridHeight { get; }
        public int Width { get; }
        public int Height { get; }

        public int GetTile(int x, int y)
        {
            if (x < 0 && x >= Width && y < 0 && y >= Height)
            {
                return Tiles.Air;
            }
            else
            {
                return tiles[x, y];
            }
        }
        public void SetTile(int x, int y, int blockId)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                tiles[x, y] = blockId;
            }
        }
        public bool IsCollidable(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return Tiles.TileData[tiles[x, y]].CollisionType == CollisionType.Solid;
            }
            return true;
        }
    }
}
