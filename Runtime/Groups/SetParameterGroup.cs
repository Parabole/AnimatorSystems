using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;
namespace Parabole.AnimatorSystems.Runtime
{
    public class SetParameterGroup : ComponentSystemGroup
    {
        [Preserve] public SetParameterGroup() {}

        protected override void OnCreate()
        {
            RequireForUpdate(GetEntityQuery(typeof(Animator)));
        }
    }
    
}