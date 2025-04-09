
using MessagePack;

namespace UGC
{
    [MessagePackObject]
    public class MoveComponent : UGCComponentBase
    {
        [Key(1)]
        public float X { get; set;}
        [Key(2)]
        public float Y { get; set;}


        public override void RegisterSystem()
        {
            SystemBase = new MoveUgcSystem(this);
        }
    }
}

