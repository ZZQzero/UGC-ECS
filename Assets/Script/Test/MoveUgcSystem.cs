
using UnityEngine;

namespace UGC
{
    public class MoveUgcSystem : UGCSystemBase
    {
        public MoveUgcSystem(UGCComponentBase component) : base(component)
        {
        }

        public override void Start()
        {
            if (Component != null && Component is MoveComponent moveComponent)
            {
                moveComponent.X = 1;
                moveComponent.Y = 2;
            }

            Debug.LogError("system start");
        }

        public override void Update()
        {
            Debug.LogError("system Update");

        }

        public override void Destroy()
        {
            Debug.LogError("system Destroy");
        }
    }
}
