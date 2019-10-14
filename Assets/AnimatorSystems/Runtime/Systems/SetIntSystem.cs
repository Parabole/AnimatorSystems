using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(AnimatorParameterGroup))]
    public class SetIntSystem : GenericElementUpdater<IntParameter>
    {
        protected override void SetElement(int index, IntParameter elementData, Animator animator)
        {
            animator.SetInteger(elementData.NameHash, elementData.Value);
        }
    }
}