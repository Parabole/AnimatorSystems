using Parabole.AnimatorSystems;
using Unity.Entities;
using UnityEditor.Animations;
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
            if (UseFloatBuffer) dstManager.AddBuffer<SetFloat>(entity);
            if (UseIntBuffer) dstManager.AddBuffer<SetInt>(entity);
            if (UseBoolBuffer) dstManager.AddBuffer<SetBool>(entity);
            if (UseTriggerBuffer) dstManager.AddBuffer<SetTrigger>(entity);
            
            // Layers
            if (UseLayersBuffer) {
                dstManager.AddBuffer<SetLayerWeight>(entity);
                dstManager.AddComponent<UpdateLayers>(entity);}

            // State Info
            if (UseStateInfoBuffer)
            {
                var stateInfoBuffer = dstManager.AddBuffer<CurrentStateInfo>(entity);
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
                
                dstManager.AddComponent<UpdateStateInfo>(entity);
            }
        }
        
    }
}