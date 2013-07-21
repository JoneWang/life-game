using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {
	public bool isDeath = false;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//CharacterController controller = GetComponent<CharacterController>();
		if(isDeath) {
			CharacterController characterController = GetComponent<CharacterController>();
			characterController.enabled = false;
			//Destroy(rigidbody);
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.useGravity = true;
			//transform.position.y -= gravity * Time.deltaTime;
			//moveDirection.y -= gravity * Time.deltaTime;
			// Move the controller
			//controller.Move(moveDirection * Time.deltaTime);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log('h'+hit.gameObject.name);
		monster m = hit.gameObject.GetComponent<monster>();
		if (m.isEnabled) {
			isDeath = true;
		}
	}
	
}
