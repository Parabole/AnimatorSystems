using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct SetInteger: IBufferElementData
    {
        public int NameHash;
        public int Value;
    }
}