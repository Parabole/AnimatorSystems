using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct BoolParameter : IBufferElementData
    {
        public int Parameter;
        public bool Value;
    }
}