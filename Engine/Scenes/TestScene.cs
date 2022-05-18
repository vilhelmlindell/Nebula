using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nebula.Engine
{
    public class TestScene : Scene
    {
        public TestScene(string name) : base(name) { }

        public override void Update(GameTime gameTime)
        {
            if (Input.KeyPressed(Keys.Space))
            {
                SceneManager.LoadScene("Main");
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            base.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}
