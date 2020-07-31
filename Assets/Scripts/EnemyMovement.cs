using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	
	public static bool raceStarted = false;
	public float aiSpeed = 10.0f;
	public float aiTurnSpeed = 0.005f;
	
	public float resetAISpeed = 0.0f;
	public float resetAITurnSpeed = 0.0f;
	
	public GameObject waypointController;
	public List<Transform> waypoints;
	public int currentWayPoint = 0;
	
	public GameObject boost;
	public Transform boostSocket;
	
	public bool canPickUp = true;
	public bool hasBoost = false;
	public bool boostTimerActive = false;
	public float boostTimer = 3.0f;
	public float resetBoostTimer = 3.0f;
	public float boostModifier = 1.5f;
	
	public bool speedIncreased = true;
	
	
	// Use this for initialization
	void Start () {
		GetWayPoints();
		resetAISpeed = aiSpeed;
		resetAITurnSpeed = aiTurnSpeed;
		
	}
	
	void Update(){
		if(hasBoost){
			canPickUp = false;
			GameObject cloneBoost;
			cloneBoost = (GameObject) Instantiate(boost, boostSocket.transform.position, transform.rotation);
			cloneBoost.transform.parent = boostSocket;
				
			boostTimerActive = true;
			if(speedIncreased){
				aiSpeed = aiSpeed * boostModifier;
				speedIncreased = false;
			}
			if(boostTimerActive){
				boostTimer -= Time.deltaTime;
				if(boostTimer <= 0){
						
					boostTimerActive = false;
					boostTimer = resetBoostTimer;
					aiSpeed = resetAISpeed;
					speedIncreased = true;
					canPickUp = true;
					hasBoost = false;	
				}
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(raceStarted){	
			MoveTowardWayPoint();
		}
	}
	

	
	void GetWayPoints(){
		Transform[] potentialWayPoints = waypointController.GetComponentsInChildren<Transform>();
		waypoints = new List<Transform>();
		
		foreach (Transform potentialWayPoint in potentialWayPoints){
			if(potentialWayPoint != waypointController.transform){
				waypoints.Add (potentialWayPoint);	
			}
		}
	}
	
	void MoveTowardWayPoint(){
		float currWayPointX = waypoints[currentWayPoint].position.x;
		float currWayPointY = transform.position.y;
		float currWayPointZ = waypoints[currentWayPoint].position.z;
		
		Vector3 relativeWayPointPos = transform.InverseTransformPoint(new Vector3(currWayPointX,currWayPointY,currWayPointZ));
		Vector3 currentWayPointPos =  new Vector3(currWayPointX,currWayPointY,currWayPointZ);
		
		Quaternion toRotation = Quaternion.LookRotation(currentWayPointPos - transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,aiTurnSpeed);
		
		GetComponent<Rigidbody>().AddRelativeForce(0,0,aiSpeed);
		
		if(relativeWayPointPos.sqrMagnitude < 10.0f){
			currentWayPoint++;	
			if(currentWayPoint >= waypoints.Count){
				currentWayPoint = 0;	
			}
		}
		
		
		float currSpeed = Mathf.Abs (transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z);
		
		float maxAngDrag = 5.0f;
		float curAngDrag = 1.0f;
		float aDragLerpTime = currSpeed * 0.1f;
		
		float maxDrag = 5.0f;
		float curDrag = 1.0f;
		float dragLerpTime = currSpeed * 0.1f;
		
		float myAngDrag = Mathf.Lerp(curAngDrag,maxAngDrag,aDragLerpTime);
		float myDrag = Mathf.Lerp(curDrag,maxDrag,dragLerpTime);
		
		GetComponent<Rigidbody>().angularDrag = myAngDrag;
		GetComponent<Rigidbody>().drag = myDrag;
		
	}
}
