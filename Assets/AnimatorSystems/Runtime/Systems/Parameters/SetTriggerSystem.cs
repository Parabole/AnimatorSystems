using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class SetTriggerSystem : BufferUpdateSystemBase<SetTrigger>
    {
        protected override void UpdateParameter(SetTrigger elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}