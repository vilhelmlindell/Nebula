using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine.Graphics
{
    public class Sprite
    {
        public Texture2D Texture;   
        public Rectangle? SourceRectangle = null;
        public Color Color = Color.White;
        public Vector2 Size = Vector2.One;
        public SpriteEffects SpriteEffect = SpriteEffects.None;
        public float Layer = 0f;

        public Sprite(string assetPath)
        {
            Texture = Main.AssetManager.LoadTexture(assetPath);
        }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }
    }
}
