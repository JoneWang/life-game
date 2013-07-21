using UnityEngine;
using System.Collections;

public class rabbit : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpSpeed = 3.5f;
	public float gravity = 12.0f;
	public int isGravity = 1;
	private Vector3 moveDirection = Vector3.zero;
	private tk2dAnimatedSprite anim;
	private float direction = -0.2f;
	public float leftStop = 2.5f;
	public float rightStop = 5.0f;
	private bool isLeft = true;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<tk2dAnimatedSprite>();
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
		
		// Player move
		if (controller.isGrounded) {
		
			moveDirection = new Vector3(direction, 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			//if (Input.GetButton("Jump")) {
			//	moveDirection.y = jumpSpeed;
			//}
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
		
		//Debug.Log(isLeft.ToString() + ',' + (transform.position.x < leftStop).ToString() + ',' + (transform.position.x > rightStop).ToString() + ',' + transform.position.x);
		if (transform.position.x < leftStop && isLeft == true) {
			direction = -direction;
			isLeft = false;
			anim.Play("rightwalk");
		}
		if (transform.position.x > rightStop && isLeft == false) {
			direction = -direction;
			isLeft = true;
			anim.Play("leftwalk");
		}
	}
}
