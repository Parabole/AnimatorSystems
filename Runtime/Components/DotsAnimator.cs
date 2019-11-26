using System;
using Unity.Entities;
using UnityEditor.Animations;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
    public struct DotsAnimator : ISharedComponentData, IEquatable<DotsAnimator>
    {
        public Animator Animator;
        public RuntimeAnimatorController OriginalController;
        public AnimatorOverrideCollection[] OverrideCollections;

        public bool Equals(DotsAnimator other)
        {
            return Equals(Animator, other.Animator) && Equals(OriginalController, other.OriginalController) && Equals(OverrideCollections, other.OverrideCollections);
        }

        public override bool Equals(object obj)
        {
            return obj is DotsAnimator other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Animator != null ? Animator.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OriginalController != null ? OriginalController.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OverrideCollections != null ? OverrideCollections.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}