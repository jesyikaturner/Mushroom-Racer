using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour {
	
	public static WayPoints start;
	public WayPoints next;
	public bool isStart = false;
	
	void Awake(){
		if(!next){
			Debug.LogWarning ("Error. This waypoint is not connected.");	
		}
		
		if(isStart){
			start = this;	
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position,new Vector3(0.5f,0.5f,0.5f));
		if(next){
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position,next.transform.position);
		}
	}
}
