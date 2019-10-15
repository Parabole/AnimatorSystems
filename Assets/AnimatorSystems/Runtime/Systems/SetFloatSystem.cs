using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class SetFloatSystem : SetBufferElementSystem<SetFloat>
    {
        protected override void SetElement(int index, SetFloat elementData, Animator animator)
        {
            animator.SetFloat(elementData.NameHash, elementData.Value);
        }
    }
}