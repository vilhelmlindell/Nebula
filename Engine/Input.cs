using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Nebula.Engine
{
    public static class Input
    {
        private static KeyboardState keyState;
        private static KeyboardState prevKeyState;
        private static MouseState mouseState;
        private static MouseState prevMouseState;

        static Input()
        {
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        public static Vector2 MousePosition => new Vector2(mouseState.X, mouseState.Y);
        public static Vector2 PrevMousePosition => new Vector2(prevMouseState.X, prevMouseState.Y);

        public static void Update()
        {
            prevKeyState = keyState;
            prevMouseState = mouseState;
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        public static bool KeyDown(Keys key)
        {
            return keyState.IsKeyDown(key);
        }
        public static bool KeyUp(Keys key)
        {
            return keyState.IsKeyUp(key);
        }
        public static bool KeyPressed(Keys key)
        {
            return prevKeyState.IsKeyUp(key) && keyState.IsKeyDown(key);
        }
        public static bool KeyReleased(Keys key)
        {
            return prevKeyState.IsKeyDown(key) && keyState.IsKeyUp(key);
        }
        public static bool RightMouseDown()
        {
            return mouseState.RightButton == ButtonState.Pressed;
        }
        public static bool RightMouseUp()
        {
            return mouseState.RightButton == ButtonState.Released;
        }
        public static bool RightMousePressed()
        {
            return prevMouseState.RightButton == ButtonState.Released &&
                   mouseState.RightButton == ButtonState.Pressed;
        }
        public static bool RightMouseReleased()
        {
            return prevMouseState.RightButton == ButtonState.Pressed &&
                   mouseState.RightButton == ButtonState.Released;
        }
        public static bool LeftMouseDown()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }
        public static bool LeftMouseUp()
        {
            return mouseState.LeftButton == ButtonState.Released;
        }
        public static bool LeftMousePressed()
        {
            return prevMouseState.LeftButton == ButtonState.Released &&
                   mouseState.LeftButton == ButtonState.Pressed;
        }
        public static bool LeftMouseReleased()
        {
            return prevMouseState.LeftButton == ButtonState.Pressed &&
                   mouseState.LeftButton == ButtonState.Released;
        }
    }
}
