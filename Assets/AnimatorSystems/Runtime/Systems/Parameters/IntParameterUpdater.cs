using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class IntParameterUpdater : GenericElementUpdater<IntParameter>
    {
        protected override void SetElement(int index, IntParameter elementData, Animator animator)
        {
            animator.SetInteger(elementData.NameHash, elementData.Value);
        }
    }
}