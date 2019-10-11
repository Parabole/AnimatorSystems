using System;
using System.Collections;
using System.Collections.Generic;
using AnimatorSystems.Runtime;
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
    
    [Tooltip("Set if you wish to change the controller at runtime. AnimatorOverridesContainer needs to be attached to the Animator GameObject.")]
    public AnimatorOverridesContainer OverridesContainer;
    
    [Tooltip("Enable if you expect other systems to update layers on the Animator.")]
    public bool UpdateLayers = true;

    [Tooltip("Enable if you expect other systems to read StateInfo from the Animator.")]
    public bool UpdateStateInfo = true;
    
    [Tooltip("Enable if you expect other systems to get parameters values from the Animator.")]
    public bool UpdateParameters = true;

    [Tooltip("Enable if you want this entity to have rotation, local to world and translation components.")]
    public bool UpdateTransform = false;
}
