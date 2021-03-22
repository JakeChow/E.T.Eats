using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed = 50.0f;
	public float turnSpeed = 400.0f;
	public float gravity = 20.0f;
	public float airControl = 10;
	public float jumpHeight = 3;
	public AudioClip jumpSFX;
	public AudioClip wallrunSFX;

	AudioSource audioSource;
	int jumpCount = 2;
	Animator anim;
	CharacterController controller;
	Vector3 input, moveDirection;
	bool onWall = false;

	void Start () {
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
		audioSource = GetComponent<AudioSource>();
		
	}

	void Update() {

		float moveHorizontal = 0;
		float moveVertical = 0;

		// Input.GetAxis emulates a joystick and makes the controls sloppy
		if (Input.GetKey("w")) {
			moveVertical += 1;
		}

		if (Input.GetKey("s")) {
			moveVertical -= 1;
		}

		if (Input.GetKey("a")) {
			moveHorizontal -= 1;
		}

		if (Input.GetKey("d")) {
			moveHorizontal += 1;
		}


		if (moveHorizontal == 0 && moveVertical == 0) {
			anim.SetInteger("AnimationPar", 0);
		} else {
			anim.SetInteger("AnimationPar", 1);
        }

		input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

		input *= moveSpeed;

		if (controller.isGrounded)
		{
			jumpCount = 2;

			moveDirection = input;

			if (Input.GetButtonDown("Jump"))
			{
				jumpCount--;
				moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
				AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
			}
			else
			{
				moveDirection.y = 0.0f;
			}

		}
		else if(onWall && moveHorizontal != 0)
        {
			moveDirection = input;
			if (!audioSource.isPlaying)
            {
				audioSource.clip = wallrunSFX;
				audioSource.Play();
            }
		}
		else
		{
			if (Input.GetButtonDown("Jump") && jumpCount > 0)
			{
				moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity / 2);
				AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
				jumpCount--;
			}
			input.y = moveDirection.y;
			moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("WallRide")) {
			Debug.Log("On wall");
			onWall = true;
		}
        if (other.CompareTag("WallJump"))
        {
			jumpCount = 1;
        }
	}

	private void OnTriggerExit(Collider other) {
		if(other.CompareTag("WallRide")) {
			Debug.Log("Off wall");
			onWall = false;
		}
	}
}
