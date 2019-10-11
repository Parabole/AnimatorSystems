using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct IntParameter: IBufferElementData
    {
        public int NameHash;
        public int Value;
    }
}