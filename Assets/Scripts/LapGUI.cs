using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LapGUI : MonoBehaviour {

	public Text lapNumber;

	// Update is called once per frame
	void Update () {
		lapNumber.text = CheckPointController.currLap.ToString();
	}
}
