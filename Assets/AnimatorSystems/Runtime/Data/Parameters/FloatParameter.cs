using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct FloatParameter : IBufferElementData
    {
        public int NameHash;
        public float Value;
    }
}