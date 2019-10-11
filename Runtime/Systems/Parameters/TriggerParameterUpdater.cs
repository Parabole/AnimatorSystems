using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public class TriggerParameterUpdater : GenericElementUpdater<TriggerParameter>
    {
        protected override void SetElement(int index, TriggerParameter elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}