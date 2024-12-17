using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public bool isMoving;
    public int rotationSpeed;
    public int movementSpeed;
    public int jumpHeight;

    public bool isGrounded;
    public Transform groundChecker;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float gravity = 9.81f;

    public Vector3 velocity;



    public void Start()
    {
        characterController = GetComponent<CharacterController>();  
    }

    public void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        Vector3 movementUnits = new Vector3(horizontal, 0, vertical);
        isMoving = movementUnits != Vector3.zero ? true : false;

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);


    }
}





