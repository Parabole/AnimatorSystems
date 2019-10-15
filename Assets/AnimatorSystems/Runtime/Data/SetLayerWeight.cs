using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct SetLayerWeight : IBufferElementData
    {
        public int LayerIndex;
        public int Weight;
    }
}