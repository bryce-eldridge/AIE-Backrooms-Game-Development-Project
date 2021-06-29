using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float WalkSpeed = 1f;
    public float sprintSpeed = 100f;
    public float RotateSpeed = 1f;
    public float horizontalSpeed = 1f;
    public float verticalSpeed  = 1f;
    public Transform MainCamera;

    public float Drain = 1f;
    public float Refill = 5f;


    Coroutine currentDrain;
    Coroutine currentFill;
    //public float 

    CharacterController CharacterSystem;
    StaminaScript StaminaSystem;


    IEnumerator DrainStamina()
    {
        while (true)
        {
            // Perform this action forever
            StaminaSystem.Stamina = Mathf.Clamp(StaminaSystem.Stamina - Drain * Time.deltaTime * 1, 0, 100);
            yield return null;
        }
    }

    IEnumerator RefillStamina()
    {
        while (true)
        {
           StaminaSystem.Stamina = (StaminaSystem.Stamina + Refill * Time.deltaTime);
           yield return null;
        }
    }


    //Initialization
    private void Start()
    {
        CharacterSystem = GetComponent<CharacterController>();
        StaminaSystem = GetComponent<StaminaScript>();

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

        // Stop the camera from rotating in 360 degree on the x axies 

        var currentRotation = MainCamera.eulerAngles;

        var rotationX = currentRotation.x;

        if (rotationX > 90f)
        {
            rotationX = 90f;
        }
        else if (rotationX < -90f)
        {
            rotationX = -90f;
        }

        



        //When player presses shift key, accelerate their speed and drain their stamina 
        {
            if (Input.GetKey(KeyCode.LeftShift) && StaminaSystem.Stamina > 0)
            {
                MoveSpeed = sprintSpeed;
                currentDrain = StartCoroutine(DrainStamina());

                
            }
            else
            {
                MoveSpeed = WalkSpeed;


                currentFill = StartCoroutine(RefillStamina());
                if (currentDrain != null)
                    StopAllCoroutines();
                
                

                //Refill player's stamina overtime
                
            }

                





        }

        // Move forward/backward according to up/down key

        var forward = transform.forward * Input.GetAxis("Vertical");
        var right = transform.right * Input.GetAxis("Horizontal");
        var direction = forward + right;
        var normalized = direction.normalized;
        var movement = normalized * MoveSpeed;



        

        // Apply Gravity
        CharacterSystem.SimpleMove(Physics.gravity);

        // Apply Movement

        CharacterSystem.SimpleMove(movement);
    }

}
        