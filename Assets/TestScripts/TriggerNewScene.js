#pragma strict

var teleport :Transform;

function Start () {
	
}

function Update () {

}

function OnTriggerEnter(other:Collider){
	if(other.gameObject.tag =="Player"){
		//Application.LoadLevel("Scene2");
		other.transform.position = teleport.transform.position;
		Debug.Log("Proceed to next scene!");
		
	}

}