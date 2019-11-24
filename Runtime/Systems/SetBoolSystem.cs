using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class SetBoolSystem : SetBufferElementSystem<SetBool>
    {
        protected override void SetElement(int index, SetBool elementData, DotsAnimator animator)
        {
            animator.Animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}