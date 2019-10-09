using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

/// <summary>
/// Conversion of the Animator component
/// so that Other DOTS systems may communicate with it.
/// </summary>
[RequiresEntityConversion]
public class AnimatorAuthoring : MonoBehaviour
{
    [Tooltip("If set to ConvertAndDestroy, do not link an animator that is on the object to be destroyed.")]
    public Animator Animator = null;

    [Tooltip("Enable if you expect other systems to read the AnimatorStateInfo.")]
    public bool HasStateInfo = true;
    
    [Tooltip("Enable if you expect other systems to update some int parameters on the Animator.")]
    public bool HasIntPameters = true;
    
    [Tooltip("Enable if you expect other systems to update some float parameters on the Animator.")]
    public bool HasFloatParameter = true;
    
    [Tooltip("Enable if you expect other systems to update some bool parameters on the Animator.")]
    public bool HasBoolParameters = true;
    
    [Tooltip("Enable if you expect other systems to update some bool parameters on the Animator.")]
    public bool HasTriggerParameters = true;
    
    [Tooltip("Enable if you want this entity to have rotation, local to world and translation components.")]
    public bool HasTransformComponents = false;
}
