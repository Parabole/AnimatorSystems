using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public abstract class ParameterUpdateSystem<TB, TP> : ComponentSystem 
        where TB : struct, IBufferElementData 
        where TP : struct
    {
        private EntityQueryDesc m_QueryDesc;
        private EntityQuery m_Query;
 
        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            m_QueryDesc = new EntityQueryDesc
            {
                All = new ComponentType[] {typeof(Animator), typeof(TB)},
            };
            
            m_Query = GetEntityQuery(m_QueryDesc);
        }

        protected override void OnUpdate()
        {
            Entities.With(m_Query).ForEach((Entity entity, Animator animator, DynamicBuffer<TB> buffer) =>
            {
                foreach (var b in buffer)
                {
                    UpdateParameter(animator, b);
                }
                buffer.Clear();
            });
        }
        
       protected abstract void UpdateParameter(Animator animator, TB element);
    }
    
    // BOOL
    
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class BoolUpdateSystem : ParameterUpdateSystem<BoolParameter, bool>
    {
        protected override void UpdateParameter(Animator animator, BoolParameter element)
        {
            animator.SetBool(element.Parameter, element.Value);
        }
    }
    
    // FLOAT

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class FloatUpdateSystem : ParameterUpdateSystem<FloatParameter, float>
    {
        protected override void UpdateParameter(Animator animator, FloatParameter element)
        {
            animator.SetFloat(element.Parameter, element.Value);
        }
    }
    
    // INT
    
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class IntUpdateSystem : ParameterUpdateSystem<IntParameter, int>
    {
        protected override void UpdateParameter(Animator animator, IntParameter element)
        {
            animator.SetInteger(element.Parameter, element.Value);
        }
    }
    
    // TRIGGER
    
    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class TriggerUpdateSystem : ParameterUpdateSystem<TriggerParameter, float>
    {
        protected override void UpdateParameter(Animator animator, TriggerParameter element)
        {
            if (element.Value)
            {
                animator.SetTrigger(element.Parameter);
                element.Value = false;
            }
       
        }
    }
}