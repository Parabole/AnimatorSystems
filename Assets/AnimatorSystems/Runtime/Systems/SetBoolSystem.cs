using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class SetBoolSystem : SetBufferElementSystem<SetBool>
    {
        protected override void SetElement(int index, SetBool elementData, Animator animator)
        {
            animator.SetBool(elementData.NameHash, elementData.Value);
        }
    }
}