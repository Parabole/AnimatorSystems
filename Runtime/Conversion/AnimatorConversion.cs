using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class AnimatorConversion : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private Animator _animator;
        
        public virtual void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentObject(entity, _animator);

            var stateInfoBuffer = dstManager.AddBuffer<StateInfo>(entity);
            var stateInfoElement = new StateInfo();
            
            for (int i = 0; i < _animator.layerCount; i++)
            {
                var info = _animator.GetCurrentAnimatorStateInfo(i);
                
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

            dstManager.AddBuffer<IntParameter>(entity);
            dstManager.AddBuffer<FloatParameter>(entity);
            dstManager.AddBuffer<BoolParameter>(entity);
            dstManager.AddBuffer<TriggerParameter>(entity);
            
             #if UNITY_EDITOR
            dstManager.SetName(entity, "AnimatorSystems.Animator" );
            #endif
        }
    }
}