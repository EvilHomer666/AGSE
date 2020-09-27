using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour

{
    [SerializeField] private float accelerationForce = 10.0f;
    [SerializeField] private float maxSpeed = 2;
    [SerializeField] private PhysicMaterial stopPhysicsMaterial, movePhysicsMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);


        // There is a shorcut syntax for this block of code - See below using the ternary or also called conditional operator.
        //if (inputDirection.magnitude > 0)
        //{
        //    collider.material = movePhysicsMaterial;
        //}
        //else
        //{
        //    collider.material = stopPhysicsMaterial;
        //}

        collider.material = inputDirection.magnitude > 0 ? movePhysicsMaterial : stopPhysicsMaterial;
        // The line of code above does the same as the comented if condition before.



        if(rigidbody.velocity.magnitude < maxSpeed)
        {
        rigidbody.AddForce(inputDirection * accelerationForce, ForceMode.Acceleration); // << Multiply by time.DetaTime not needed in FixedUpdate
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

