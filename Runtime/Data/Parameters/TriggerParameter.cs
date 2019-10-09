using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct TriggerParameter : IBufferElementData
    {
        public int NameHash;
        public bool Value;
    }
}