using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct IntParameter : IBufferElementData
    {
        public int Parameter;
        public int Value;
    }
}