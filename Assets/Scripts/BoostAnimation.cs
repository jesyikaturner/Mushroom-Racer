
using UnityEngine;
using System.Collections;

public class BoostAnimation : MonoBehaviour {
	
	public int columns = 8;
	public int rows = 8;
	
	public int currFrame = 1;
	public int currAnim = 0;
	public float animTime = 0.0f;
	public float fps = 10.0f;
	
	private Vector2 framePosition;
	private Vector2 frameSize;
	private Vector2 frameOffset;
	private int i;
	
	private int boostMin = 37;
	private int boostMax = 38;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayAnimation();
	}
	
	void PlayAnimation(){
		animTime -= Time.deltaTime;
		if(animTime <=0){
			currFrame+=1;
			animTime += 1.0f/fps;
		}
		currFrame = Mathf.Clamp(currFrame,boostMin, boostMax +1);
			if(currFrame > boostMax){
				currFrame = boostMin;
			}
	
		
		framePosition.y = 1;
		for(i = currFrame; i > columns; i -= rows){
			framePosition.y += 1;
		}
		framePosition.x = i-1;
		
		frameSize = new Vector2(1.0f/columns, 1.0f / rows);
		frameOffset = new Vector2(framePosition.x/columns, 1.0f - (framePosition.y/rows));
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", frameSize);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", frameOffset);
		
	}
}
