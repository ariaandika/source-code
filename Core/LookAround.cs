using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    /// <summary>
    /// First Person View
    /// </summary>

    // Put this in camera holder

    public Transform playerBody;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
        #region Look Around
        float mouseX = Input.GetAxis("Mouse X") * 400f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 400f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
        #endregion


    }
}
