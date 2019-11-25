using System;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class AnimatorLayersInitializationSystem : JobComponentSystem
    {
        private EntityQuery query;
        private EntityCommandBufferSystem ecbSystem;
        
        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<DotsAnimator>(), 
                ComponentType.Exclude<UpdateLayers>());
            
            ecbSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
            RequireForUpdate(query);
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var cb = ecbSystem.CreateCommandBuffer();
            
            Entities.WithoutBurst().ForEach((Entity entity, DotsAnimator dotsAnimator) =>
            {
                if (!dotsAnimator.CreateLayersBuffer) return;

                cb.AddBuffer<SetLayerWeight>(entity);
                cb.AddComponent<UpdateLayers>(entity);
                
            }).WithNone<UpdateLayers>().Run();
            
            return default;
        }

    }
}