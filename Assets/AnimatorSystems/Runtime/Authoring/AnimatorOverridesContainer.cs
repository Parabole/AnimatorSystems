using System;
using UnityEngine;

namespace AnimatorSystems.Runtime
{
    /// <summary>
    /// Stores a list of override controllers.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimatorOverridesContainer : MonoBehaviour
    {
        [HideInInspector] public AnimatorOverrideController OriginalController;
        public AnimatorOverrideController[] Controllers;

        private void Awake()
        {
            var animator = GetComponent<Animator>();
            OriginalController = new AnimatorOverrideController(animator.runtimeAnimatorController);  
        }
    }
}