using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    /// <summary>
    /// Mirror the AnimatorStateInfo in DOTS.
    /// </summary>
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
	[UpdateAfter(typeof(AnimatorOverrideSystem))]
    public class StateInfoUpdateSystem : SystemBase
    {
        private EntityQuery query;

        protected override void OnCreate()
        {
            RequireForUpdate(query);
        }

        protected override void OnUpdate()
        {
            Entities.WithoutBurst().WithStoreEntityQueryInField(ref query).WithAll<UpdateStateInfo>()
                .ForEach((Entity entity , DynamicBuffer<CurrentStateInfo> buffer, DotsAnimator dotsAnimator) =>
            {
                for (var i = 0; i < buffer.Length; i++)
                {
                    var info = dotsAnimator.Animator.GetCurrentAnimatorStateInfo(i);

                    buffer[i] = new CurrentStateInfo
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
            }).Run();
        }
    }
}