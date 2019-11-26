using System;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class AnimatorStateInfoInitializationSystem : JobComponentSystem
    {
        private EntityQuery query;
        private EntityCommandBufferSystem ecbSystem;
        
        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<DotsAnimator>(), 
                ComponentType.Exclude<UpdateStateInfo>());
            
            ecbSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
            RequireForUpdate(query);
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var cb = ecbSystem.CreateCommandBuffer();
            
            Entities.WithoutBurst().ForEach((Entity entity, DotsAnimator dotsAnimator) =>
            {
                if (!dotsAnimator.CreateStateInfoBuffer) return;

                var stateInfoBuffer = cb.AddBuffer<CurrentStateInfo>(entity);
                var stateInfoElement = new CurrentStateInfo();

                for (int i = 0; i < dotsAnimator.Animator.layerCount; i++)
                {
                    var info = dotsAnimator.Animator.GetCurrentAnimatorStateInfo(i);
                
                    stateInfoElement = new CurrentStateInfo
                    {
                        LayerIndex = i,
                        NormalizedTime = 0,
                        FullPathHash = info.fullPathHash,
                        ShortNameHash = info.shortNameHash,
                        IsLooping = info.loop,
                        Speed = info.speed,
                        SpeedMultiplier = info.speedMultiplier,
                        Length = info.length,
                        TagHash = info.tagHash
                    };

                    stateInfoBuffer.Add(stateInfoElement);
                }
                
                cb.AddComponent<UpdateStateInfo>(entity);
                
            }).WithNone<UpdateStateInfo>().Run();
            
            return default;
        }
    }
}