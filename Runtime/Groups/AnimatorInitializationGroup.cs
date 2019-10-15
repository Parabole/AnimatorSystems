using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;
namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class AnimatorInitializationGroup : ComponentSystemGroup
    {
        [Preserve] public AnimatorInitializationGroup() {}

        protected override void OnCreate()
        {
            RequireForUpdate(GetEntityQuery(typeof(AnimatorTag)));
        }
    }
    
}