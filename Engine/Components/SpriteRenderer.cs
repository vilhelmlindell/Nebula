using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Nebula.Engine.Graphics;

namespace Nebula.Engine.Components
{
    public class SpriteRenderer : Component
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

        public override void Initialize()
        {
            transform = Parent.GetComponent<Transform>();
        }   
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Camera.Main != null)
                spriteBatch.Draw(Sprite.Texture, Vector2.Transform(transform.Position, Camera.Main.TransformMatrix), Sprite.SourceRectangle, 
                                 Sprite.Color, transform.Rotation, Origin, transform.Size, Sprite.SpriteEffect, Sprite.Layer);
            else
                spriteBatch.Draw(Sprite.Texture, transform.Position, Sprite.SourceRectangle, Sprite.Color, 
                                 transform.Rotation, Origin, transform.Size, Sprite.SpriteEffect, Sprite.Layer);
        }
    }
}
