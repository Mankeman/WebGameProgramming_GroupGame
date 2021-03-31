using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [Header("Mobile Controls")]
    public Joystick joystick;
    public float sensitivity;

    [Header("Desktop Controls")]
    //Mouse sensitivity.
    public float mouseSensitivity = 100f;

    [Header("Others")]
    //Reference to the player body to rotate it as we move the camera.
    public Transform playerBody;

    //Move up and down.
    float xRotation = 0f;

    //Game Controller
    public GameController control;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        control = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mobile Controls
        float mouseX = joystick.Horizontal * sensitivity;
        float mouseY = joystick.Vertical * sensitivity;

        //Reference to the mouse motions. (Desktop/WebGL)
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate the camera up and down.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 65f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotate the body of the player side to side.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
