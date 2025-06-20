using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    private float movementDirection = 0f;
    private int characterRotation = 0;

    private Rigidbody myRigidBody;
    
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movementDirection = 0f;
        characterRotation = 0;

        if (Input.GetKey(KeyCode.W))
        {
            movementDirection = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementDirection = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterRotation = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterRotation = 1;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * movementDirection * speed * Time.fixedDeltaTime;
        myRigidBody.MovePosition(myRigidBody.position + movement);

        Quaternion deltaRotation = Quaternion.Euler(0f, characterRotation * rotationSpeed * Time.fixedDeltaTime, 0f);
        myRigidBody.MoveRotation(myRigidBody.rotation * deltaRotation);
    }
}
