using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine
{
    public abstract class Component : IComponent
    {
        public Entity Parent { get; set; }

        public virtual void Initialize() { }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Unload() { }
    }
}