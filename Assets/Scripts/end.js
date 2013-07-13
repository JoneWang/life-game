#pragma strict

function Start () {

}

function Update () {
	Debug.Log(transform.position.y);
	if (transform.position.y >= 38) {
		GameOver();
	}
}

function GameOver () {
	yield WaitForSeconds(10);
	Application.LoadLevel("life");
}