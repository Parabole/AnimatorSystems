using AnimatorSystems.Runtime;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(AnimatorOverrideGroup))]
    public class AnimatorOverrideSystem : ComponentSystem
    {
        private EntityQueryDesc queryDesc;
        private EntityQuery query;

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            queryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] 
                {
                    ComponentType.ReadOnly<Animator>(),
                    ComponentType.ReadOnly<AnimatorOverridesContainer>(),
                    ComponentType.ReadOnly<SetAnimatorOverride>() 
                }
            };
			
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((Entity entity, ref SetAnimatorOverride setOverride, Animator animator, AnimatorOverridesContainer overrides) =>
            {
                var o = overrides.Controllers[setOverride.Index];
                animator.runtimeAnimatorController = o;
                EntityManager.RemoveComponent<SetAnimatorOverride>(entity);
            });
        }
    }
}