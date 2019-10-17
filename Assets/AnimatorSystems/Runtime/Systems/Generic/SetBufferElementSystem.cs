using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public abstract class SetBufferElementSystem<TBufferElementData> : ComponentSystem
        where TBufferElementData : struct, IBufferElementData
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
                    ComponentType.ReadWrite<TBufferElementData>()
                }
            };
			
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((DynamicBuffer<TBufferElementData> buffer, Animator animator) =>
            {
                if (buffer.Length > 0)
                {
                    for (var i = 0; i < buffer.Length; i++) SetElement(i, buffer[i], animator);
                    buffer.Clear();
                }
            });
        }

        protected abstract void SetElement(int index, TBufferElementData elementData, Animator animator);
    }
}