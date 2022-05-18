using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Graphics;

namespace Nebula.Engine.GUI
{
    public class TextField : Widget
    {
        public Text Text { get; set; }

        public TextField(SpriteFont font)
        {
            Text = new Text(font);
        }
        public TextField(string assetPath)
        {
            Text = new Text(assetPath);
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Text.Font, Text.String, AbsolutePosition, Text.Color, Text.Rotation,
                                   Text.Origin, Text.Scale, Text.SpriteEffect, Text.Layer);
            base.Draw(gameTime, spriteBatch);
        }
    }
}
