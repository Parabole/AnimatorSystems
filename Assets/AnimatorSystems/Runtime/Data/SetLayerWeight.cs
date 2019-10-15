using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    [InternalBufferCapacity(16)]
    public struct SetLayerWeight : IBufferElementData
    {
        public int LayerIndex;
        public float Weight;
    }
}