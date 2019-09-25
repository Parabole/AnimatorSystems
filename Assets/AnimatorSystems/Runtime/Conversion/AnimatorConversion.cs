using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class AnimatorConversion : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private Animator _animator = null;
        
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

            var iBuffer = dstManager.AddBuffer<IntParameter>(entity);
            var fBuffer = dstManager.AddBuffer<FloatParameter>(entity);
            var bBuffer = dstManager.AddBuffer<BoolParameter>(entity);
            var tBuffer = dstManager.AddBuffer<TriggerParameter>(entity);
        }
    }
}