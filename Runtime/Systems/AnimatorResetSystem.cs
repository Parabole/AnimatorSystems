using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
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
                    ComponentType.ReadOnly<DotsAnimator>(),
                    ComponentType.ReadOnly<SetOriginalAnimator>() 
                }
            };
		
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }
    
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((Entity entity, DotsAnimator dotsAnimator) =>
            {
                dotsAnimator.Animator.runtimeAnimatorController = dotsAnimator.OriginalController;
                EntityManager.RemoveComponent<SetOriginalAnimator>(entity);
            });
        }
    }
}


