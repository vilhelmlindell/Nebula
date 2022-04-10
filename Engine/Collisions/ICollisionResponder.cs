namespace Nebula.Engine.Collisions
{
    public interface ICollisionResponder
    {
        public void OnCollisionEnter(Entity other);
    }
}