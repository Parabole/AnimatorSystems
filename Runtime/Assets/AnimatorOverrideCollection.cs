using UnityEngine;

namespace Parabole.AnimatorSystems
{
    [CreateAssetMenu(fileName = "AnimatorOverrideCollection", menuName = "Animator Override Controller Collection", order = 403)]
    public class AnimatorOverrideCollection : ScriptableObject
    {
        public AnimatorOverrideController[] Controllers;
    }
}