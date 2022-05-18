using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine
{
    public static class SceneManager
    {
        public static Scene LoadedScene;
        private static List<Scene> scenes = new List<Scene>();

        static SceneManager()
        {
            scenes.Add(new MainScene("Main"));
            scenes.Add(new TestScene("Test"));
            LoadScene("Main");
        }

        public static void Initialize()
        {
            LoadedScene.Initialize();
        }
        public static void Update(GameTime gameTime)
        {
            LoadedScene.Update(gameTime);
        }
        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            LoadedScene.Draw(gameTime, spriteBatch);
        }
        public static void Unload()
        {
            LoadedScene.Unload();
        }

        public static void LoadScene(string name)
        {
            foreach (Scene scene in scenes)
            {
                if (scene.Name == name)
                {
                    LoadedScene = scene;
                }
            }
        }
    }
}
