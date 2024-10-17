using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //mouse sensitivity
    public float mouseSensitivity = 2.0f;
    //default vertical rotation
    private float verticalRotation = 0;

    //movement speed
    public float movementSpeed = 5.0f;
    //player object's rigidbody component
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //retrieve player objects rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RotationInputM();

        WASD();
    }

    //player rotation
    void RotationInputM()
    {
        //gets mouse input for horizontal rotation
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        //applies horizontal rotation
        transform.Rotate(0, horizontalRotation, 0);

        //gets mouse input for vertical rotation
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        //restricts vertical rotation of player
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
    }

    //player movement
    void WASD()
    {
        //get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //adjusts player position based on input, modified by movementSpeed and applied between frames
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * movementSpeed * Time.deltaTime;

        //apply movement vector to the direction player is facing
        movement = transform.TransformDirection(movement);
        //apply movement vector to the player's rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
