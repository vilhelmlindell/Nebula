using System;
using System.Collections.Generic;
using Nebula.Engine.Components;
namespace Nebula.Engine.Collisions
{
    public class CollisionHandler
    {
        private List<Entity> collisionEntities;

        public CollisionHandler(Scene scene)
        {
            collisionEntities = scene.GetEntitiesWith(typeof(BoxCollider), typeof(PhysicsBody));
        }

        public void CheckCollisions()
        {
            foreach (Entity entity in collisionEntities)
            {
                foreach (Entity other in collisionEntities)
                {
                    if (entity != other)
                    {
                    }
                }
            }
        }

        public void CheckEntityCollisions(Entity entity)
        {
            foreach (Entity other in collisionEntities)
            {
                if (other != entity)
                {

                }
            }
        }
    }
}
