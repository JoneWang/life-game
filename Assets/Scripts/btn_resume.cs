using UnityEngine;
using System.Collections;

public class btn_resume : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseUp () {
		transform.localScale = new Vector3(1, 1, transform.localScale.z);
    	move_camera mc = gameObject.transform.parent.parent.GetComponent<move_camera>();
		mc.SetActive(false);
	}
}
