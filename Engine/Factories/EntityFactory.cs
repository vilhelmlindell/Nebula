using Nebula.Engine.Collisions;
using Nebula.Engine.Components;

namespace Nebula.Engine.Factories
{
    public static class EntityFactory
    {
        public static Entity CreateCamera()
        {
            Entity camera = new Entity();
            camera.AddComponent(new Transform());
            camera.AddComponent(new Camera(Main.GraphicsDevice.Viewport));
            return camera;
        }

        public static Entity CreatePlayer(CollisionHandler collisionHandler, Tilemap tilemap)
        {
            Entity player = new Entity();
            player.AddComponent(new Transform());
            player.AddComponent(new SpriteRenderer("Assets/Sprites/Slime"));
            Animator animator = new Animator("Assets/Animations/Slime.json");
            player.AddComponent(animator);
            player.AddComponent(new PhysicsBody(collisionHandler));
            player.AddComponent(new BoxCollider(32, 23, tilemap)
            {
                Response = CollisionResponse.Dynamic
            });
            player.AddComponent(new PlayerMovement());
            return player;
        }

        public static Entity CreateTilemap()
        {
            Entity tilemap = new Entity();
            tilemap.AddComponent(new Transform());
            Tilemap tilemapComponent = new Tilemap(32, 32, 16, 16);
            tilemap.AddComponent(tilemapComponent);
            tilemap.AddComponent(new TilemapRenderer());
            for (int x = 0; x < 16; x++)
            {
                tilemapComponent.SetTile(x, 14, Tiles.Grass);
            }
            return tilemap;
        }
    }
}
