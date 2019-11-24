using System;
using Unity.Entities;
using UnityEditor.Animations;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [GenerateAuthoringComponent]
    public class DotsAnimator : IComponentData
    {
        public Animator Animator;
        public AnimatorController OriginalController;
        public AnimatorOverrideCollection[] OverrideCollections;
    }
}