using UnityEngine;
using System.Collections;

public class role_move1 : MonoBehaviour {
	public float xSpeed = -1f;
	public float gravity = -1f;
	public bool isGravity = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(xSpeed*Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(-xSpeed*Time.deltaTime, 0, 0);
		}
		if (isGravity) {
		    // Apply gravity
	    	transform.Translate(0, gravity * Time.deltaTime, 0);
		}
	}
	
	/*void OnControllerColliderHit (ControllerColliderHit hit) {
		gravity = 1f;
	    if(hit.gameObject.name == "Blocks") {
	    	isGravity = false;
	    }
		else {
	    	isGravity = true;
		}
			
	}*/
	
	void OnCollisionStay (Collision obj) {
	    if(obj.gameObject.name == "Blocks") {
	    	isGravity = false;
	    }
		else {
	    	isGravity = true;
		}
    }
}
