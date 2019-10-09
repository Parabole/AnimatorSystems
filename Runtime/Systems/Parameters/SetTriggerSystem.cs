using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class SetTriggerSystem : SetParameterSystem<SetTrigger>
    {
        protected override void SetParameter(SetTrigger elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}