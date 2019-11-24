using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class SetLayerWeightSystem : SetBufferElementSystem<SetLayerWeight>
    {
        protected override void SetElement(int index, SetLayerWeight elementData, DotsAnimator dotsAnimator)
        {
            dotsAnimator.Animator.SetLayerWeight(elementData.LayerIndex, elementData.Weight);
        }
    }
}