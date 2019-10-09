using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
/// <summary>
/// Builds the Animator Entity.
/// - Would probably better be split into more granular
/// - Maybe having an archetype and not Adding/Removing components during conversion would be better / more efficient
/// </summary>
    public class AnimatorConversion : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((AnimatorAuthoring animator) =>
            {
                var entity = GetPrimaryEntity(animator);
                
                DstEntityManager.AddComponentObject(entity, animator.Animator);

                if (animator.HasStateInfo)
                {
                    var stateInfoBuffer = DstEntityManager.AddBuffer<StateInfo>(entity);
                    var stateInfoElement = new StateInfo();
            
                    for (int i = 0; i < animator.Animator.layerCount; i++)
                    {
                        var info = animator.Animator.GetCurrentAnimatorStateInfo(i);
                
                        stateInfoElement = new StateInfo
                        {
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
                }
               
                if (animator.HasIntPameters) 
                    DstEntityManager.AddBuffer<IntParameter>(entity);
                
                if (animator.HasFloatParameter) 
                    DstEntityManager.AddBuffer<FloatParameter>(entity);
                
                if (animator.HasBoolParameters) 
                    DstEntityManager.AddBuffer<BoolParameter>(entity);
                
                if (animator.HasTriggerParameters) 
                    DstEntityManager.AddBuffer<TriggerParameter>(entity);

                if (!animator.HasTransformComponents)
                {
                    DstEntityManager.RemoveComponent<Rotation>(entity);
                    DstEntityManager.RemoveComponent<Translation>(entity);
                    DstEntityManager.RemoveComponent<LocalToWorld>(entity);
                }
               
                #if UNITY_EDITOR
                DstEntityManager.SetName(entity, "Animator");
                #endif
            });
        }
    }
}