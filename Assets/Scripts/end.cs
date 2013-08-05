using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {
	private bool isPlay = false;
	private float speed = 0.01f;

	// Use this for initialization
	void Start () {
		//Play();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(isPlay);
		if (isPlay) {
			transform.localScale = new Vector3(
				transform.localScale.x*(1+speed), 
				transform.localScale.y*(1+speed), 
				transform.localScale.z
			);
			if (transform.localScale.x>10) {
				//isPlay = false;
				Application.LoadLevel("gameover");
			}
		}
	}
	
	public void Play() {
		if (!isPlay) {
			transform.localScale = new Vector3(0.1f, 0.1f, 0f);
		}
		isPlay = true;
	}
}
