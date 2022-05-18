using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine.GUI
{
    public class Widget : IComponent
    {
        private Widget parent;
        private float x;
        private float y;
        private float width;
        private float height;

        public float X 
        { 
            get { return x; } 
            set
            {
                x = value;
                OnMove?.Invoke(this);
            }
        }
        public float Y
        {
            get { return y; }
            set
            {
                y = value;
                OnMove?.Invoke(this);
            }
        }
        public float Width
        {
            get { return width; }
            set
            {
                width = value;
                OnResize?.Invoke(this);
            }
        }
        public float Height
        {
            get { return height; }
            set
            {
                height = value;
                OnResize?.Invoke(this);
            }
        }
        public bool DoUpdate { get; set; } = true;
        public bool DoDraw { get; set; } = true;
        public bool Enabled { get; set; } = true;
        public List<Widget> Children { get; set; } = new List<Widget>();
        public Widget Parent
        {
            get { return parent; }
            set
            {
                parent?.RemoveChild(this);
                parent = value;
            }
        }
        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
                OnMove?.Invoke(this);
            }
        }
        public Vector2 AbsolutePosition
        {
            get
            {
                return Parent != null ? Position + Parent.AbsolutePosition : Position;
            }
        }
        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
            set
            {
                Width = value.X;
                Height = value.Y;
                OnResize?.Invoke(this);
            }
        }
        public RectangleF Bounds
        {
            get { return new RectangleF(X, Y, Width, Height); }
            set
            {
                X = value.X;
                Y = value.Y;
                Width = value.Width;
                Height = value.Height;
                OnMove?.Invoke(this);
                OnResize?.Invoke(this);
            }
        }
        public RectangleF AbsoluteBounds
        {
            get
            {
                return new RectangleF(AbsolutePosition, Width, Height);
            }
        }

        public Action<Widget> OnResize;
        public Action<Widget> OnMove;

        public virtual void Initialize() { }
        public virtual void Update(GameTime gameTime) 
        {
            foreach (Widget child in Children)
                if (child.Enabled && child.DoUpdate)
                    child.Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            foreach (Widget child in Children)
                if (child.Enabled && child.DoUpdate)
                    child.Draw(gameTime, spriteBatch);
        }
        public virtual void Unload() { }

        public void AddChild(Widget widget)
        {
            Children.Add(widget);
            widget.Parent = this;
        }
        public T GetChild<T>() where T : Widget
        {
            foreach (Widget widget in Children)
                if (widget.GetType() == typeof(T))
                    return (T) widget;
            return null;
        }
        public void RemoveChild(Widget widget)
        {
            Children.Remove(widget);
            widget.parent = null;
        }
    }
}
