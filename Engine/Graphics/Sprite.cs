using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public float Rotation { get; set; }
        public float Layer { get; set; }
        public SpriteEffects SpriteEffect { get; set; }
        public Rectangle? SourceRectangle { get; set; }
        public Color Color { get; set; } = Color.White;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Origin { get; set; } = Vector2.Zero;

        public Sprite(string assetPath)
        {
            Texture = Main.AssetManager.Load<Texture2D>(assetPath);
        }
        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }

        public int Width => Texture.Width * Convert.ToInt32(Scale.X);
        public int Height => Texture.Height * Convert.ToInt32(Scale.X);
        public Vector2 Size => new Vector2(Width, Height);
    }
}
