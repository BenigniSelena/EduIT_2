using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private Vector3 characterPosition;
    [SerializeField] private Vector3 characterMovement;
    [SerializeField] private Transform transformCharacter;
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        transformCharacter = this.gameObject.GetComponent<Transform>();
        characterPosition = transformCharacter.position;
    }

    private void Update()
    {
        characterMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            characterMovement.x += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            characterMovement.x -= 1;
        }

        Vector3 objectPosition = transform.position;
        objectPosition += characterMovement.normalized * speed * Time.deltaTime;
        transform.position = objectPosition;
    }
}
