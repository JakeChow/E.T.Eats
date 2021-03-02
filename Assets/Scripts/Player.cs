using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed = 50.0f;
	public float turnSpeed = 400.0f;
	public float gravity = 20.0f;
	public float airControl = 10;
	public float jumpHeight = 3;

	int jumpCount = 2;
	Animator anim;
	CharacterController controller;
	Vector3 input, moveDirection;

	void Start () {
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update() {
		if (Input.GetKey("w"))
		{
			anim.SetInteger("AnimationPar", 1);
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
		}

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

		input *= moveSpeed;

		if (controller.isGrounded)
		{
			jumpCount = 2;

			moveDirection = input;

			if (Input.GetButton("Jump"))
			{
				jumpCount--;
				moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
			}
			else
			{
				moveDirection.y = 0.0f;
			}

		}
		else
		{
			if (Input.GetButton("Jump") && jumpCount > 0)
			{
				moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity / 2);
				jumpCount--;
			}
			input.y = moveDirection.y;
			moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
