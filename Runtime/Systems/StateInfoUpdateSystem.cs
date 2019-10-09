using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    /// <summary>
    /// Mirror the AnimatorStateInfo in DOTS
    /// </summary>
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class StateInfoUpdateSystem : ComponentSystem
    {
        
        private EntityQueryDesc m_QueryDesc;
        private EntityQuery m_Query;
        
        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            m_QueryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(UnityEngine.Animator), typeof(StateInfo)},
            };
            
            m_Query = GetEntityQuery(m_QueryDesc);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(m_Query).ForEach((Entity entity, UnityEngine.Animator animator, DynamicBuffer<StateInfo> buffer) =>
            {
                for (var i = 0; i < buffer.Length; i++)
                {
                    var info = animator.GetCurrentAnimatorStateInfo(i);
                    
                    buffer[i] = new StateInfo
                    {
                        NormalizedTime = info.normalizedTime,
                        FullPathHash = info.fullPathHash,
                        ShortNameHash = info.shortNameHash,
                        IsLooping = info.loop,
                        Speed = info.speed,
                        SpeedMultiplier = info.speedMultiplier,
                        Length = info.length,
                        TagHash = info.tagHash
                    };
                }
            });
        }
    }
}