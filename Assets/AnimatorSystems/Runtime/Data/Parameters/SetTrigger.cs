using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct SetTrigger : IBufferElementData
    {
        public int NameHash;
        public bool Value;
    }
}