using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    [UpdateInGroup(typeof(SetParameterGroup))]
    public abstract class SetParameterSystem<TBufferElementData> : ComponentSystem
        where TBufferElementData : struct, IBufferElementData
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
                    ComponentType.ReadWrite<DynamicBuffer<TBufferElementData>>()
                }
            };
			
            query = GetEntityQuery(queryDesc);
            RequireForUpdate(query);
        }
        
        protected override void OnUpdate()
        {
            Entities.With(query).ForEach((DynamicBuffer<TBufferElementData> buffer, Animator animator) =>
            {
                foreach (var e in buffer) SetParameter(e, animator);
                buffer.Clear();
            });
        }

        protected abstract void SetParameter(TBufferElementData elementData, Animator animator);
    }
}