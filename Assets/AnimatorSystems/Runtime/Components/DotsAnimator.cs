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
        public RuntimeAnimatorController OriginalController;
        public AnimatorOverrideCollection[] OverrideCollections;

        public bool CreateParametersBuffers;
        public bool CreateLayersBuffer;
        public bool CreateStateInfoBuffer;
    }
}