using UnityEngine;

namespace Core.Player.Bin
{
    public class CamFps : MonoBehaviour
    {
        /// <summary>
        /// First Person View
        /// </summary>
        // Put this in camera holder
        
        public Transform playerBody;

        public float sensitivity = 4;
        public static Camera cam;
        float xRotation;
        
        void Start()
        {
            cam = GetComponentInChildren<Camera>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            #region Look Around
            var mouseX = Input.GetAxis("Mouse X") * sensitivity * 100 * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * sensitivity * 100 * Time.deltaTime;
            
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
            #endregion
        }
    }
}