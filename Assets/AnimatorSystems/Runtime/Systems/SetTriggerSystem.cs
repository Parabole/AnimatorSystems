using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(AnimatorParameterGroup))]
    public class SetTriggerSystem : GenericElementUpdater<TriggerParameter>
    {
        protected override void SetElement(int index, TriggerParameter elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}