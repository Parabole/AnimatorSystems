using Parabole.AnimatorSystems;
using Unity.Entities;
using UnityEngine;
using System;

namespace AnimatorSystems.Runtime.Authoring
{
    public class AnimatorAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public Animator Animator = null;
        public AnimatorOverrideCollection[] OverrideCollections;
        
        [Space(3)]
        [Header("Buffers")]
        public bool UseFloatBuffer = true;
        public bool UseIntBuffer = true;
        public bool UseBoolBuffer = true;
        public bool UseTriggerBuffer = true;
        public bool UseLayersBuffer = true;
        public bool UseStateInfoBuffer = true;
        
        private RuntimeAnimatorController originalController = null;      
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            originalController = Animator.runtimeAnimatorController;
            
            // Animator
            var dotsAnimator = new DotsAnimator
            {
                Animator = Animator,
                OriginalController =  originalController,
                OverrideCollections = OverrideCollections
            };
            dstManager.AddSharedComponentData(entity, dotsAnimator);

            // Parameters
            if (UseFloatBuffer || UseIntBuffer || UseIntBuffer || UseBoolBuffer || UseTriggerBuffer)
            {
                dstManager.AddComponent<UpdateParameters>(entity);
                if (UseFloatBuffer) dstManager.AddBuffer<SetFloat>(entity);
                if (UseIntBuffer) dstManager.AddBuffer<SetInt>(entity);
                if (UseBoolBuffer) dstManager.AddBuffer<SetBool>(entity);
                if (UseTriggerBuffer) dstManager.AddBuffer<SetTrigger>(entity);
            }
            
            // Layers
            if (UseLayersBuffer) {
                dstManager.AddBuffer<SetLayerWeight>(entity);
                dstManager.AddComponent<UpdateLayers>(entity);}

            // State Info
            if (UseStateInfoBuffer)
            {
                dstManager.AddComponent<UpdateStateInfo>(entity);
            }
        }
        
    }
}