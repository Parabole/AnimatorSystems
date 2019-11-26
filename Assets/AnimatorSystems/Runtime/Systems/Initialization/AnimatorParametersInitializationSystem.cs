using System;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [AlwaysSynchronizeSystem]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class AnimatorParametersInitializationSystem : JobComponentSystem
    {
        private EntityQuery query;
        private EntityCommandBufferSystem ecbSystem;
        
        protected override void OnCreate()
        {
            query = GetEntityQuery(
                ComponentType.ReadOnly<DotsAnimator>(), 
                ComponentType.Exclude<UpdateParameters>());
            
            ecbSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
            RequireForUpdate(query);
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var cb = ecbSystem.CreateCommandBuffer();
            
            Entities.WithoutBurst().ForEach((Entity entity, DotsAnimator dotsAnimator) =>
            {
                if (!dotsAnimator.CreateParametersBuffers) return;
                
                bool hasFloat = false;
                bool hasInt = false;
                bool hasBool = false;
                bool hasTrigger = false;
            
                foreach (var parameter in dotsAnimator.Animator.parameters)
                {
                    switch (parameter.type)
                    {
                        case AnimatorControllerParameterType.Float:
                            hasFloat = true;
                            break;
                        case AnimatorControllerParameterType.Int:
                            hasInt = true;
                            break;
                        case AnimatorControllerParameterType.Bool:
                            hasBool = true;
                            break;
                        case AnimatorControllerParameterType.Trigger:
                            hasTrigger = true;
                            break;
                    }
                }
            
                // Adding the buffers
                if (hasFloat) cb.AddBuffer<SetFloat>(entity);
                if (hasInt) cb.AddBuffer<SetInt>(entity);
                if (hasBool) cb.AddBuffer<SetBool>(entity);
                if (hasTrigger) cb.AddBuffer<SetTrigger>(entity);
                
                cb.AddComponent<UpdateParameters>(entity);
                
            }).WithNone<UpdateParameters>().Run();
            
            return default;
        }

    }
}