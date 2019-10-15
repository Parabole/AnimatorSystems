using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct SetFloat : IBufferElementData
    {
        public int NameHash;
        public float Value;
    }
}