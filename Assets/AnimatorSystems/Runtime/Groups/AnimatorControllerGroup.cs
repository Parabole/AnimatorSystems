using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;
namespace Parabole.AnimatorSystems
{
    [UpdateBefore(typeof(AnimatorParametersGroup))]
    public class AnimatorControllerGroup : ComponentSystemGroup
    {
        [Preserve] public AnimatorControllerGroup() {}

        protected override void OnCreate()
        {
            RequireForUpdate(GetEntityQuery(typeof(AnimatorTag)));
        }
    }
    
}