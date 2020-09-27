using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour

{
    [SerializeField] private float accelerationForce = 10.0f;
    [SerializeField] private float maxSpeed = 2;

    private new Rigidbody rigidbody;
    private Vector2 input;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);
        if(rigidbody.velocity.magnitude < maxSpeed)
        {
        rigidbody.AddForce(inputDirection * accelerationForce); // << Multiply by time.DetaTime not needed in FixedUpdate
        }

        /*rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);*/ // << Using this over rides the Unity phisics 
        // simulation, ei. The character's gravity is affected by this!
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}

