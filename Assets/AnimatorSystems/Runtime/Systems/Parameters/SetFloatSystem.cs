using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class SetFloatSystem : BufferUpdateSystemBase<SetFloat>
    {
        protected override void UpdateParameter(SetFloat elementData, Animator animator)
        {
            animator.SetFloat(elementData.NameHash, elementData.Value);
        }
    }
}