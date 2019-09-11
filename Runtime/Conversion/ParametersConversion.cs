using System.Collections;
using System.Collections.Generic;
using Parabole.AnimatorSystems;
using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class ParametersConversion : MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private IntParameter[]  _intParameters;
        [SerializeField] private FloatParameter[] _floatParameters;
        [SerializeField] private BoolParameter[] _boolParameters;
        [SerializeField] private TriggerParameter[] _triggerParameters;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentObject(entity, _animator);
        
        // INT
        var intBuffer = dstManager.AddBuffer<AnimatorSystems.IntParameter>(entity);
        var intElement = new AnimatorSystems.IntParameter();

        foreach (var parameter in _intParameters)
        {
            intElement.Parameter = Animator.StringToHash(parameter.parameter);
            intElement.Value = parameter.value;
            intBuffer.Add(intElement);
        }

        // FLOAT
        var floatBuffer = dstManager.AddBuffer<AnimatorSystems.FloatParameter>(entity);
        var floatElement = new AnimatorSystems.FloatParameter();
        
        foreach (var parameter in _floatParameters)
        {
            floatElement.Parameter = Animator.StringToHash(parameter.parameter);
            floatElement.Value = parameter.value;
            floatBuffer.Add(floatElement);
        }
        
        // BOOL
        var boolBuffer = dstManager.AddBuffer<AnimatorSystems.BoolParameter>(entity);
        var boolElement = new AnimatorSystems.BoolParameter();
        
        foreach (var parameter in _boolParameters)
        {
            boolElement.Parameter = Animator.StringToHash(parameter.parameter);
            boolElement.Value = parameter.value;
            boolBuffer.Add(boolElement);
        }
        
        // TRIGGER
        var triggerBuffer = dstManager.AddBuffer<AnimatorSystems.TriggerParameter>(entity);
        var triggerElement = new AnimatorSystems.TriggerParameter();
        
        foreach (var parameter in _boolParameters)
        {
            triggerElement.Parameter = Animator.StringToHash(parameter.parameter);
            triggerElement.Value = parameter.value;
            triggerBuffer.Add(triggerElement);
        }
        
                
        #if UNITY_EDITOR
        dstManager.SetName(entity, "AnimatorSystems.Parameters" );
        #endif
    }

    [System.Serializable]
    class BaseParameter<T>
    {
        public string parameter;
        public T value;
    }

    [System.Serializable]
    class IntParameter : BaseParameter<int> {}
    
    [System.Serializable]
    class FloatParameter : BaseParameter<float> {}
    
    [System.Serializable]
    class BoolParameter : BaseParameter<bool> {}
    
    [System.Serializable]
    class TriggerParameter : BaseParameter<bool> {}
}

}

