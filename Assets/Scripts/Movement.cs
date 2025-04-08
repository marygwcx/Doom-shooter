using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float currentSpeed;
    public float sprint = 5;
    public float baseSpeed = 5;



    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;

    }

    void Update()
    {
        var x = transform.position.x;
        var z = transform.position.z;
        var input = new Vector3();

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        transform.position += input * baseSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprint;
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        if (input != Vector3.zero)
        {
            transform.forward = input;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

}