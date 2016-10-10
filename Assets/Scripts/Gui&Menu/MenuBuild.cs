using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuBuild : MonoBehaviour {
	
	public Button btnStart;
	public Button btnQuit;
	
	private bool btnStartSelected;
	private bool btnQuitSelected;
	
	public AudioClip clip;
	//private bool onOptions;
	
	void Start() {
		Time.timeScale=1;
		btnStart.Select();
		
		AudioManager.instance.stopAllMusic();
		
		AudioManager.instance.PlaySound("MainTheme");
	}

	public void ClickBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.8f, .8f); //Il pulsante si rimpicciolisce
		if (selectedButton.name == "btnStart") 
		{
			Application.LoadLevel (Application.loadedLevel+1);
		}
		else if (selectedButton.name == "btnQuit") 
		{
			Application.Quit();
		}
	}
	
	public void loadLevel (string levelName)
	{
		Application.LoadLevel(levelName);
	}
	
	public void OverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1.1f, 1.1f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}

}