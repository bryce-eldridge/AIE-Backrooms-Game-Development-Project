using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float walkSpeed = 1f;
    public float sprintSpeed = 3f;
    public float RotateSpeed = 1f;
    public float horizontalSpeed = 1f;
    public float verticalSpeed  = 1f;
    public Transform MainCamera;

    CharacterController cc;

    //Initialization
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Rotate the character controller according to where the Mouse is looking.
        
        float h = horizontalSpeed * Input.GetAxis ("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);
        MainCamera.Rotate(v, 0, 0);

        //When player presses shift key, accelerate their speed.
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                MoveSpeed = sprintSpeed;
            }
            else
            {
                MoveSpeed = walkSpeed;
            }
        }

        // Move forward/backward according to up/down key
        cc.Move(transform.forward * Input.GetAxis("Vertical") * MoveSpeed);

        // Apply Gravity
        cc.SimpleMove(Physics.gravity);
    }

}
