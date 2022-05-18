using Microsoft.Xna.Framework;
using Nebula.Engine.Animations;
namespace Nebula.Engine.Components
{
    public class Animator : Component
    {
        private string assetPath;
        private SpriteRenderer sprite;
        private SpriteAnimator animator;

        public Animator(string assetPath)
        {
            this.assetPath = assetPath;
        }

        public override void Initialize()
        {
            sprite = Parent.GetComponent<SpriteRenderer>();
            animator = new SpriteAnimator(assetPath, sprite.Sprite);
        }
        public override void Update(GameTime gameTime)
        {
            animator.Update(gameTime);
        }

        public void Play(string tagName)
        {
            animator.Play(tagName);
        }
    }
}
