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
    
    [Header("Add to Entity")]
    [Tooltip("Enable if you expect other systems to update layers on the Animator.")]
    public bool AddLayers = true;

    [Tooltip("Enable if you expect other systems to read StateInfo from the Animator.")]
    public bool AddStateInfo = true;
    
    [Tooltip("Enable if you expect other systems to get parameters values from the Animator.")]
    public bool AddGetParameters = true;
    
    [Tooltip("Enable if you expect other systems to set parameters on the Animator.")]
    public bool AddSetParameters = true;
    
    [Tooltip("Enable if you want this entity to have rotation, local to world and translation components.")]
    public bool AddTransformComponents = false;
}
