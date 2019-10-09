using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct BoolParameter : IBufferElementData
    {
        public bool Value;
    }
}