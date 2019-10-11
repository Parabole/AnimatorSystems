using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems.Runtime
{
    /// <summary>
    /// Helpers to add buffer elements
    /// </summary>
    public static class BufferUtils 
    {
        public static void AddFloat(int nameHash, float value, DynamicBuffer<FloatParameter> buffer)
        {
            var element = new FloatParameter()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddBool(int nameHash, bool value, DynamicBuffer<BoolParameter> buffer)
        {
            var element = new BoolParameter()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddInteger (int nameHash, int value, DynamicBuffer<IntParameter> buffer)
        {
            var element = new IntParameter()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddTrigger (int nameHash, DynamicBuffer<TriggerParameter> buffer)
        {
            var element = new TriggerParameter()
            {
                NameHash = nameHash,
                Value = true
            };
            buffer.Add(element);
        }
        
    }

}

