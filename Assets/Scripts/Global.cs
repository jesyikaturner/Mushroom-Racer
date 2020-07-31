using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	public Canvas gameplay, pauseGame, raceFinished;
	public Text raceFinishedText, winsText, lossesText;
	[SerializeField] private Canvas activeCanvas;
	[SerializeField] private Canvas prevCanvas;
	[SerializeField] private bool transitionActive = true;

	public static int enemyWins;
	public static int playerWins;
	
	public static bool pause = false;
	public bool finished = false;
	
	// Use this for initialization
	void Start () {
		playerWins = PlayerPrefs.GetInt("Wins");
		enemyWins = PlayerPrefs.GetInt("Loses");
		winsText.text = playerWins.ToString();
		lossesText.text = enemyWins.ToString();

		activeCanvas = gameplay;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("Wins") < playerWins){
			PlayerPrefs.SetInt("Wins",playerWins);
			winsText.text = playerWins.ToString();
		}
		if(PlayerPrefs.GetInt ("Loses")<enemyWins){
			PlayerPrefs.SetInt("Loses",enemyWins);
			lossesText.text = enemyWins.ToString();
		}

		if(GameState.raceFinshed)
        {
			if (GameState.playerWin)
            {
				raceFinishedText.text = "You Won!";
            }
            else
            {
				raceFinishedText.text = "You Lost!";
            }

			if(!finished)
            {
				transitionActive = false;
				SetCanvas("FINISHED");
				finished = true;
			}

		}
		
		if(Input.GetKeyUp(KeyCode.P)){
			pause = !pause;
			transitionActive = false;

			if(pause && !transitionActive)
			{
				SetCanvas("PAUSE");
			}
			
			if (!pause && !transitionActive)
			{
				SetCanvas("GAMEPLAY");
			}
		}
	}

	public void SetCanvas(string menu)
	{
		menu.ToUpper();
		switch (menu)
		{
			case "GAMEPLAY":
				prevCanvas = activeCanvas;
				activeCanvas = gameplay;
				break;
			case "PAUSE":
				prevCanvas = activeCanvas;
				activeCanvas = pauseGame;
				break;
			case "FINISHED":
				prevCanvas = activeCanvas;
				activeCanvas = raceFinished;
				break;
			default:
				Debug.LogError(string.Format("{0} is an invalid canvas name", menu));
				break;

		}

		if (!transitionActive)
		{
			StartCoroutine(CanvasFadeTrasition(0.01f, 0.01f));
			transitionActive = true;
		}
	}

	private IEnumerator CanvasFadeTrasition(float outDelay, float inDelay)
	{
		CanvasGroup prevCanvasGroup = prevCanvas.GetComponent<CanvasGroup>();
		while (prevCanvasGroup.alpha > 0)
		{
			prevCanvasGroup.alpha -= 0.1f;
			yield return new WaitForSeconds(outDelay);
		}
		prevCanvas.gameObject.SetActive(false);

		CanvasGroup activeCanvasGroup = activeCanvas.GetComponent<CanvasGroup>();
		activeCanvasGroup.alpha = 0;
		activeCanvas.gameObject.SetActive(true);

		while (activeCanvasGroup.alpha < 1)
		{
			activeCanvasGroup.alpha += 0.1f;
			yield return new WaitForSeconds(inDelay);
		}

		transitionActive = false;
	}

	public void BTN_Gameplay()
	{
		pause = false;
		transitionActive = false;
		SetCanvas("GAMEPLAY");
	}

	public void BTN_MainMenu()
	{
		transitionActive = false;
		SceneManager.LoadScene(0);
	}
}
