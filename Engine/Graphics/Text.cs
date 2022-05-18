using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine.Graphics
{
    public class Text
    {
        public string String { get; set; } = "";
        public float Rotation { get; set; }
        public float Layer { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; } = Color.White;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Origin { get; set; } = Vector2.Zero;
        public SpriteEffects SpriteEffect { get; set; } = SpriteEffects.None;

        public Text(string assetPath)
        {
            Font = Main.AssetManager.Load<SpriteFont>(assetPath);
        }
        public Text(SpriteFont font)
        {
            Font = font;
        }

        public Vector2 Size => Font.MeasureString(String) * Scale;
    }
}