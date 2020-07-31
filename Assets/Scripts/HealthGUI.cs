using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthGUI : MonoBehaviour {

	public Sprite health_100, health_75, health_50, health_25, health_00;
	public Image guiBackdrop;
	public DamageController damageController;
	private GameObject playerGameObject;
	
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		damageController = playerGameObject.GetComponent<DamageController>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(damageController.health)
		{
			case 4:
				guiBackdrop.sprite = health_100;
				break;
			case 3:
				guiBackdrop.sprite = health_75;
				break;
			case 2:
				guiBackdrop.sprite = health_50;
				break;
			case 1:
				guiBackdrop.sprite = health_25;
				break;
			case 0:
				guiBackdrop.sprite = health_00;
				break;
			default:
				Debug.LogError(string.Format("{0} is an invalid number for health", damageController.health));
				break;
		}
	}
}
