using UnityEngine;
using System.Collections;

public class role_move : MonoBehaviour {

	public float Gravity = 21f;	 //downward force
	public float TerminalVelocity = 20f;	//max downward speed
	public float JumpSpeed = 6f;
	public float MoveSpeed = 10f;
	
	public Vector3 MoveVector {get; set;}
	public float VerticalVelocity {get; set;}
	
	public CharacterController CharacterController;
		
	// Use this for initialization
	void Awake () {
		CharacterController = gameObject.GetComponent("CharacterController") as CharacterController;
	}
	
	// Update is called once per frame
	void Update () {
	
		checkMovement();
		HandleActionInput();
		processMovement();
		}
		
		void checkMovement(){
		//move l/r
		var deadZone = 0.1f;
		VerticalVelocity = MoveVector.y;
		MoveVector = Vector3.zero;
		if(Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") <- deadZone){
			MoveVector += new Vector3(Input.GetAxis("Horizontal"),0,0);
		}
	//jump
	
	}
	
	void HandleActionInput(){
		if(Input.GetButton("Jump")){
			jump();
		}
	}
	
	void processMovement(){
		//transform moveVector into world-space relative to character rotation
		MoveVector = transform.TransformDirection(MoveVector);
		
		//normalize moveVector if magnitude > 1
		if(MoveVector.magnitude > 1){
		MoveVector = Vector3.Normalize(MoveVector);
		}
		
		//multiply moveVector by moveSpeed
		MoveVector *= MoveSpeed;
		
		//reapply vertical velocity to moveVector.y
		MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);
		
		//apply gravity
		applyGravity();
		
		//move character in world-space
		CharacterController.Move(MoveVector * Time.deltaTime);
	}

	void applyGravity(){
		if(MoveVector.y >- TerminalVelocity){
			MoveVector = new Vector3(MoveVector.x, (MoveVector.y - Gravity * Time.deltaTime), MoveVector.z);
			//MoveVector = new Vector3(MoveVector.x, (MoveVector.y – Gravity * Time.deltaTime), MoveVector.z);
		}
		if(CharacterController.isGrounded && MoveVector.y < -1){
			MoveVector = new Vector3(MoveVector.x, (-1), MoveVector.z);
		}
	}

	public void jump(){
	if(CharacterController.isGrounded){
		VerticalVelocity = JumpSpeed;
		}
	}
}