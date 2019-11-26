using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    /// <summary>
    /// Mirror the AnimatorStateInfo in DOTS.
    /// </summary>
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class StateInfoUpdateSystem : JobComponentSystem
    {
        private EntityQuery query;

        protected override void OnCreate()
        {
            base.OnCreate();
            query = GetEntityQuery(
                ComponentType.ReadOnly<DotsAnimator>(),
                ComponentType.ReadWrite<CurrentStateInfo>(),
                ComponentType.ReadOnly<UpdateStateInfo>());
            
            RequireForUpdate(query);
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Entities.WithoutBurst().ForEach((Entity entity , DynamicBuffer<CurrentStateInfo> buffer, DotsAnimator dotsAnimator) =>
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

            return default;
        }
    }
}