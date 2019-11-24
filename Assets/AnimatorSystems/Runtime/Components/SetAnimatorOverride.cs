using Unity.Entities;

namespace Parabole.AnimatorSystems
{
    public struct SetAnimatorOverride : IComponentData
    {
        public int CollectionIndex;
        public int ControllerIndex;
    }
}