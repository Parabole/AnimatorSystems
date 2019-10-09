using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class SetIntegerSystem : BufferUpdateSystemBase<SetInteger>
    {
        protected override void UpdateParameter(SetInteger elementData, Animator animator)
        {
            animator.SetInteger(elementData.NameHash, elementData.Value);
        }
    }
}