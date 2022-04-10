using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Graphics;

namespace Nebula.Engine.Components
{
    public class TilemapRenderer : Component, IUpdateable, IDraweable
    {
        private Tilemap tilemap;
        private Transform transform;

        public override void Init()
        {
            tilemap = Parent.GetComponent<Tilemap>();
            transform = Parent.GetComponent<Transform>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Tile tile in Tiles.TileData.Values)
            {
                if (tile.Animator != null)
                {
                    tile.Animator.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int x = 0; x < tilemap.Width; x++)
            {
                for (int y = 0; y < tilemap.Height; y++)
                {
                    Sprite sprite = Tiles.TileData[tilemap.GetTile(x, y)].Sprite;
                    if (sprite != null)
                    {
                        spriteBatch.Draw(sprite.Texture, transform.Position + new Vector2(x * tilemap.GridWidth, y * tilemap.GridHeight),
                                         sprite.SourceRectangle, sprite.Color, 0f, Vector2.Zero, sprite.Size, sprite.SpriteEffect, sprite.Layer);
                    }
                }
            }
        }
    }
}
