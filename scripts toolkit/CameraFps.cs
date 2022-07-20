using UnityEngine;

namespace Toolkit
{
    public class CameraFps : MonoBehaviour
    {
        /// <summary>
        /// First Person View
        /// </summary>
        // Put this in camera holder
        
        public Transform playerBody;
        float xRotation = 0f;
        
            void Start() => Cursor.lockState = CursorLockMode.Locked;
            void Update()
            {
                #region Look Around
                var mouseX = Input.GetAxis("Mouse X") * 400f * Time.deltaTime;
                var mouseY = Input.GetAxis("Mouse Y") * 400f * Time.deltaTime;
                
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
                playerBody.Rotate(Vector3.up * mouseX);
                #endregion
            }
    }
}