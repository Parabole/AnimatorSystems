using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct SetInt: IBufferElementData
    {
        public int NameHash;
        public int Value;
    }
}