using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float gravity = 10f;
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticleVelocity = 0.5f;

    [SerializeField] private float animationDuration = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * moveSpeed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticleVelocity = -0.5f;
        }
        else
        {
            verticleVelocity -= gravity * Time.deltaTime;
        }

        //Move forward
        moveVector.z = moveSpeed;   //Input.GetAxisRaw("Vertical");
        //Move left and right
        moveVector.x = Input.GetAxisRaw("Horizontal");
        //Gravity applied
        moveVector.y = verticleVelocity;

        controller.Move(moveVector * Time.deltaTime);
    }
}
