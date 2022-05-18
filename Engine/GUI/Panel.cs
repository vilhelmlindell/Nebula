using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Engine.GUI
{
    public enum ButtonState
    {
        None,
        Hovered,
        Clicked,
        Held,
        Released
    };

    public class Panel : Widget
    {
        public ButtonState ButtonState { get; protected set; }
        public ButtonState PrevButtonState { get; protected set; }

        public Action<Panel> OnHover;
        public Action<Panel> OnClick;
        public Action<Panel> OnHeld;
        public Action<Panel> OnRelease;
        public Action<Panel> OnHoverPositionChange;
        public Action<Panel> OnHeldPositionChange;

        public override void Update(GameTime gameTime)
        {
            PrevButtonState = ButtonState;
            ButtonState = ButtonState.None;
            if (AbsoluteBounds.Contains(Input.MousePosition))
            {
                if (Input.LeftMousePressed())
                {
                    ButtonState = ButtonState.Clicked;
                    OnClick?.Invoke(this);
                }
                else if (Input.LeftMouseDown())
                {
                    ButtonState = ButtonState.Held;
                    OnHeld?.Invoke(this);
                }
                else if (Input.LeftMouseReleased())
                {
                    ButtonState = ButtonState.Released;
                    OnRelease?.Invoke(this);
                }
                else
                {
                    ButtonState = ButtonState.Hovered;
                    if (PrevButtonState != ButtonState.Hovered)
                        OnHover?.Invoke(this);
                }
            }

            if (ButtonState == ButtonState.Hovered && Input.MousePosition != Input.PrevMousePosition)
                OnHoverPositionChange?.Invoke(this);
            else if (ButtonState == ButtonState.Held && Input.MousePosition != Input.PrevMousePosition)
                OnHeldPositionChange?.Invoke(this);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
