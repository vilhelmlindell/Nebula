using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nebula.Engine.Animations
{
    public static class AnimationParser
    {
        // Private classes for parsing the json file
        private class Rectangle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int W { get; set; }
            public int H { get; set; }
        }
        private class Size
        {
            public int W { get; set; }
            public int H { get; set; }
        }
        private class FrameData
        {
            public string FileName { get; set; }
            public Rectangle Frame { get; set; }
            public bool Rotated { get; set; }
            public bool Trimmed { get; set; }
            public Rectangle SpriteSourceSize { get; set; }
            public Size SourceSize { get; set; }
            public int Duration { get; set; }
        }
        private class Meta
        {
            public string App { get; set; }
            public string Version { get; set; }
            public string Image { get; set; }
            public string Format { get; set; }
            public Size Size { get; set; }
            public string Scale { get; set; }
            public List<FrameTag> FrameTags { get; set; }
            public List<Layer> Layers { get; set; }
            public List<object> Slices { get; set; }
        }
        private class Root
        {
            public List<FrameData> Frames { get; set; }
            public Meta Meta { get; set; }
        }

        public static Animation LoadJson(string assetPath)
        {
            string json = Main.AssetManager.ReadJson(assetPath);
            Root root = JsonConvert.DeserializeObject<Root>(json);
            Animation animation = new Animation();
            foreach (FrameData frameData in root.Frames)
            {
                Frame frame = new Frame()
                {
                    FileName = frameData.FileName,
                    SourceRectangle = new Microsoft.Xna.Framework.Rectangle
                    (frameData.Frame.X, frameData.Frame.Y, frameData.Frame.W, frameData.Frame.H),
                    Size = new Microsoft.Xna.Framework.Vector2
                    (frameData.SourceSize.W, frameData.SourceSize.H),
                    Duration = frameData.Duration
                };
                animation.Frames.Add(frame);
            }
            foreach (FrameTag tag in root.Meta.FrameTags)
            {
                animation.Tags.Add(tag);
            }
            return animation;
        }
    }
}
