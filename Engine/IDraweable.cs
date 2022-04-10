using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine
{
    public interface IDraweable
    {
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
