using Parabole.AnimatorSystems;
using Unity.Entities;
using UnityEditor.Animations;
using UnityEngine;

namespace AnimatorSystems.Runtime.Authoring
{
    public class AnimatorAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public Animator Animator = null;
        public AnimatorOverrideCollection[] OverrideCollections = null;
        
        public bool CreateParametersBuffers = true;
        public bool CreateLayersBuffer = true;
        public bool CreateStateInfoBuffer = true; 
        
        private RuntimeAnimatorController originalController = null;      
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            originalController = Animator.runtimeAnimatorController;
            
            var dotsAnimator = new DotsAnimator
                {
                    Animator = Animator,
                    OriginalController =  originalController,
                    OverrideCollections = OverrideCollections
                };

            if (CreateParametersBuffers) InitializeParameters(entity, dstManager);
            if (CreateLayersBuffer) InitializeLayers(entity, dstManager);
            if (CreateStateInfoBuffer) InitializeStateInfo(entity, dstManager);
            
            dstManager.AddComponentData(entity, dotsAnimator);
        }


        /// <summary>
        /// Create parameters buffers
        /// </summary>
        private void InitializeParameters(Entity entity, EntityManager manager)
        {
            bool hasFloat = false;
            bool hasInt = false;
            bool hasBool = false;
            bool hasTrigger = false;
        
            foreach (var parameter in Animator.parameters)
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
        
            if (hasFloat) manager.AddBuffer<SetFloat>(entity);
            if (hasInt) manager.AddBuffer<SetInt>(entity);
            if (hasBool) manager.AddBuffer<SetBool>(entity);
            if (hasTrigger) manager.AddBuffer<SetTrigger>(entity);
            
            manager.AddComponent<UpdateParameters>(entity);
        }
        
        /// <summary>
        /// Create Layers buffer
        /// </summary>
        private void InitializeLayers(Entity entity, EntityManager manager)
        {
            manager.AddBuffer<SetLayerWeight>(entity);
            manager.AddComponent<UpdateLayers>(entity);
        }
        
        /// <summary>
        /// Create state info buffer
        /// </summary>
        private void InitializeStateInfo(Entity entity, EntityManager manager)
        {
            var stateInfoBuffer = manager.AddBuffer<CurrentStateInfo>(entity);
            var stateInfoElement = new CurrentStateInfo();

            for (int i = 0; i < Animator.layerCount; i++)
            {
                var info = Animator.GetCurrentAnimatorStateInfo(i);
                
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
                
            manager.AddComponent<UpdateStateInfo>(entity);
        }
        
    }
}