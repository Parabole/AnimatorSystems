using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public static class BufferUtils 
    {
        public static void AddFloatToBuffer(int hash, float value, DynamicBuffer<FloatParameter> buffer)
        {
            var element = new FloatParameter()
            {
                Parameter = hash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddBoolToBuffer(int hash, bool value, DynamicBuffer<BoolParameter> buffer)
        {
            var element = new BoolParameter()
            {
                Parameter = hash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddIntToBuffer (int hash, int value, DynamicBuffer<IntParameter> buffer)
        {
            var element = new IntParameter()
            {
                Parameter = hash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddTriggerToBuffer (int hash, bool value, DynamicBuffer<TriggerParameter> buffer)
        {
            var element = new TriggerParameter()
            {
                Parameter = hash,
                Value = value
            };
            buffer.Add(element);
        }
    }

}

