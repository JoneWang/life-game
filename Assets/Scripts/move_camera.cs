using UnityEngine;
using System.Collections;

public class move_camera : MonoBehaviour {
	public float upspeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(transform.position.y);
		if (transform.position.y > 17f && transform.position.y < 29f) {
			if (upspeed < 0.2f) {
				upspeed += 0.001f;
			}
		}
		else if (transform.position.y > 29f && transform.position.y < 38f) {
			if (upspeed < 0.4f) {
				upspeed += 0.001f;
			}
		}
		else if (transform.position.y >= 38) {
			upspeed = 0f;
		}
		
		//transform.position = new Vector3(transform.position.x, transform.position.y+0.001f, transform.position.z);
		Vector3 movement = Vector3.zero;
		movement.y += upspeed;
		transform.Translate(movement * Time.deltaTime, Space.Self);
	}
}
