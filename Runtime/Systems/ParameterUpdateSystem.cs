using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public abstract class ParameterUpdateSystem: ComponentSystem 
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
                    typeof(Animator),
                    typeof(AnimatorTag)
                }
            };
            
            m_Query = GetEntityQuery(m_QueryDesc);
        }

        protected override void OnUpdate()
        {
            Entities.With(m_Query).ForEach((Entity entity, Animator animator) =>
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
                
                floatBuffer.Clear();
                intBuffer.Clear();
                boolBuffer.Clear();
                triggerBuffer.Clear();
            });
        }
    }
}