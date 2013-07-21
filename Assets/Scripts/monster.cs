using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {
	public bool isEnabled = true;
	public GameObject player = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Bounds b = transform.renderer.bounds;
		Bounds p = player.renderer.bounds;
		if (b.Intersects(p)) {
			death d = player.GetComponent<death>();
			d.isDeath = true;
		}
	}
	
	
}
