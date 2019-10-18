using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    /// <summary>
    /// Mirror the AnimatorStateInfo in DOTS.
    /// </summary>
    [UpdateInGroup(typeof(AnimatorInitializationGroup))]
    public class StateInfoUpdateSystem : ComponentSystem
    {
        private EntityQueryDesc queryDesc;
        private EntityQuery query;

        protected override void OnCreate()
        {
            base.OnCreate();
            queryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] 
                {
                    ComponentType.ReadOnly<AnimatorTag>(),
                    ComponentType.ReadOnly<Animator>(), 
                    ComponentType.ReadWrite<CurrentStateInfo>()
                }
            };
			
            query = GetEntityQuery(queryDesc);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((DynamicBuffer<CurrentStateInfo> buffer, Animator animator) =>
            {
                for (var i = 0; i < buffer.Length; i++)
                {
                    var info = animator.GetCurrentAnimatorStateInfo(i);
                
                    buffer[i] = new CurrentStateInfo
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