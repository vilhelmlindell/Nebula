using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nebula.Engine.Collisions;
using Nebula.Engine.Components;
using Nebula.Engine.Factories;
using Nebula.Engine.Graphics;
using Nebula.Engine.GUI;

namespace Nebula.Engine
{
    public class MainScene : Scene
    {
        private Entity player;
        private Entity tilemap;
        private Entity camera;
        private CollisionHandler collisionHandler;
        private GUIManager guiManager;
        private Inventory inventory;

        private Effect effect;

        public MainScene(string name) : base(name)
        {
            guiManager = new GUIManager();
            effect = Main.AssetManager.Load<Effect>("Assets/Shaders/BasicEffect");
        }

        public override void Initialize()
        {
            inventory = new Inventory(10, 5, new Sprite("Assets/Sprites/ItemFrame"));
            guiManager.Widgets.Add(inventory.Container);

            camera = EntityFactory.CreateCamera();
            AddEntity(camera);

            tilemap = EntityFactory.CreateTilemap();
            AddEntity(tilemap);

            player = EntityFactory.CreatePlayer(collisionHandler, tilemap.GetComponent<Tilemap>());
            AddEntity(player);

            base.Initialize();
            collisionHandler = new CollisionHandler(this);
            camera.GetComponent<Camera>().Transform = player.GetComponent<Transform>();
            player.GetComponent<Animator>().Play("Idle");
        }

        public override void Update(GameTime gameTime)
        {
            collisionHandler.CheckCollisions();
            base.Update(gameTime);

            guiManager.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Main.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            base.Draw(gameTime, spriteBatch);
            guiManager.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}
