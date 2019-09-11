using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class AnimatorConversion : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private Animator _animator;
        
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentObject(entity, _animator);

            var buffer = dstManager.AddBuffer<StateInfo>(entity);
            var element = new StateInfo();
            
            for (int i = 0; i < _animator.layerCount; i++)
            {
                var info = _animator.GetCurrentAnimatorStateInfo(i);
                
                element = new StateInfo
                {
                    FullPathHash = info.fullPathHash,
                    ShortNameHash = info.shortNameHash,
                    IsLooping = info.loop,
                    Speed = info.speed,
                    SpeedMultiplier = info.speedMultiplier,
                    Length = info.length,
                    TagHash = info.tagHash
                };

                buffer.Add(element);
            }
            
             #if UNITY_EDITOR
            dstManager.SetName(entity, "AnimatorSystems.StateInfo" );
            #endif
        }
    }
}