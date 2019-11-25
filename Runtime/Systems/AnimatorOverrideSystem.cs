using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class AnimatorOverrideSystem : JobComponentSystem
    {
        private EntityQuery query;
        private EntityCommandBufferSystem ecbSystem;

        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<SetAnimatorOverride>(),
                ComponentType.ReadOnly<DotsAnimator>());
            RequireForUpdate(query);
            
            ecbSystem = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var cb = ecbSystem.CreateCommandBuffer();
            
            Entities.WithoutBurst().ForEach((Entity entity , DotsAnimator dotsAnimator, ref SetAnimatorOverride setOverride) =>
            {
                var o = dotsAnimator.OverrideCollections[setOverride.CollectionIndex].Controllers[setOverride.ControllerIndex];
                dotsAnimator.Animator.runtimeAnimatorController = o;
                cb.RemoveComponent<SetAnimatorOverride>(entity);
            }).Run();

            return default;
        }
    }
}