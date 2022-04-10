using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine
{
    public static class SceneManager
    {
        public static List<Scene> LoadedScenes = new List<Scene>();
        private static List<Scene> scenes = new List<Scene>();

        static SceneManager()
        {
            scenes.Add(new MainScene("Main"));
            scenes.Add(new TestScene("Test"));
            LoadScene("Main");
        }

        public static void LoadScene(string name)
        {
            foreach (Scene scene in scenes)
            {
                if (scene.Name == name)
                {
                    LoadedScenes.Add(scene);
                }
            }
        }
        public static void UnloadScene(string name)
        {
            foreach (Scene scene in scenes)
            {
                if (scene.Name == name)
                {
                    LoadedScenes.Remove(scene);
                }
            }
        }

        public static void Init()
        {
            foreach (Scene scene in scenes)
            {
                scene.Init();
            }
        }
        public static void Update(GameTime gameTime)
        {
            foreach (Scene scene in LoadedScenes.ToList())
            {
                scene.Update(gameTime);
            }
        }
        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Scene scene in LoadedScenes)
            {
                scene.Draw(spriteBatch, gameTime);
            }
        }
    }
}
