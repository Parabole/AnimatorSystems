using System.Collections;
using System.Collections.Generic;
using Parabole.AnimatorSystems.Runtime;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class TestParameterSystem : JobComponentSystem
{
    private int boolHash;
    private int triggerHash;
    private int floatHash;
    private int intHash;

    protected override void OnCreate()
    {
        base.OnCreate();
        boolHash = Animator.StringToHash("TestBool");
        triggerHash = Animator.StringToHash("TestTrigger");
        floatHash = Animator.StringToHash("TestFloat");
        intHash = Animator.StringToHash("TestInt");
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return new TestJob
        {
            BoolHash = boolHash,
            TriggerHash = triggerHash,
            FloatHash = floatHash,
            IntHash = intHash
        }.Schedule(this, inputDeps);
    }

    private struct TestJob : IJobForEach_BBBB<BoolParameter, TriggerParameter, FloatParameter, IntParameter>
    {
        public int BoolHash;
        public int TriggerHash;
        public int FloatHash;
        public int IntHash;
        
        public void Execute(DynamicBuffer<BoolParameter> setBool, 
            DynamicBuffer<TriggerParameter> setTrigger, 
            DynamicBuffer<FloatParameter> setFloat,
            DynamicBuffer<IntParameter> setInteger)
        {
            
            BufferUtils.AddBool(BoolHash, true, setBool);
            BufferUtils.AddFloat(FloatHash, 99, setFloat);
            BufferUtils.AddInteger(IntHash, 77, setInteger);
            BufferUtils.AddTrigger(TriggerHash, setTrigger);
        }
    }
}
