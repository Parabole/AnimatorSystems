using System;
using Unity.Entities;
using UnityEditor.Animations;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public class DotsAnimator : IComponentData
    {
        public Animator Animator;
        public RuntimeAnimatorController OriginalController;
        public AnimatorOverrideCollection[] OverrideCollections;
    }
}