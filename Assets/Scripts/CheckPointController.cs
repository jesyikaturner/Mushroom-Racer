using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {
	
	public Transform[] checkPointArray;
	public static int currCheckPoint = 0;
	public static int currLap = 0;
	
	public static int enCurrCheckPoint = 0;
	public static int enCurrLap = 0;
	
	
	public static Vector3 startPos;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		currCheckPoint = 0;
		currLap = 0;
		
		enCurrCheckPoint = 0;
		enCurrLap = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
