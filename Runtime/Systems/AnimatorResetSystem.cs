using AnimatorSystems.Runtime;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(AnimatorControllerGroup))]
    public class AnimatorResetSystem : ComponentSystem
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
                    ComponentType.ReadOnly<SetOriginalAnimator>() 
                }
            };
		
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }
    
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((Animator animator, AnimatorOverridesContainer overrides) =>
            {
                animator.runtimeAnimatorController = overrides.OriginalController;
            });
        }
    }
}


