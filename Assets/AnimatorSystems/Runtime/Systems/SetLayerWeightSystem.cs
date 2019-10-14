using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    public class SetLayerWeightSystem : GenericElementUpdater<LayerWeight>
    {
        protected override void SetElement(int index, LayerWeight elementData, Animator animator)
        {
            animator.SetLayerWeight(elementData.LayerIndex, elementData.Weight);
        }
    }
}