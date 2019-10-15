using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    /// <summary>
    /// Mirror the AnimatorStateInfo in DOTS.
    /// </summary>
    [UpdateInGroup(typeof(AnimatorInitializationGroup))]
    public class StateInfoUpdateSystem : SetBufferElementSystem<CurrentStateInfo>
    {
        protected override void SetElement(int index, CurrentStateInfo elementData, Animator animator)
        {
            var info = animator.GetCurrentAnimatorStateInfo(index);
                    
            elementData = new CurrentStateInfo
            {
                NormalizedTime = info.normalizedTime,
                FullPathHash = info.fullPathHash,
                ShortNameHash = info.shortNameHash,
                IsLooping = info.loop,
                Speed = info.speed,
                SpeedMultiplier = info.speedMultiplier,
                Length = info.length,
                TagHash = info.tagHash
            };
        }
    }
}