using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Nebula.Engine
{
    public sealed class Entity : IComponent
    {
        public Entity() { }
        public Entity(Entity other)
        {
            Entity entity = other.Copy();
            foreach (Component component in entity.Components)
            {
                AddComponent(component);
            }
        }

        public List<Component> Components { get; } = new List<Component>();

        public void Initialize()
        {
            foreach (Component component in Components)
            {
                component.Initialize();
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach (Component component in Components)
            {
                component.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Component component in Components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }
        public void Unload()
        {
            foreach (Component component in Components)
            {
                component.Unload();
            }
        }

        public void AddComponent(Component componentToAdd)
        {
            componentToAdd.Parent = this;
            Components.Add(componentToAdd);
        }
        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in Components)
                if (component.GetType() == typeof(T))
                    return (T)component;
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
    }
}