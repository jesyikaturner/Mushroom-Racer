
// Digital Tutors Script -- 2D Racer Script
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 10.0f;
	public float reverseSpeed = 5.0f;
	public float turnSpeed = 0.6f;
	
	public float grassSpeed = 3.0f;
	public float resetSpeed = 0.0f;
	public float resetTurnSpeed = 0.0f;
	
	private float moveDirection = 0.0f;
	private float turnDirection = 0.0f;
	
	// Use this for initialization
	void Start () {
		resetSpeed = speed;
		resetTurnSpeed = turnSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float curSpeed = Mathf.Abs(transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z);
		float maxAngDrag = 10.0f;
		float curAngDrag = 5.0f;
		float aDragLerpTime = curSpeed * 0.1f;
		
		float maxDrag = 1.0f;
		float curDrag = 2.5f;
		float dragLerpTime = curSpeed * 0.1f;
		
		float myAngDrag = Mathf.Lerp(curAngDrag,maxAngDrag,aDragLerpTime);
		float myDrag = Mathf.Lerp(curDrag,maxDrag,dragLerpTime);
		
		if(Input.GetAxis("Vertical") > 0.0f){
			moveDirection = Input.GetAxis("Vertical") * speed;
			GetComponent<Rigidbody>().AddRelativeForce(0,0,moveDirection);
			if (curSpeed > 0.1f){
				turnDirection = Input.GetAxis("Horizontal") * turnSpeed;
				GetComponent<Rigidbody>().AddRelativeTorque(0, turnDirection, 0);
			}
		}
		if(Input.GetAxis("Vertical") < 0.0f){
			moveDirection = Input.GetAxis("Vertical") * reverseSpeed;
			GetComponent<Rigidbody>().AddRelativeForce(0,0,moveDirection);
			if (curSpeed > 0.1f){
				turnDirection = Input.GetAxis("Horizontal") * turnSpeed;
				GetComponent<Rigidbody>().AddRelativeTorque(0, -turnDirection, 0);
			}
		}
		
		GetComponent<Rigidbody>().angularDrag = myAngDrag;
		GetComponent<Rigidbody>().drag = myDrag;
		
	}
	
	void OnTriggerStay(Collider other){
		if(other.tag == "Grass"){
			speed = grassSpeed;	
		}
		if(other.tag =="DeadZone"){
			speed = 0.0f;	
		}
	}
	
	void OnTriggerExit(Collider other){
		speed = resetSpeed;	
	}
	
}
