using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float maxSpeed = 15f;
    public float jumpStrength = 5f;

    Rigidbody rigi;

    bool grounded;

    float horizontalSpeed;
    float verticalSpeed;

    GameMaster game;

    public bool isImmune = false;

    public bool isFast = false;

    Animator anim;

    public Transform model;



	private void Start()
	{
        rigi = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        game = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<GameMaster>();
	}


	private void Update()
	{

        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");

	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.collider.tag == "Car")
        {
            if (collision.gameObject.GetComponent<CarController>().isRunning && !isImmune) {
                game.gameOver = true;
                Destroy(gameObject);
            }
        }
	}

   

    private void FixedUpdate()
	{

        Vector3 movementVector = new Vector3(horizontalSpeed, 0, verticalSpeed);
        movementVector = transform.TransformDirection(movementVector);

        movementVector *= speed;

        var velocity = rigi.velocity;

        anim.SetFloat("speed", velocity.magnitude);
        anim.SetBool("grounded", grounded);

        Vector3 facingVector = new Vector3(velocity.x, 0, velocity.z);

        model.rotation = Quaternion.LookRotation(facingVector) * Quaternion.Euler(0, 90, 0);

        var velocityChange = (movementVector - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxSpeed, maxSpeed);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxSpeed, maxSpeed);
        velocityChange.y = 0;
        rigi.AddForce(velocityChange, ForceMode.VelocityChange);

        rigi.AddForce(movementVector, ForceMode.VelocityChange);

        if(grounded && Input.GetButton("Jump")){
            rigi.velocity = new Vector3(velocity.x, jumpStrength, velocity.y);
            grounded = false;
        }
		
	}

	private void OnCollisionStay(Collision collision)
	{
        grounded = true;
	}
}
