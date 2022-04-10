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
                SceneManager.UnloadScene("Test");
            }
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            base.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
