using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    /// <summary>
    /// Receives "orders" to set parameters of the animator
    /// Currently 16 directives by type are supported
    /// To add more, modify the internal buffer size of each component
    /// </summary>
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class ParameterUpdateSystem: ComponentSystem 
    {
        private EntityQueryDesc m_QueryDesc;
        private EntityQuery m_Query;
 
        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            m_QueryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] 
                {
                    ComponentType.ReadOnly<Animator>(), 
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<FloatParameter>(),
                    ComponentType.ReadOnly<IntParameter>(),
                    ComponentType.ReadOnly<BoolParameter>(),
                    ComponentType.ReadOnly<TriggerParameter>()
                }
            };
            
            m_Query = GetEntityQuery(m_QueryDesc);
        }

        protected override void OnUpdate()
        {
            Entities.With(m_Query).ForEach((Entity entity, UnityEngine.Animator animator) =>
            {
                var floatBuffer = EntityManager.GetBuffer<FloatParameter>(entity);
                var intBuffer = EntityManager.GetBuffer<IntParameter>(entity);
                var boolBuffer = EntityManager.GetBuffer<BoolParameter>(entity);
                var triggerBuffer = EntityManager.GetBuffer<TriggerParameter>(entity);
                
                foreach (var e in floatBuffer)
                {
                    animator.SetFloat(e.Parameter, e.Value);
                }
                
                foreach (var e in intBuffer)
                {
                    animator.SetInteger(e.Parameter, e.Value);
                }
                
                foreach (var e in boolBuffer)
                {
                    animator.SetBool(e.Parameter, e.Value);
                }

                foreach (var e in triggerBuffer)
                {
                    animator.SetTrigger(e.Parameter);
                }
            });
        }
    }
}