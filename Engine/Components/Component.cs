namespace Nebula.Engine
{
    public abstract class Component
    {
        public Entity Parent = null;

        public virtual void Init() { }
    }
}