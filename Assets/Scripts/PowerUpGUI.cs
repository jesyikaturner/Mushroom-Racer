using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpGUI : MonoBehaviour {

	public Sprite projectile, trap, boost, none;
	public PlayerProperties playerProperties;
	public Image powerUpGUI;
	private GameObject playerGameObject;
	
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		playerProperties = playerGameObject.GetComponent<PlayerProperties>();
	}
	
	// Update is called once per frame
	void Update () {

		if (playerProperties.hasProjectile)
		{
			powerUpGUI.sprite = projectile;	
		}
		if (playerProperties.hasBoost)
		{
			powerUpGUI.sprite = boost;
		}
		if (playerProperties.hasTrap)
		{
			powerUpGUI.sprite = trap;
		}
		if (playerProperties.canPickUp)
		{
			powerUpGUI.sprite = none;
		}
	}
}

