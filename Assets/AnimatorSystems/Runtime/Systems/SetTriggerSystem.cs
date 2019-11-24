using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class SetTriggerSystem : SetBufferElementSystem<SetTrigger>
    {
        protected override void SetElement(int index, SetTrigger elementData, DotsAnimator dotsAnimator)
        {
            dotsAnimator.Animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}