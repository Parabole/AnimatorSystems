using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(8)]
    public struct Layer : IBufferElementData
    {
        public int Index;
        public int Weight;
    }
}