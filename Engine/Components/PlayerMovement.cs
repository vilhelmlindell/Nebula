using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Nebula.Engine.Components
{
    public class PlayerMovement : Component, IUpdateable
    {
        private readonly float maxVelocityTime = 60;
        private readonly float maxVelocity = 3;
        private readonly float terminalVelocity = 5;
        private readonly float jumpHeight = 120;
        private readonly float jumpWidth = 100;
        private readonly int minJumpFrames = 5;
        private readonly int midAirJumps = 3;
        private readonly float xFriction;
        private readonly float xAcceleration;
        private readonly float jumpTime;
        private bool jumpHeld;
        private bool jumpReleased;
        private bool jumpedMidAir;
        private int currentJumpFrames;
        private int currentMidAirJumps;
        private int xInput;

        private Vector2 acceleration;

        private PhysicsBody body;
        private BoxCollider boxCollider;

        public PlayerMovement()
        {
            xFriction = 5 / maxVelocityTime;
            xAcceleration = maxVelocity * xFriction;
            jumpTime = jumpWidth / maxVelocity;
            currentMidAirJumps = midAirJumps;
        }

        public override void Init()
        {
            body = Parent.GetComponent<PhysicsBody>();
            boxCollider = Parent.GetComponent<BoxCollider>();
        }

        public void Update(GameTime gameTime)
        {
            if (Input.KeyDown(Keys.D))
                xInput= 1;
            else if (Input.KeyDown(Keys.A))
                xInput = -1;
            else
                xInput = 0;

            if (boxCollider.TouchingGround)
            {
                jumpHeld = false;
                jumpedMidAir = false;
                jumpReleased = false;
                currentJumpFrames = 0;
                currentMidAirJumps = midAirJumps;
            }

            if (Input.KeyPressed(Keys.Space) && boxCollider.TouchingGround)
            {
                body.Velocity.Y -= (2 * jumpHeight * maxVelocity) / jumpWidth;
                jumpHeld = true;
                currentJumpFrames = 0;
            }

            if (currentMidAirJumps > 0)
            {
                if (Input.KeyPressed(Keys.Space) && !boxCollider.TouchingGround)
                {
                    body.Velocity.Y = 0;
                    body.Velocity.Y -= (2 * jumpHeight * maxVelocity) / jumpWidth;
                    currentMidAirJumps--;
                    jumpedMidAir = true;
                }
            }

            if (Input.KeyDown(Keys.Space) && jumpHeld)
                currentJumpFrames++;

            if (Input.KeyReleased(Keys.Space) && jumpHeld)
                jumpReleased = true;

            acceleration.X = xInput * xAcceleration;
            body.Velocity.X += acceleration.X;
            body.Velocity.X -= body.Velocity.X * xFriction;

            if (jumpReleased && body.Velocity.Y < 0 && !jumpedMidAir)
            {
                body.Velocity.Y += (2 * jumpHeight * maxVelocity * maxVelocity) / (jumpWidth * jumpWidth) *
                                   (jumpTime / Math.Clamp(currentJumpFrames, minJumpFrames, jumpTime));
            }
            else
                body.Velocity.Y += (2 * jumpHeight * maxVelocity * maxVelocity) / (jumpWidth * jumpWidth);

            if (body.Velocity.Y > terminalVelocity)
                body.Velocity.Y = terminalVelocity;
        }
    }
}