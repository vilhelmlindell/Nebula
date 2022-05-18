using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Graphics;

namespace Nebula.Engine.GUI
{
    public class Image : Widget
    {
        public Sprite Sprite { get; set; }

        public Image(Sprite sprite)
        {
            Sprite = sprite;
            ResetSize();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.Texture, AbsoluteBounds.Rectangle, Sprite.SourceRectangle, Sprite.Color,
                             Sprite.Rotation, Sprite.Origin, Sprite.SpriteEffect, Sprite.Layer);
            base.Draw(gameTime, spriteBatch);
        }

        public void ResetSize()
        {
            Size = Sprite.Size;
        }
    }
}
