using Microsoft.Xna.Framework;
namespace Nebula.Engine.Components
{
    public class Transform : Component
    {
        public Transform() { }
        public Transform(Vector2 position)
        {
            Position = position;
        }
        public Transform(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }
        public Transform(Vector2 position, Vector2 size, float rotation)
        {
            Position = position;
            Size = size;
            Rotation = rotation;
        }

        public Vector2 Position = Vector2.Zero;
        public Vector2 Size = Vector2.One;
        public float Rotation = 0f;
    }
}
