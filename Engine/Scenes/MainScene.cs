using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Collisions;
using Nebula.Engine.Components;

namespace Nebula.Engine
{
    public class MainScene : Scene
    {
        private Entity player;
        private Entity tilemap;
        private CollisionHandler collisionHandler;

        public MainScene(string name) : base(name)
        {
        }

        public override void Init()
        {
            tilemap = new Entity();
            AddEntity(tilemap);
            tilemap.AddComponent(new Transform());
            Tilemap tilemapComponent = new Tilemap(32, 32, 16, 16);
            tilemap.AddComponent(tilemapComponent);
            tilemap.AddComponent(new TilemapRenderer());
            for (int x = 0; x < 16; x++)
            {
                tilemapComponent.SetTile(x, 14, Tiles.Grass);
            }

            player = new Entity();
            AddEntity(player);
            player.AddComponent(new Transform());
            player.AddComponent(new SpriteRenderer("Assets/Sprites/Slime"));
            Animator animator = new Animator("Assets/Animations/Slime.json");
            player.AddComponent(animator);
            player.AddComponent(new PhysicsBody(collisionHandler));
            player.AddComponent(new BoxCollider(32, 23, tilemapComponent)
            {
                Response = CollisionResponse.Dynamic
            });
            player.AddComponent(new PlayerMovement());

            base.Init();
            collisionHandler = new CollisionHandler(this);
            animator.Play("Idle");
        }

        public override void Update(GameTime gameTime)
        {
            collisionHandler.CheckCollisions();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            base.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}