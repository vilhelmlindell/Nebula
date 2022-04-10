using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Nebula.Engine.Graphics;

namespace Nebula.Engine.Components
{
    public class SpriteRenderer : Component, IDraweable
    {
        public Sprite Sprite;
        public Vector2 Origin = Vector2.Zero;

        private Transform transform;

        public SpriteRenderer(string assetPath)
        {
            Sprite = new Sprite(assetPath);
        }
        public SpriteRenderer(Texture2D texture)
        {
            Sprite = new Sprite(texture);
        }

        public override void Init()
        {
            transform = Parent.GetComponent<Transform>();
        }   
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Sprite.Texture, transform.Position, Sprite.SourceRectangle, Sprite.Color,
                             transform.Rotation, Origin, transform.Size, Sprite.SpriteEffect, Sprite.Layer);
        }
    }
}
