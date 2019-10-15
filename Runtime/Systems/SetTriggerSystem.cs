using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(AnimatorParametersGroup))]
    public class SetTriggerSystem : SetBufferElementSystem<SetTrigger>
    {
        protected override void SetElement(int index, SetTrigger elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}