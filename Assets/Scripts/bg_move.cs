using UnityEngine;
using System.Collections;

public class bg_move : MonoBehaviour {
	public float speed = 0.5f;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {//-4.885276
	
	  gameObject.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-Time.deltaTime*-speed,gameObject.transform.position.z);
	  if(gameObject.transform.position.y>3)
	  {
	   gameObject.transform.position=new Vector3(gameObject.transform.position.x,-1.4f,gameObject.transform.position.z);
	  }
	}
}
