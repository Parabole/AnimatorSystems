using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct TriggerParameter : IBufferElementData
    {
        public int Parameter;
        public bool Value;
    }
}