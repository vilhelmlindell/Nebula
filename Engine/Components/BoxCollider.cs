using System;
using System.Drawing;
using System.Collections.Generic;

namespace Nebula.Engine.Components
{
    public enum CollisionResponse
    {
        None,
        Static,
        Dynamic
    }

    public class BoxCollider : Component
    {
        public int Width;
        public int Height;
        public CollisionResponse Response;
        private RectangleF bounds;
        private Tilemap tilemap;
        private Transform transform;
        private PhysicsBody body;
            
        public BoxCollider(int width, int height, Tilemap tilemap)
        {
            Width = width;
            Height = height;
            this.tilemap = tilemap;
        }

        public bool TouchingRight { get; private set; }
        public bool TouchingLeft { get; private set; }
        public bool TouchingCeiling { get; private set; }
        public bool TouchingGround { get; private set; }

        public override void Initialize()
        {
            transform = Parent.GetComponent<Transform>();
            body = Parent.GetComponent<PhysicsBody>();
        }

        public void CheckCollisionsX()
        {
            TouchingRight = false;
            TouchingLeft = false;
            foreach (RectangleF other in GetCollisions())
            {
                if (body.Velocity.X > 0) // Moving right
                {
                    transform.Position.X = other.Left - Width;
                    TouchingRight = true;
                }
                else if (body.Velocity.X < 0) // Moving left
                {
                    transform.Position.X = other.Right;
                    TouchingLeft = true;
                }
                body.Velocity.X = 0;
            }
        }
        public void CheckCollisionsY()
        {
            TouchingCeiling = false;
            TouchingGround = false;
            foreach (RectangleF other in GetCollisions())
            {
                if (body.Velocity.Y > 0) // Moving down
                {
                    transform.Position.Y = other.Top - Height;
                    TouchingGround = true;
                }
                else if (body.Velocity.Y < 0) // Moving up
                {
                    transform.Position.Y = other.Bottom;
                    TouchingCeiling = true;
                }
                body.Velocity.Y = 0;
            }
        }
        private List<RectangleF> GetCollisions()
        {
            bounds = new RectangleF(transform.Position.X, transform.Position.Y, Width, Height);
            List<RectangleF> collisions = new List<RectangleF>();

            int leftTile = (int)Math.Floor(bounds.Left / tilemap.GridWidth);
            int rightTile = (int)Math.Ceiling(bounds.Right / tilemap.GridWidth) - 1;
            int topTile = (int)Math.Floor(bounds.Top / tilemap.GridHeight);
            int bottomTile = (int)Math.Ceiling(bounds.Bottom / tilemap.GridHeight) - 1;

            for (int y = topTile; y <= bottomTile; ++y)
            {
                for (int x = leftTile; x <= rightTile; ++x)
                {
                    if (tilemap.IsCollidable(x, y))
                    {
                        RectangleF tile = new RectangleF(x * tilemap.GridWidth, y * tilemap.GridHeight,
                                                       tilemap.GridWidth, tilemap.GridHeight);
                        if (bounds.IntersectsWith(tile))
                        {
                            collisions.Add(tile);
                        }
                    }
                }
            }
            return collisions;
        }
    }
}
