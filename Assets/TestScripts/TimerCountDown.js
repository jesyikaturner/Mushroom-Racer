#pragma strict
/*
private var startTime :float;
var textTime :String;

function Start () {
	startTime = Time.time;
}

function OnGUI(){
	var guiTime = Time.time - startTime;
	var min :int = guiTime/60;
	var sec :int = guiTime%60;
	var fract :int = (guiTime * 100) % 100;
	
	textTime = String.Format("{0:00}:{1:00}:{2:00}",min,sec,fract);
	GUI.Label(Rect(400,25,100,30), textTime);
}

function Update () {

}*/

    private var startTime :float;
    private var restSeconds : int;
    private var roundedRestSeconds : int;
    private var displaySeconds : int;
    private var displayMinutes : int;
     
    var countDownSeconds : int;
    private var text :String;
    static var timeLimitReached :boolean = false;
     
     var timerStyle :GUISkin;
     
function Awake() {
    startTime = Time.time;
}

function Start(){
	timeLimitReached = false;
}

//var lerpedColor :Color = Color.white;
     
function OnGUI () {
    //make sure that your time is based on when this script was first called
    //instead of when your game started
    
    //var roseIcon :Texture2D;
    
    GUI.skin = timerStyle;
    
    if (!timeLimitReached){
    var guiTime = Time.time - startTime;
     
    restSeconds = countDownSeconds - (guiTime);
    
    //lerpedColor = Color.Lerp(Color.white, Color.black,10*Time.deltaTime);
    //GUI.contentColor = lerpedColor;
     
    //display messages or whatever here -->do stuff based on your timer
    
    if (restSeconds == restSeconds/2){
    	print("half the time");
    }
    
    if (restSeconds == 60) {
    	print ("One Minute Left");
	}
    if (restSeconds == 0) {
    	print ("Time is Over");
    	guiTime = 0;
    	timeLimitReached = true;
    	//do stuff here
	}
     
    //display the timer
    roundedRestSeconds = Mathf.CeilToInt(restSeconds);
    displaySeconds = roundedRestSeconds % 60;
    displayMinutes = roundedRestSeconds / 60;
     }
    text = String.Format ("{0:00}:{1:00}", displayMinutes, displaySeconds);
    GUI.Label(Rect (43, 10, 100, 90), text);
}

