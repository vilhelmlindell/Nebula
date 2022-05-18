using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Nebula.Engine.GUI
{
    public class GUIManager : IComponent
    {
        public List<Widget> Widgets = new List<Widget>();

        public void Initialize()
        {
            foreach (Widget widget in Widgets)
                widget.Initialize();
        }
        public void Update(GameTime gameTime)
        {
            foreach (Widget widget in Widgets)
                if (widget.Enabled && widget.DoUpdate)
                    widget.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Widget widget in Widgets)
                if (widget.Enabled && widget.DoUpdate)
                    widget.Draw(gameTime, spriteBatch);
        }
        public void Unload()
        {
            foreach (Widget widget in Widgets)
                widget.Unload();
        }
    }
}
