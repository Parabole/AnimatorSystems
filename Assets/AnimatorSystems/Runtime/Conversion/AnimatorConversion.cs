using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
/// <summary>
/// Builds the Animator Entity.
/// </summary>
    public class AnimatorConversion : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((AnimatorAuthoring animator) =>
            {
                var entity = GetPrimaryEntity(animator);
                DstEntityManager.AddComponentObject(entity, animator.Animator);

                if (animator.AddStateInfo)
                    AddStateInfo(animator.Animator, entity);
                
                if (animator.AddSetParameters) 
                    InitializeParameters(animator.Animator, entity);
                
                if (!animator.AddTransformComponents) 
                    RemoveTransformComponents(entity);
               
                #if UNITY_EDITOR
                DstEntityManager.SetName(entity, "Animator");
                #endif
            });
        }

        /// <summary>
        /// Add StateInfo to the entity for reading in other systems
        /// May later be split in more granulal components.
        /// </summary>
        private void AddStateInfo(Animator animator, Entity entity)
        {
            var stateInfoBuffer = DstEntityManager.AddBuffer<StateInfo>(entity);
            var stateInfoElement = new StateInfo();

            for (int i = 0; i < animator.layerCount; i++)
            {
                var info = animator.GetCurrentAnimatorStateInfo(i);
                
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

        /// <summary>
        /// Remove useless transform components added during Unity black boxed conversion
        /// </summary>
        private void RemoveTransformComponents(Entity entity)
        {
            DstEntityManager.RemoveComponent<Rotation>(entity);
            DstEntityManager.RemoveComponent<Translation>(entity);
            DstEntityManager.RemoveComponent<LocalToWorld>(entity);
        }

        public void InitializeParameters(Animator animator, Entity entity)
        {
            // Create buffer to hold the values
            var pHashBuffer = DstEntityManager.AddBuffer<ParameterHash>(entity);
            var boolBuffer = DstEntityManager.AddBuffer<BoolParameter>(entity);
            var triggerBuffer = DstEntityManager.AddBuffer<TriggerParameter>(entity);
            var floatBuffer = DstEntityManager.AddBuffer<FloatParameter>(entity);
            var intBuffer = DstEntityManager.AddBuffer<IntParameter>(entity);
            
            // Populate the buffers with values
            for (int i = 0; i < animator.parameterCount; i++)
            {
                var p = animator.parameters[i];
                var index = 0;
                
                switch (p.type)
                {
                    case AnimatorControllerParameterType.Bool:
                        index = boolBuffer.Add(new BoolParameter
                        {
                            NameHash = p.nameHash,
                            Value = p.defaultBool
                        });
                        break;
                            
                    case AnimatorControllerParameterType.Trigger:
                        index = triggerBuffer.Add(new TriggerParameter
                        {
                            NameHash = p.nameHash,
                            Value = p.defaultBool
                        });
                        break;
                            
                    case AnimatorControllerParameterType.Int:
                        index = intBuffer.Add(new IntParameter
                        {
                            NameHash = p.nameHash,
                            Value = p.defaultInt
                        });
                        break;
                            
                    case AnimatorControllerParameterType.Float:
                        index = floatBuffer.Add(new FloatParameter
                        {
                            NameHash = p.nameHash,
                            Value = p.defaultFloat
                        });
                        break;
                }
                
                // Set the ParameterHash to later retrieve the new index
                // Since we follow the Animator parameter array order...
                // ...the dBuffer index corresponds to its origin index
                pHashBuffer.Add(new ParameterHash
                {
                    Hash = p.nameHash,
                    IndexInBuffer = index
                });
            }
        }
    }
}