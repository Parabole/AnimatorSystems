using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(AnimatorParametersGroup))]
    public class SetFloatSystem : SetBufferElementSystem<SetFloat>
    {
        protected override void SetElement(int index, SetFloat elementData, Animator animator)
        {
            animator.SetFloat(elementData.NameHash, elementData.Value);
        }
    }
}