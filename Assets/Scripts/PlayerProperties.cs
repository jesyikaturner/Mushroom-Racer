
using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {
	public enum PlayerState{
		CarDead = 0,
		CarNormal = 1,
		CarProjectile = 2,
		CarTrap = 3,
		CarBoost = 4
	}
	
	public PlayerState playerState = PlayerState.CarNormal;
	
	//POWERUP
	public GameObject projectile;
	public GameObject trap;
	public GameObject boost;
	
	//POWER SOCKETS
	public Transform projectileSocket;
	public Transform trapSocket;
	public Transform boostSocket;
	
	public bool hasProjectile = false;
	public bool hasTrap = false;
	public bool hasBoost = false;
	
	public bool changeState = false;
	public bool canPickUp = true;
	
	public float boostTimer = 3.0f;
	public float resetBoostTimer = 3.0f;
	public bool boostTimerActive = false;
	
	public float projectileSpeed = 100.0f;
	
	public float boostModifier = 1.5f;
	public float resetSpeed = 0.0f;
	
	// Use this for initialization
	void Start () {
		PlayerMovement playerMovement = GetComponent<PlayerMovement>();
		resetSpeed = playerMovement.speed;
	}
	
	// Update is called once per frame
	void Update () {
		if(changeState){
			SetPlayerState();	
		}
		if(hasProjectile){
			GameObject cloneProjectile;
			Vector3 fireProjectile = transform.forward*projectileSpeed;
			if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
				cloneProjectile = (GameObject) Instantiate(projectile, projectileSocket.transform.position, transform.rotation);
				cloneProjectile.GetComponent<Rigidbody>().AddForce(fireProjectile);
				
				playerState = PlayerState.CarNormal;
				changeState = true;
			}
		}
		if(hasTrap){
			GameObject cloneTrap;
			Vector3 fireTrap = transform.forward;
			
			if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
				cloneTrap = (GameObject) Instantiate(trap, trapSocket.transform.position, transform.rotation);
				cloneTrap.GetComponent<Rigidbody>().AddForce(fireTrap);
				
				playerState = PlayerState.CarNormal;
				changeState = true;
			}
		}
		
		if(hasBoost){
			PlayerMovement playerMovement = GetComponent<PlayerMovement>();
			GameObject cloneBoost;
			if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)){
				cloneBoost = (GameObject) Instantiate(boost, boostSocket.transform.position, transform.rotation);
				cloneBoost.transform.parent = boostSocket;
				
				boostTimerActive = true;
				playerMovement.speed = playerMovement.speed * boostModifier;
			}
			if(boostTimerActive){
					boostTimer -= Time.deltaTime;
					if(boostTimer <= 0){
						
						boostTimerActive = false;
						boostTimer = resetBoostTimer;
						playerMovement.speed = resetSpeed;
						
						playerState = PlayerState.CarNormal;
						changeState = true;
					}
				}
		}
	}
	
	void SetPlayerState(){
		switch(playerState){
		case PlayerState.CarNormal:
			hasProjectile = false;
			hasTrap = false;
			hasBoost = false;
			changeState = false;
			canPickUp = true;
			break;
			
		case PlayerState.CarProjectile:
			hasProjectile = true;
			hasTrap = false;
			hasBoost = false;
			changeState = false;
			canPickUp = false;
			break;
			
		case PlayerState.CarTrap:
			hasProjectile = false;
			hasTrap = true;
			hasBoost = false;
			changeState = false;
			canPickUp = false;
			break;
			
		case PlayerState.CarBoost:
			hasProjectile = false;
			hasTrap = false;
			hasBoost = true;
			changeState = false;
			canPickUp = false;
			break;
			
		case PlayerState.CarDead:
			hasProjectile = false;
			hasTrap = false;
			hasBoost = false;
			changeState = false;
			canPickUp = false;
			break;
		}
	}
}
