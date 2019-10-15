using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class SetLayerWeightSystem : SetBufferElementSystem<SetLayerWeight>
    {
        protected override void SetElement(int index, SetLayerWeight elementData, Animator animator)
        {
            animator.SetLayerWeight(elementData.LayerIndex, elementData.Weight);
        }
    }
}