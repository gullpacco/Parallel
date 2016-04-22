using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		/*if(Input.GetKeyDown(KeyCode.Space))
		{
			Cursor.visible = true;
		}*/


	}

	public void ClickBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.8f, .8f); //Il pulsante si rimpicciolisce

		if (selectedButton.name == "btnStart") 
		{
			Application.LoadLevel ("LevelSelection");
		} 
		else if (selectedButton.name == "btnOptions") 
		{
			Application.LoadLevel ("OptionsMenu");
		} 
		else if (selectedButton.name == "btnCredits") 
		{
			Application.LoadLevel ("CreditsScene");
		}
		else if (selectedButton.name == "btnQuit") 
		{
			Application.Quit();
		}

	}

	public void OverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.9f, .9f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}


}
