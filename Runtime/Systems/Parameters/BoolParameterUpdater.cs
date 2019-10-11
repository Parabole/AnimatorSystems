using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class BoolParameterUpdater : GenericElementUpdater<BoolParameter>
    {
        protected override void SetElement(int index, BoolParameter elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}