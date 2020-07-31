using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {
	
	private Transform playerTransform;
	private Transform enemyTransform;
	
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		
		SpawnController spawnController = GetComponent<SpawnController>();
		PlayerMovement playerMovement = GetComponent<PlayerMovement>();
		EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
		/*
		if(!other.CompareTag("Player")){
			return;	
		}*/
		if(other.tag == "Player"){
			if(transform == playerTransform.GetComponent<CheckPointController>().checkPointArray[CheckPointController.currCheckPoint].transform){
				Debug.Log ("We are at check point: " +CheckPointController.currCheckPoint);
				if(CheckPointController.currCheckPoint + 1 < playerTransform.GetComponent<CheckPointController>().checkPointArray.Length){
					if(CheckPointController.currCheckPoint == 0){
						CheckPointController.currLap++;
						Debug.Log ("We are on lap: " + CheckPointController.currLap);
					}
					CheckPointController.currCheckPoint++;
				}else{
					CheckPointController.currCheckPoint = 0;	
				}

			}
		}
		if(other.tag=="Enemy"){
			if(transform == enemyTransform.GetComponent<CheckPointController>().checkPointArray[CheckPointController.enCurrCheckPoint].transform){
				Debug.Log ("They are at check point: " +CheckPointController.enCurrCheckPoint);
				if(CheckPointController.enCurrCheckPoint + 1 < enemyTransform.GetComponent<CheckPointController>().checkPointArray.Length){
					if(CheckPointController.enCurrCheckPoint == 0){
						CheckPointController.enCurrLap++;
						Debug.Log ("They are on lap: " + CheckPointController.enCurrLap);
					}
					CheckPointController.enCurrCheckPoint++;
				}else{
					CheckPointController.enCurrCheckPoint = 0;	
				}
			}
		}
	}
}
