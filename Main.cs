using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Nebula.Engine;

namespace Nebula
{
    public class Main : Game
    {
        private SpriteBatch spriteBatch;

        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public static GraphicsDeviceManager Graphics { get; private set; }
        public static AssetManager AssetManager { get; private set; }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            AssetManager = new AssetManager(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SceneManager.Init();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneManager.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}