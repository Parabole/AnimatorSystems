using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct SetBool: IBufferElementData
    {
        public int NameHash;
        public bool Value;
    }
}