using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Nebula.Engine
{
    public sealed class Entity
    {
        public Entity()
        { }

        public Entity(Entity other)
        {
            Entity entity = other.Copy();
            foreach (Component component in entity.Components)
            {
                AddComponent(component);
            }
        }

        public List<Component> Components { get; private set; } = new List<Component>();

        public void AddComponent(Component componentToAdd)
        {
            componentToAdd.Parent = this;
            Components.Add(componentToAdd);
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in Components)
            {
                if (component.GetType() == typeof(T))
                {
                    return (T)component;
                }
            }
            return null;
        }

        public bool HasComponent<T>() where T : Component
        {
            return GetComponent<T>() != null;
        }

        public void RemoveComponent<T>() where T : Component
        {
            foreach (Component component in Components)
            {
                if (component.GetType() == typeof(T))
                {
                    Components.Remove(component);
                    return;
                }
            }
        }

        public void Init()
        {
            foreach (Component component in Components)
            {
                component.Init();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
            {
                if (component is IUpdateable)
                {
                    (component as IUpdateable).Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Component component in Components)
            {
                if (component is IDraweable)
                {
                    (component as IDraweable).Draw(spriteBatch, gameTime);
                }
            }
        }
    }
}