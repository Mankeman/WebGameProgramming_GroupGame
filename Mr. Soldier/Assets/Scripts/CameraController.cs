using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Mouse sensitivity.
    public float mouseSensitivity = 100f;

    //Reference to the player body to rotate it as we move the camera.
    public Transform playerBody;

    //Move up and down.
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor to the center of the screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Reference to the mouse motions.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate the camera up and down.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 65f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotate the body of the player side to side.
        playerBody.Rotate(Vector3.up * mouseX);
        

    }
}
