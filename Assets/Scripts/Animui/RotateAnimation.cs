using System.Collections;
using UnityEngine;

namespace Animui
{

    /// <summary>
    /// Attach this component to an object to control its rotation via a curve.
    /// </summary>
    public class RotateAnimation : MonoBehaviour
    {
        [System.Serializable]
        public class AnimationStackEntry
        {
            [Tooltip("Rotation progress over time")]
            public AnimationCurve RotationAnimation;
            [Tooltip("Total time the animation will take")]
            public float TimeTotal;
            [Tooltip("Snaps to the target rotation at end of animation")]
            public bool SnapToTargetRotation = true;
        }

        [Tooltip("Specify animation curves")]
        public AnimationStackEntry[] AnimationStack;
        [Tooltip("Set to true to avoid timeScale affecting the animation")]
        public bool unscaledTime = false;


        /// <summary>
        /// Plays the animation from the array at the given index.
        /// </summary>
        /// <param name="Index">The index to play.</param>
        public void TransitionToRotation(int Index, Vector3 targetRotation)
        {
            if (Index < AnimationStack.Length)
            {
                StartCoroutine(RotationRoutine(Index, targetRotation));
            }
            else Debug.LogWarning("Animation at Index " + Index + " not found.", gameObject);
        }

        /// <summary>
        /// Routine that samples from the animation Curve
        /// </summary>
        /// <param name="Index">The animation curve to be played</param>
        IEnumerator RotationRoutine(int Index, Vector3 targetRotation)
        {
            float startTime = unscaledTime ? Time.realtimeSinceStartup : Time.time;
            Vector3 startRotation = transform.eulerAngles;
            Vector3 rotationDifference = targetRotation - startRotation;
            while ((unscaledTime ? Time.realtimeSinceStartup : Time.time) < startTime + AnimationStack[Index].TimeTotal)
            {
                transform.eulerAngles = startRotation + rotationDifference *
                    AnimationStack[Index].RotationAnimation.Evaluate
                    (((unscaledTime ? Time.realtimeSinceStartup : Time.time) - startTime) / AnimationStack[Index].TimeTotal);
                yield return null;
            }
            transform.eulerAngles = AnimationStack[Index].SnapToTargetRotation ? targetRotation : targetRotation * AnimationStack[Index].RotationAnimation.Evaluate(1f);
        }

    }

}
