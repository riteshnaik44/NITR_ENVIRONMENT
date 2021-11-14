using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class cam_movement : NetworkBehaviour
{
    public float mouseSensitivity = 10f;

    float xRotation = 0f;
    float yRotation = 0f;
    [SerializeField]
    private  float clamp=50;
    [SerializeField]
    private Camera cam;
    void Start()
    {
        if (!isLocalPlayer)
        {
            cam.gameObject.SetActive(false);
        }
        
        Cursor.lockState=CursorLockMode.Locked;
    }


    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clamp, clamp);
        yRotation -= mouseX;
        transform.localRotation = Quaternion.Euler(0f, -yRotation, 0f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, cam.transform.localRotation.y,cam.transform.localRotation.z);

    }
}
