using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class SetIntSystem : SetBufferElementSystem<SetInt>
    {
        protected override void SetElement(int index, SetInt elementData, DotsAnimator dotsAnimator)
        {
            dotsAnimator.Animator.SetInteger(elementData.NameHash, elementData.Value);
        }
    }
}