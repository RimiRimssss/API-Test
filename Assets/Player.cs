using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public int movementSpeed;
    public Rigidbody rb;
    private float horizontal, vertical;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        vertical = Input.GetAxis("Vertical") * movementSpeed;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal, rb.velocity.y, vertical);
    }
}
