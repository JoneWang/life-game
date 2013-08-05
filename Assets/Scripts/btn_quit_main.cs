using UnityEngine;
using System.Collections;

public class btn_quit_main : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseUp () {
    	Application.LoadLevel("life");
	}
}
