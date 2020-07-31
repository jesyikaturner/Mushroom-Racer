using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	[SerializeField] private Canvas activeCanvas;
	[SerializeField] private Canvas prevCanvas;
	[SerializeField] private bool transitionActive = true;

	public Canvas mainMenu, instructions, trackSelect;

	public void Start()
	{
		activeCanvas = mainMenu;
	}

	public void SetCanvas(string menu)
	{
		menu.ToUpper();
		switch(menu)
		{
			case "MENU":
				prevCanvas = activeCanvas;
				activeCanvas = mainMenu;
				break;
			case "TRACKS":
				prevCanvas = activeCanvas;
				activeCanvas = trackSelect;
				break;
			case "INSTRUCTIONS":
				prevCanvas = activeCanvas;
				activeCanvas = instructions;
				break;
			default:
				Debug.LogError(string.Format("{0} is an invalid canvas name",menu));
				break;

		}

		if(!transitionActive)
		{
			StartCoroutine(CanvasFadeTrasition(0.01f, 0.01f));
			transitionActive = true;
		}
	}

	public void BTN_Menu()
	{
		transitionActive = false;
		SetCanvas("MENU");

	}

	public void BTN_TrackSelect()
	{
		transitionActive = false;
		SetCanvas("TRACKS");

	}

	public void BTN_Instructions()
	{
		transitionActive = false;
		SetCanvas("INSTRUCTIONS");

	}

	public void BTN_LoadTrack1()
	{
		SceneManager.LoadScene("Track01");
	}

	public void BTN_LoadTrack2()
	{
		SceneManager.LoadScene("Track02");
	}

	public void BTN_LoadTrack3()
	{
		SceneManager.LoadScene("Track03");
	}

	public void BTN_LoadTrack4()
	{
		SceneManager.LoadScene("Track04");
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

}
