using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public abstract class SetBufferElementSystem<TBufferElementData> : ComponentSystem
        where TBufferElementData : struct, IBufferElementData
    {
        private EntityQueryDesc queryDesc;
        private EntityQuery query;

        protected override void OnStartRunning()
        {
            Entities.ForEach<DotsAnimator>(Initialize);
            queryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] 
                {
                    ComponentType.ReadOnly<DotsAnimator>(),
                    ComponentType.ReadWrite<TBufferElementData>()
                }
            };
			
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }

        void Initialize(Entity entity, DotsAnimator animator)
        {
            EntityManager.AddBuffer<TBufferElementData>(entity);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((DynamicBuffer<TBufferElementData> buffer, DotsAnimator dotsAnimator) =>
            {
                if (buffer.Length > 0)
                {
                    for (var i = 0; i < buffer.Length; i++) SetElement(i, buffer[i], dotsAnimator);
                    buffer.Clear();
                }
            });
        }

        protected abstract void SetElement(int index, TBufferElementData elementData, DotsAnimator dotsAnimator);
    }
}