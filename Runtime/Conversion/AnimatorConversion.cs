using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Parabole.AnimatorSystems
{

    public class AnimatorConversion : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((AnimatorAuthoring animator) =>
            {
                var entity = GetPrimaryEntity(animator);
                
                DstEntityManager.AddComponentObject(entity, animator.Animator);
                
                var stateInfoBuffer = DstEntityManager.AddBuffer<StateInfo>(entity);
                var stateInfoElement = new StateInfo();
            
                for (int i = 0; i < animator.Animator.layerCount; i++)
                {
                    var info = animator.Animator.GetCurrentAnimatorStateInfo(i);
                
                    stateInfoElement = new StateInfo
                    {
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

                DstEntityManager.AddBuffer<IntParameter>(entity);
                DstEntityManager.AddBuffer<FloatParameter>(entity);
                DstEntityManager.AddBuffer<BoolParameter>(entity);
                DstEntityManager.AddBuffer<TriggerParameter>(entity);

                if (!animator.ConvertTransform)
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