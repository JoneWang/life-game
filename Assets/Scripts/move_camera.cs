using UnityEngine;
using System.Collections;

public class move_camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3(transform.position.x, transform.position.y+0.001f, transform.position.z);
		Vector3 movement = Vector3.zero;
		movement.y += 0.1f;
		transform.Translate(movement * Time.deltaTime, Space.Self);
	}
}
