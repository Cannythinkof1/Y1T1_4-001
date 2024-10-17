using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    //to identify the Player Character
    public Transform target;

    //camera positon relative to the player
    public float distance = 5.0f;
    public float heightOffset = 1.5f;

    //mouse sensitivity
    public float sensitivity = 2.0f;

    //initial vertical and horizontal rotation
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //locks the cursor
        Cursor.lockState = CursorLockMode.Locked;
        //hides the cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
    }

    //rotates the camera
    void HandleCameraInput()
    {
        //rotates the camera modified by sensitivity
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        //updates the camera rotation based on the mouse movement
        rotationY += mouseX;
        rotationX -= mouseY;

        //apply the camera rotation
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    //moves the camera
    void FollowTarget()
    {
        //move the camera to follow the player
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * heightOffset;
        transform.position = targetPosition;

        //turn the camera to face the player
        transform.LookAt(target);
    }
}
