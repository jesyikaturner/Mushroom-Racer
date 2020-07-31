using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	
	public float raceStartTimer = 0.0f;
	public float resetRaceStartTimer = 0.0f;
	
	public int totalLaps = 3;
	public GameObject playerCar;
	//public GameObject[] enemyCars;
	public GameObject enemyCar;
	public static bool raceFinshed = false;
	public static bool playerWin = false;
	

	// Use this for initialization
	void Start () {
		resetRaceStartTimer = raceStartTimer;
		playerCar = GameObject.FindGameObjectWithTag("Player");
		//enemyCars = GameObject.FindGameObjectsWithTag("Enemy");
		enemyCar = GameObject.FindGameObjectWithTag("Enemy");
		PlayerMovement playerMovement = playerCar.GetComponent<PlayerMovement>();
		playerMovement.enabled = false;
		raceFinshed = false;
		playerWin = false;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement playerMovement = playerCar.GetComponent<PlayerMovement>();
		
		raceStartTimer -= Time.deltaTime;
		if(raceStartTimer <= 0.0f){
			playerMovement.enabled = true;
			EnemyMovement.raceStarted = true;
			raceStartTimer = 0.0f;
		}
		
		if(Global.pause){
			EnemyMovement.raceStarted = false;
			playerMovement.enabled = false;
			Debug.Log ("Paused");
		}
		
		if(CheckPointController.currLap == totalLaps+1){
			EnemyMovement.raceStarted = false;
			playerMovement.speed = 0.0f;
			playerMovement.reverseSpeed = 0.0f;
			playerMovement.turnSpeed = 0.0f;
			if(!raceFinshed){
				Global.playerWins++;
				playerWin = true;
				Debug.Log ("Player Win!");
				Debug.Log("Wins: " + Global.playerWins);
				//Debug.Log("Loses: " + Global.enemyWins);
				raceFinshed = true;
			}
		}
		
		if(CheckPointController.enCurrLap == totalLaps+1){
			EnemyMovement.raceStarted = false;
			playerMovement.speed = 0.0f;
			playerMovement.reverseSpeed = 0.0f;
			playerMovement.turnSpeed = 0.0f;
			if(!raceFinshed){
				Global.enemyWins++;
				Debug.Log ("Enemy Win!");
				//Debug.Log("Wins: " + Global.playerWins);
				Debug.Log("Loses: " + Global.enemyWins);
				raceFinshed = true;
			}
		}
		
	}
}
