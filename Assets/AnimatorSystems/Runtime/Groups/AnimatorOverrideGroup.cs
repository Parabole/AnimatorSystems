using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;
namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateBefore(typeof(AnimatorParameterGroup))]
    public class AnimatorOverrideGroup : ComponentSystemGroup
    {
        [Preserve] public AnimatorOverrideGroup() {}

        protected override void OnCreate()
        {
            RequireForUpdate(GetEntityQuery(typeof(AnimatorTag)));
        }
    }
    
}