using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;
namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class AnimatorParameterGroup : ComponentSystemGroup
    {
        [Preserve] public AnimatorParameterGroup() {}

        protected override void OnCreate()
        {
            RequireForUpdate(GetEntityQuery(typeof(AnimatorTag)));
        }
    }
    
}