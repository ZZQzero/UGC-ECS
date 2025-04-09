
using MessagePack;

namespace UGC
{
    public interface IUGCComponent
    {
        public int Id { get; set; }

        public void RegisterSystem();
    }
    
    
    [Union(0, typeof(MoveComponent))]
    public abstract class UGCComponentBase : IUGCComponent
    {
        [Key(0)]
        public int Id { get; set; }
        
        [IgnoreMember]
        public UGCSystemBase SystemBase { get; set; }
        public abstract void RegisterSystem();
    }
    
}
