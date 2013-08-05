using UnityEngine;
using System.Collections;

public class role_move : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpSpeed = 3.5f;
	public float gravity = 11.0f;
	public int isGravity = 1;
	private Vector3 moveDirection = Vector3.zero;

	private tk2dSprite roleSprite;
	private tk2dAnimatedSprite anim;
	public bool isMove = true;

	void Start () {
		// This script must be attached to the sprite to work.
		anim = GetComponent<tk2dAnimatedSprite>();
	}

	void Update() {
		if (isMove) {
			move();
		}
		
		//Debug.Log((1.6f < transform.position.x).ToString() + ',' + (transform.position.x < 1.7f).ToString() + ',' + (36.4f < transform.position.y).ToString() + ',' + (transform.position.y < 36.9f).ToString());
		//if (1.6f < transform.position.x && transform.position.x < 1.7f && 36.4f < transform.position.y && transform.position.y < 36.9f) {
		//	transform.localScale.x = 2f;
		//}
	}
	
	void move() {
		CharacterController controller = GetComponent<CharacterController>();
		roleSprite = GetComponent<tk2dSprite>();
		
		// Player move
		if (controller.isGrounded) {
		
			//Debug.Log(Input.GetAxis("Horizontal"));
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.H)) {
			if (!anim.IsPlaying("leftwalk")){
				anim.Play("leftwalk");
			}
		}
		else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.H)) {
			 anim.Play("leftstop");
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.L)) {
			if (!anim.IsPlaying("rightwalk")){
				anim.Play("rightwalk");
			}
		}
		else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.L)) {
			anim.Play("rightstop");
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
	}
}