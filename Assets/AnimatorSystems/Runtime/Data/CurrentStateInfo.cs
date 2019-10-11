using Unity.Entities;

namespace Parabole.AnimatorSystems.Runtime
{
    [InternalBufferCapacity(16)]
    public struct CurrentStateInfo : IBufferElementData
    {
        public int LayerIndex;
        public float NormalizedTime;
        public int FullPathHash;
        public int ShortNameHash;
        public bool IsLooping;
        public float Speed;
        public float SpeedMultiplier;
        public float Length;
        public int TagHash;
    }
}