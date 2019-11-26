using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public class SetLayerWeightSystem : JobComponentSystem
    {
        private EntityQuery query;

        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<DotsAnimator>(), 
                ComponentType.ReadWrite<SetLayerWeight>(),
                ComponentType.ReadOnly<UpdateLayers>());
            
            RequireForUpdate(query);
        }

        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            Entities.WithoutBurst().ForEach((DynamicBuffer<SetLayerWeight> buffer, DotsAnimator dotsAnimator) =>
            {
                if (buffer.Length > 0)
                {
                    for (var i = 0; i < buffer.Length; i++) dotsAnimator.Animator.SetLayerWeight(buffer[i].LayerIndex, buffer[i].LayerIndex);
                    buffer.Clear();
                }
            }).Run();
 
            return default;
        }
    }
}