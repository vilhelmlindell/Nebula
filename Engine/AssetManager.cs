using System.IO;
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

        public T Load<T>(string assetPath)
        {
            return Content.Load<T>(assetPath);
        }

        public string ReadJson(string assetPath)
        {
            StreamReader reader = new StreamReader(assetPath);
            return reader.ReadToEnd();
        }
    }
}
