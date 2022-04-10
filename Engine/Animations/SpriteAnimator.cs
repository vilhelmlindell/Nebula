using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nebula.Engine.Components;
using Nebula.Engine.Graphics;
namespace Nebula.Engine.Animations
{
    public class SpriteAnimator
    {
        private Sprite sprite;
        private Animation animation;
        private FrameTag currentTag;
        private Frame currentFrame;
        private int animationTimer;
        private int frameIndex;

        public SpriteAnimator(string assetPath, Sprite sprite)
        {
            animation = AnimationParser.LoadJson("../../..//Content/" + assetPath);
            this.sprite = sprite;
            frameIndex = 0;
        }

        public void Play(string tagName)
        {
            foreach (FrameTag tag in animation.Tags)
            {
                if (tag.Name == tagName)
                {
                    currentTag = tag;
                }
            }

            if (currentTag != null)
            {
                frameIndex = currentTag.From;
                ChangeFrame();
            }
        }
        private void ChangeFrame()
        {
            animationTimer = 0;
            currentFrame = animation.Frames[frameIndex];
            sprite.SourceRectangle = currentFrame.SourceRectangle;
        }

        public void Update(GameTime gameTime)
        {
            if (currentTag != null)
            {
                animationTimer += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (animationTimer > currentFrame.Duration)
                {
                    if (frameIndex < currentTag.To)
                    {
                        frameIndex++;
                        ChangeFrame();
                    }
                    else
                    {
                        frameIndex = currentTag.From;
                        ChangeFrame();
                    }
                }
            }
        }
    }
}

