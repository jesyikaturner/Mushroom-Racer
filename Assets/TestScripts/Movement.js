#pragma strict

var speed :float = 5.0f;
var jumpSpeed :float = 10.0f;
var gravity :float = 20.0f; 

private var moveDirection = Vector3.zero;
private var vertVel :float = 0.0f;


private var up;
private var left;
private var right;

private var down;

function Start () {

}

function Update () {
	var controller :CharacterController  = GetComponent("CharacterController");
	
	up = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
	left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
	right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
	down = Input.GetKey(KeyCode.S);
	
	if (left){
		moveDirection = new Vector3(-speed,0,0);
	}else if (right){
		moveDirection = new Vector3(speed, 0,0);
	}else{
		moveDirection = new Vector3(0,0,0);
	}
	if(up){
		if (controller.isGrounded){
			vertVel = jumpSpeed;	
		}
	}
	
	if(down){
		moveDirection = new Vector3(0,0,-speed);
	}
	
	vertVel -= gravity * Time.deltaTime;
	moveDirection.y = vertVel;
	controller.Move(moveDirection * Time.deltaTime);
	
}