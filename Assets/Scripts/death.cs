using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {
	public bool isDeath = false;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 1;
	private int pointIndex = 0;
	public GameObject camera = null;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//CharacterController controller = GetComponent<CharacterController>();
		CharacterController characterController = GetComponent<CharacterController>();
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if(isDeath) {
			characterController.enabled = false;
			//Destroy(rigidbody);
			rigidbody.useGravity = true;
			//transform.position.y -= gravity * Time.deltaTime;
			//moveDirection.y -= gravity * Time.deltaTime;
			// Move the controller
			//controller.Move(moveDirection * Time.deltaTime);
		}
		else {
			characterController.enabled = true;
			rigidbody.useGravity = false;
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log('h'+hit.gameObject.name);
		try {
			monster m = hit.gameObject.GetComponent<monster>();
			if (m.isEnabled) {
				isDeath = true;
			}
		}
		catch {
		}
	}
	
	void OnTriggerStay(Collider collider) {
		string objectName = collider.gameObject.name;
		if (objectName == "save") {
			point p = collider.gameObject.GetComponent<point>();
			pointIndex = p.index;
			tk2dSprite s = collider.gameObject.GetComponent<tk2dSprite>();
			s.SetSprite("content_137");
		}
	}

	void OnBecameInvisible() {
		//Out of the screen
		//Application.LoadLevel("life");
		if (camera != null) {
			Transform cameraTransform = camera.transform;
			float cameraY = cameraTransform.position.y;
			float playerX = transform.position.x;
			float playerY = transform.position.y;
			if (pointIndex==0) {
				playerX = 0.3f;
				playerY = 1f;
				cameraY = 2f;
			}
			else if (pointIndex==1) {
				playerX = 0.5f;
				playerY = 10.7f;
				cameraY = 11.3f;
			}
			else if (pointIndex==2) {
				playerX = 3.4f;
				playerY = 22.84f;
				cameraY = 23.9f;
			}
			if (cameraY != cameraTransform.position.y) {
				transform.position = new Vector3(playerX, playerY, transform.position.z);
				cameraTransform.position = new Vector3(cameraTransform.position.x, cameraY, cameraTransform.position.z);
				isDeath = false;
			}
		}
	}
}
