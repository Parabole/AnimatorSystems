using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(AnimatorParametersGroup))]
    public class SetFloatSystem : GenericElementUpdater<FloatParameter>
    {
        protected override void SetElement(int index, FloatParameter elementData, Animator animator)
        {
            animator.SetFloat(elementData.NameHash, elementData.Value);
        }
    }
}