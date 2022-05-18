using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Graphics;

namespace Nebula.Engine.Components
{
    public class TilemapRenderer : Component
    {
        private Tilemap tilemap;
        private Transform transform;

        public override void Initialize()
        {
            tilemap = Parent.GetComponent<Tilemap>();
            transform = Parent.GetComponent<Transform>();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (Tile tile in Tiles.TileData.Values)
            {
                if (tile.Animator != null)
                {
                    tile.Animator.Update(gameTime);
                }
            }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int x = 0; x < tilemap.Width; x++)
            {
                for (int y = 0; y < tilemap.Height; y++)
                {
                    Sprite sprite = Tiles.TileData[tilemap.GetTile(x, y)].Sprite;
                    if (sprite != null)
                    { 
                        if (Camera.Main != null)
                            spriteBatch.Draw(sprite.Texture, Vector2.Transform(transform.Position + new Vector2(x * tilemap.GridWidth, y * tilemap.GridHeight), Camera.Main.TransformMatrix),
                                             sprite.SourceRectangle, sprite.Color, 0f, Vector2.Zero, sprite.Scale, sprite.SpriteEffect, sprite.Layer);
                        else
                            spriteBatch.Draw(sprite.Texture, transform.Position + new Vector2(x * tilemap.GridWidth, y * tilemap.GridHeight),
                                             sprite.SourceRectangle, sprite.Color, 0f, Vector2.Zero, sprite.Scale, sprite.SpriteEffect, sprite.Layer);
                    }
                }
            }
        }
    }
}
