using AnimatorSystems.Runtime;
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
            Entities.ForEach((AnimatorAuthoring authoring) =>
            {
                var entity = GetPrimaryEntity(authoring);
                DstEntityManager.AddComponentObject(entity, authoring.Animator);
                DstEntityManager.AddComponent<AnimatorTag>(entity);

                if (authoring.UpdateLayers)
                    AddBufferToEntity<SetLayerWeight>(entity);
                
                if (authoring.OverridesContainer != null)
                    AddOverrides(authoring.OverridesContainer, entity);
                
                if (authoring.UpdateStateInfo)
                    AddStateInfo(authoring.Animator, entity);
                
                if (authoring.UpdateParameters) 
                    AddParameterBuffers(authoring.Animator, entity);
                
                if (!authoring.UpdateTransform) 
                    RemoveTransformComponents(entity);

                #if UNITY_EDITOR
                DstEntityManager.SetName(entity, "Animator");
                #endif
            });
        }

        /// <summary>
        /// Store a list of override controllers to later set them using OverrideAnimatorController component
        /// </summary>
        private void AddOverrides(AnimatorOverridesContainer controllersContainer, Entity entity)
        {
            if (controllersContainer.Controllers.Length == 0) return;
            DstEntityManager.AddComponentObject(entity, controllersContainer);
        }

        /// <summary>
        /// Add StateInfo to the entity for reading in other systems
        /// May later be split in more granular components.
        /// </summary>
        private void AddStateInfo(Animator animator, Entity entity)
        {
            var stateInfoBuffer = DstEntityManager.AddBuffer<CurrentStateInfo>(entity);
            var stateInfoElement = new CurrentStateInfo();

            for (int i = 0; i < animator.layerCount; i++)
            {
                var info = animator.GetCurrentAnimatorStateInfo(i);
                
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

        /// <summary>
        /// Loop through all parameters found on the animator and create parameters buffer if necessary
        /// </summary>
        private void AddParameterBuffers(Animator animator, Entity entity)
        {
            var hasBool = false;
            var hasTrigger = false;
            var hasInt = false;
            var hasFloat = false;
                    
            foreach (var p in animator.parameters)
            {
                switch (p.type)
                {
                    case AnimatorControllerParameterType.Bool:
                        if (!hasBool) hasBool = AddBufferToEntity<SetBool>(entity);
                        break;
                            
                    case AnimatorControllerParameterType.Trigger:
                        if (!hasTrigger) hasTrigger = AddBufferToEntity<SetTrigger>(entity);
                        break;
                            
                    case AnimatorControllerParameterType.Int:
                        if (!hasInt) hasInt = AddBufferToEntity<SetInt>(entity);
                        break;
                            
                    case AnimatorControllerParameterType.Float:
                        if (!hasFloat) hasFloat = AddBufferToEntity<SetFloat>(entity);
                        break;
                }
            }
        }
        
        /// <summary>
        /// Add the buffer 
        /// </summary>
        private bool AddBufferToEntity<T>(Entity entity) where T : struct, IBufferElementData
        {
            DstEntityManager.AddBuffer<T>(entity);
            return true;
        }
    }
}