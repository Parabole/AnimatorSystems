using System.Collections;
using System.Collections.Generic;
using Parabole.AnimatorSystems.Runtime;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class TestSystem : JobComponentSystem
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

    private struct TestJob : IJobForEach_BBBB<SetBool, SetTrigger, SetFloat, SetInteger>
    {
        public int BoolHash;
        public int TriggerHash;
        public int FloatHash;
        public int IntHash;
        
        public void Execute(DynamicBuffer<SetBool> setBool, 
            DynamicBuffer<SetTrigger> setTrigger, 
            DynamicBuffer<SetFloat> setFloat,
            DynamicBuffer<SetInteger> setInteger)
        {
            
            BufferUtils.AddBool(BoolHash, true, setBool);
            BufferUtils.AddFloat(FloatHash, 99, setFloat);
            BufferUtils.AddInteger(IntHash, 77, setInteger);
            BufferUtils.AddTrigger(TriggerHash, true, setTrigger);
        }
    }
}
