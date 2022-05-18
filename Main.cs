using System.IO;
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
            Directory.SetCurrentDirectory("C:/Dev/MonoGame/Nebula/Content");
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public static AssetManager AssetManager { get; private set; }
        public static GraphicsDeviceManager Graphics { get; private set; }
        public static GraphicsDevice GraphicsDevice => Graphics.GraphicsDevice;

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            AssetManager = new AssetManager(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SceneManager.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
