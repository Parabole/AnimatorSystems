using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public class SetIntSystem : JobComponentSystem
    {
        private EntityQuery query;

        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<DotsAnimator>(), 
                ComponentType.ReadWrite<SetInt>(),
                ComponentType.ReadOnly<UpdateParameters>());
            
            RequireForUpdate(query);
        }

        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            Entities.WithoutBurst().ForEach((DynamicBuffer<SetInt> buffer, DotsAnimator dotsAnimator) =>
            {
                if (buffer.Length > 0)
                {
                    for (var i = 0; i < buffer.Length; i++) dotsAnimator.Animator.SetInteger(buffer[i].NameHash, buffer[i].Value);
                    buffer.Clear();
                }
            }).Run();
 
            return default;
        }
    }
}