using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(64)]
    public struct ParameterHash : IBufferElementData
    {
        public int Hash;
        public int IndexInBuffer;
    }
}