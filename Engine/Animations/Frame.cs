using System;
using Microsoft.Xna.Framework;
namespace Nebula.Engine.Animations
{
    public class Frame
    {
        public string FileName { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Vector2 Size { get; set; }
        public int Duration { get; set; }
    }
}
