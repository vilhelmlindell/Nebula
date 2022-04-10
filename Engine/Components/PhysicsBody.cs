using Microsoft.Xna.Framework;
using Nebula.Engine.Collisions;

namespace Nebula.Engine.Components
{
    public class PhysicsBody : Component, IUpdateable
    {
        public Vector2 Velocity;
        private Transform transform;
        private BoxCollider boxCollider;
        private CollisionHandler collisionHandler;

        public PhysicsBody(CollisionHandler collisionHandler)
        {
            this.collisionHandler = collisionHandler;
        }

        public override void Init()
        {
            transform = Parent.GetComponent<Transform>();
            boxCollider = Parent.GetComponent<BoxCollider>();
        }

        public void Update(GameTime gameTime)
        {
            bool hasCollider = boxCollider != null;
            transform.Position.X += Velocity.X;
            if (hasCollider)
            {
                boxCollider.CheckCollisionsX();
            }
            transform.Position.Y += Velocity.Y;
            if (hasCollider)
            {
                boxCollider.CheckCollisionsY();
            }
        }
    }
}