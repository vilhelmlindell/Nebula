using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Animations;
namespace Nebula.Engine.Components
{
    public class Animator : Component, IUpdateable
    {
        private SpriteRenderer sprite;
        private SpriteAnimator animator;
        private string assetPath;

        public Animator(string assetPath)
        {
            this.assetPath = assetPath;
        }

        public void Play(string tagName)
        {
            animator.Play(tagName);
        }
        public override void Init()
        {
            sprite = Parent.GetComponent<SpriteRenderer>();
            animator = new SpriteAnimator(assetPath, sprite.Sprite);
        }

        public void Update(GameTime gameTime)
        {
            animator.Update(gameTime);
        }
    }
}
