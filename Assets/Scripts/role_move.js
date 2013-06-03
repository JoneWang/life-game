#pragma strict

var speed : float = 1.0;
var jumpSpeed : float = 3.5;
var gravity : float = 12.0;
var isGravity : int = 1;
private var moveDirection : Vector3 = Vector3.zero;

private var roleSprite : tk2dSprite;

function Update() {
    var controller : CharacterController = GetComponent(CharacterController);
    roleSprite = GetComponent(tk2dSprite);
    
    // Player move
    if (controller.isGrounded) {
    	if (Input.GetKey(KeyCode.A)) {
    		roleSprite.spriteId = 1;
    	}
    	if (Input.GetKey(KeyCode.D)) {
    		roleSprite.spriteId = 0;
    	}
    
        moveDirection = Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
            
        if (Input.GetButton ("Jump")) {
            moveDirection.y = jumpSpeed;
        }
    }
    
	moveDirection.y -= gravity * Time.deltaTime;
    // Move the controller
    controller.Move(moveDirection * Time.deltaTime);
}

function OnBecameInvisible() {
	//Out of the screen
	transform.position = new Vector3(0.5497832f, 0.2547682, 0);
}