
using UnityEngine;

namespace UGC
{
    public interface IUGCSystem
    {
        public abstract void Start();
        public abstract void Update();
        public abstract void Destroy();
    }

    public abstract class UGCSystemBase : IUGCSystem
    {
        public UGCComponentBase Component;

        public UGCSystemBase(UGCComponentBase component)
        {
            Component = component;
        }
        public abstract void Start();
        public abstract void Update();
        public abstract void Destroy();
    }
}
