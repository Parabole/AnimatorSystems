using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;
namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class AnimatorParametersGroup : ComponentSystemGroup
    {
        [Preserve] public AnimatorParametersGroup() {}

        protected override void OnCreate()
        {
            RequireForUpdate(GetEntityQuery(typeof(AnimatorTag)));
        }
    }
    
}