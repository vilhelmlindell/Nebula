using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Nebula.Engine
{
    public class AssetManager
    {
        public AssetManager(ContentManager content)
        {
            Content = content;
        }

        public ContentManager Content { get; }

        public Texture2D LoadTexture(string assetPath)
        {
            return Content.Load<Texture2D>(assetPath);
        }

        public string ReadJson(string assetPath)
        {
            StreamReader reader = new StreamReader(assetPath);
            return reader.ReadToEnd();
        }
    }
}
