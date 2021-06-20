using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Animui
{

    /// <summary>
    /// Attach this component to a sprite to control its size via a curve. Use this e.g. for a nice spawn effect.
    /// </summary>
    public class PlopUpGraphical : MonoBehaviour
    {
        [System.Serializable]
        public class AnimationStackEntry {
            [Tooltip("Scale modifier over time")]
            public AnimationCurve SizeOverTime;
            [Tooltip("Total time the animation will take")]
            public float TimeTotal;
            [Tooltip("Snaps to the standard scale at end of animation")]
            public bool SnapToBaseSize = true;
        }

        [Tooltip("Specify animation curves")]
        public AnimationStackEntry[] AnimationStack;
        [Tooltip("Set to true to avoid timeScale affecting the animation")]
        public bool unscaledTime = false;

        [Tooltip("Play animation at index 0 on start")]
        public bool PlayOnStart = true;

        void Start()
        {
            if (PlayOnStart)
            {
                PlayAnimation(0);
            }
        }

        /// <summary>
        /// Plays the animation from the array at the given index.
        /// </summary>
        /// <param name="Index">The index to play.</param>
        public void PlayAnimation(int Index) {
            if (Index < AnimationStack.Length)
            {
                StartCoroutine(PlopUpRoutine(Index));
            }
            else Debug.LogWarning("Animation at Index " + Index + " not found.", gameObject);
        }

        /// <summary>
        /// Routine that samples form the animation Curve
        /// </summary>
        /// <param name="Index">The animation curve to be played</param>
        IEnumerator PlopUpRoutine(int Index) {
            Vector3 endSize = transform.localScale;
            float startTime = unscaledTime ? Time.realtimeSinceStartup : Time.time;
            while ((unscaledTime ? Time.realtimeSinceStartup : Time.time) < startTime + AnimationStack[Index].TimeTotal) {
                transform.localScale = endSize * 
                    AnimationStack[Index].SizeOverTime.Evaluate
                    (((unscaledTime ? Time.realtimeSinceStartup : Time.time) - startTime) / AnimationStack[Index].TimeTotal);
                yield return null;
            }
            transform.localScale = AnimationStack[Index].SnapToBaseSize ? endSize : endSize * AnimationStack[Index].SizeOverTime.Evaluate(1f);
        }

    }

}
