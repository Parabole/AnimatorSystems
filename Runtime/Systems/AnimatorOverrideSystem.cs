using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class AnimatorOverrideSystem : ComponentSystem
    {
        private EntityQueryDesc queryDesc;
        private EntityQuery query;

        protected override void OnCreate()
        {
            queryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] 
                {
                    ComponentType.ReadOnly<DotsAnimator>(),
                    ComponentType.ReadOnly<SetAnimatorOverride>() 
                }
            };
			
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((Entity entity, ref SetAnimatorOverride setOverride, DotsAnimator dotsAnimator) =>
            {
                var o = dotsAnimator.OverrideCollections[setOverride.CollectionIndex].Controllers[setOverride.ControllerIndex];
                dotsAnimator.Animator.runtimeAnimatorController = o;
                EntityManager.RemoveComponent<SetAnimatorOverride>(entity);
            });
        }
    }
}