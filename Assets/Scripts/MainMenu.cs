using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public int levelToLoad;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void startLevel(Button selectedButton)
	{
		levelToLoad = int.Parse(selectedButton.name);

		Application.LoadLevel(levelToLoad);
	}

	public void MouseOverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.9f, .9f); //Il pulsante si rimpicciolisce
	}

	public void MouseOutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}

}
