using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class SetFloatSystem : SetBufferElementSystem<SetFloat>
    {
        protected override void SetElement(int index, SetFloat elementData, DotsAnimator dotsAnimator)
        {
            dotsAnimator.Animator.SetFloat(elementData.NameHash, elementData.Value);
        }
    }
}