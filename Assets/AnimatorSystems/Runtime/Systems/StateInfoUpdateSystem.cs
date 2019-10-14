using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    /// <summary>
    /// Mirror the AnimatorStateInfo in DOTS.
    /// </summary>
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class StateInfoUpdateSystem : GenericElementUpdater<CurrentStateInfo>
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