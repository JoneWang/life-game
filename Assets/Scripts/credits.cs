using UnityEngine;
using System.Collections;

public class credits : MonoBehaviour {
	public float upspeed = 0.8f;
	private bool isStop = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isStop) {
			if (transform.position.y >= 21) {
				isStop = true;
			}
		
			Vector3 movement = Vector3.zero;
			movement.y += upspeed;
			transform.Translate(movement * Time.deltaTime, Space.Self);
		}
		else {
			StartCoroutine(ReturnMain());
		}
	}
	
	IEnumerator ReturnMain () {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("life");
	}
}
