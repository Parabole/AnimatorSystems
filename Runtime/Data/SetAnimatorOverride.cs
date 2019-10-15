using Unity.Entities;

namespace AnimatorSystems.Runtime
{
    public struct SetAnimatorOverride : IComponentData
    {
        public int Index;
    }
}