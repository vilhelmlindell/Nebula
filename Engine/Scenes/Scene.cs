using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Components;

namespace Nebula.Engine
{
    public abstract class Scene
    {
        public readonly string Name;
        private List<Entity> entities;
        private bool initialized = false;

        public Scene(string name)
        {
            Name = name;

            entities = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }
        public List<Entity> GetEntitiesWith(params Type[] components)
        {
            List<Entity> approvedEntities = new List<Entity>();
            bool contains = true;
            foreach (Entity entity in entities)
            {
                foreach (Type type in components)
                {
                    if (!entity.Components.Select(x => x.GetType()).Contains(type))
                    {
                        contains = false;
                        break;
                    }
                }
                if (contains)
                {
                    approvedEntities.Add(entity);
                }
                contains = true;
            }
            return approvedEntities;
        }
        public virtual void Init()
        {
            foreach (Entity entity in entities)
            {
                entity.Init();
            }
            initialized = true;
        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Draw(spriteBatch, gameTime);
            }
        }
    }
}
