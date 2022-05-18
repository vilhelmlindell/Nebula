using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nebula.Engine.Graphics;
using Nebula.Engine.Animations;
namespace Nebula.Engine
{
    public enum CollisionType
    {
        Empty,
        Solid
    };

    public static class Tiles
    {
        public static Dictionary<int, Tile> TileData = new Dictionary<int, Tile>();

        #region Tile IDs
        public static int Air = 0;
        public static int Grass = 1;
        #endregion Tile IDs

        static Tiles()
        {
            Tile air = new Tile()
            {
                CollisionType = CollisionType.Empty
            };
            Tile grass = new Tile()
            {
                Sprite = new Sprite("Assets/Sprites/Grass")
                {
                    Scale = new Vector2(2, 2)
                },
                CollisionType = CollisionType.Solid
            };
            TileData.Add(Air, air);
            TileData.Add(Grass, grass);
        }
    }
}
