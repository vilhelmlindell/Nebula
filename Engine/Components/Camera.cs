using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Components;

namespace Nebula.Engine.Components
{
    public class Camera : Component
    {
        private Viewport viewport;

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
            SceneManager.LoadedScene.Camera = this;
        }

        public float Zoom { get; set; } = 1f;
        public float Rotation { get; set; }
        public Transform Transform { get; set; }
        public Matrix TransformMatrix { get; private set; }

        public static Camera Main => SceneManager.LoadedScene.Camera;

        public override void Initialize()
        {
            Transform = Parent.GetComponent<Transform>();
        }
        public override void Update(GameTime gameTime)
        {
            TransformMatrix = Matrix.CreateTranslation(new Vector3(-Transform.Position.X, -Transform.Position.Y, 0)) *
                                              Matrix.CreateRotationZ(Rotation) *
                                              Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                                              Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
        }
    }
}
