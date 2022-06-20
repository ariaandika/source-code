using UnityEngine;

namespace Toolkit
{
    public class SidescrollCamera : MonoBehaviour
    {
        public static Camera _cam;
        [SerializeField] private Transform target;

        [Space(10)][Range(0,10)]
        [SerializeField] private float smooth;

        Vector3 y;

        // External Hook
        public void SetTarget(Transform camTarget) => target = camTarget;

        void Awake() => _cam = FindObjectOfType<UnityEngine.Camera>();
        void Update() => transform.position = Vector3.SmoothDamp(transform.position, target.position, ref y, smooth);
    }
}