using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour {
	
	public int health = 4;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ApplyDamage(int damage){
		SpawnController spawnController = GetComponent<SpawnController>();
		PlayerMovement playerMovement = GetComponent<PlayerMovement>();
		EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
		
		if(gameObject.tag == "Player"){
			health -= damage;
			if(health == 0){
				spawnController.activeRespawnTimer = true;
				playerMovement.speed = 0.0f;		//reset values after respawn timer
				playerMovement.turnSpeed = 0.0f;
				//health = 4;
			}
		}
		
		if(gameObject.tag == "Enemy"){
			health -= damage;
			if(health == 0){
				spawnController.activeRespawnTimer = true;
				enemyMovement.aiSpeed = 0.0f;		//reset values after respawn timer
				enemyMovement.aiTurnSpeed = 0.0f;
				//health = 4;
			}
		}
	}
}
