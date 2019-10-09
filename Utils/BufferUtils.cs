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
        public static void AddFloat(int nameHash, float value, DynamicBuffer<SetFloat> buffer)
        {
            var element = new SetFloat()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddBool(int nameHash, bool value, DynamicBuffer<SetBool> buffer)
        {
            var element = new SetBool()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddInteger (int nameHash, int value, DynamicBuffer<SetInteger> buffer)
        {
            var element = new SetInteger()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
        public static void AddTrigger (int nameHash, bool value, DynamicBuffer<SetTrigger> buffer)
        {
            var element = new SetTrigger()
            {
                NameHash = nameHash,
                Value = value
            };
            buffer.Add(element);
        }
        
    }

}

