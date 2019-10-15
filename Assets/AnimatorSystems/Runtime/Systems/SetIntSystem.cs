using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class SetIntSystem : SetBufferElementSystem<SetInt>
    {
        protected override void SetElement(int index, SetInt elementData, Animator animator)
        {
            animator.SetInteger(elementData.NameHash, elementData.Value);
        }
    }
}