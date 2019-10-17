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
        public Animator AnimatorToOverride = null;
        [HideInInspector] public AnimatorOverrideController OriginalController;
        public AnimatorOverrideController[] Controllers;

        private void Awake()
        {
            if (AnimatorToOverride == null)
            {
                Debug.LogError("The override container requires an Animator in order to operate.");
                return;
            }
            
            OriginalController = AnimatorToOverride.runtimeAnimatorController as AnimatorOverrideController;  
        }
    }
}