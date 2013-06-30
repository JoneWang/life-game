#pragma strict

var speed : float = 1.0;
var jumpSpeed : float = 3.5;
var gravity : float = 12.0;
var isGravity : int = 1;
private var moveDirection : Vector3 = Vector3.zero;

private var roleSprite : tk2dSprite;
private var anim : tk2dAnimatedSprite;
private var walking : boolean = false;

function Start () {
    // This script must be attached to the sprite to work.
    anim = GetComponent(tk2dAnimatedSprite);
}

function Update() {
    var controller : CharacterController = GetComponent(CharacterController);
    roleSprite = GetComponent(tk2dSprite);
    
    // Player move
    if (controller.isGrounded) {
    
        moveDirection = Vector3(Input.GetAxis("Horizontal"), 0, 0);
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

function OnBecameInvisible() {
	//Out of the screen
	//transform.position = new Vector3(0.5497832f, 0.2547682, 0);
	Application.LoadLevel("life");
}