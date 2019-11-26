using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class AnimatorResetSystem : JobComponentSystem
    {
        private EntityQuery query;
        private EntityCommandBufferSystem ecbSystem;

        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<SetOriginalAnimator>(),
                ComponentType.ReadOnly<DotsAnimator>());
            
            ecbSystem = World.GetOrCreateSystem<BeginPresentationEntityCommandBufferSystem>();
            RequireForUpdate(query);
        }
 
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var cb = ecbSystem.CreateCommandBuffer();
            
            Entities.WithoutBurst().ForEach((Entity entity , DotsAnimator dotsAnimator) =>
            {
                dotsAnimator.Animator.runtimeAnimatorController = dotsAnimator.OriginalController;
                cb.RemoveComponent<SetOriginalAnimator>(entity);
            }).Run();

            return default;
        }
    }
}


