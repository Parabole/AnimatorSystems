using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[RequiresEntityConversion]
public class AnimatorAuthoring : MonoBehaviour
{
    public Animator Animator = null;
    public bool ConvertTransform = false;
}
