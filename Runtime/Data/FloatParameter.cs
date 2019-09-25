using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct FloatParameter : IBufferElementData
    {
        public int Parameter;
        public float Value;
    }
}