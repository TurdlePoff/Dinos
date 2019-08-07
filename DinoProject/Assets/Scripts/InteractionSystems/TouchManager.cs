using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Singleton instance
    private static TouchManager s_rInstance = null;

    [SerializeField]
    private Camera m_rCamera = null;

    private void Awake() {
        if (!s_rInstance) {
            s_rInstance = this;
        }
    }

    // Finds the world space position of the zeroth index touch
    public static Vector3 GetTouchInWorldSpace() {
        if (!s_rInstance) {
            return Vector3.zero;
        }else if(s_rInstance.m_rCamera == null) {
            return Vector3.zero;
        }
        // Cast screen to world point
        return s_rInstance.m_rCamera.ScreenToWorldPoint(Input.touches[0].position);
    }

    // Checks if a touch event is happening
    public static bool IsTouching() {
        return (Input.touchCount > 0);
    }

    // As above, but populates an array with touch information
    public static bool IsTouching(out Touch[] _touches) {
        _touches = Input.touches; // assuming array is empty even if no touches
        return (Input.touchCount > 0);
    }
}
