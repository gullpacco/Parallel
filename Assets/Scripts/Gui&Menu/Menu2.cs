using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour {
	
	public Button btnStart;
	public Button btnOptions;
	public Button btnCredits;
	public Button btnQuit;

	void Start() {
		Time.timeScale=1;
		
		btnStart.Select();
	}
	
	public void EnableAnimator(Animator anim)
	{
		anim.SetBool("atWorld1", true);
	}
	
	public void DisableAnimator(Animator anim)
	{
		anim.SetBool("atWorld1", false);
		anim.SetBool("atWorld2", false);
		anim.SetBool("atWorld3", false);
	}
	
	public void EnableFirstLeft(Animator anim)
	{
		anim.SetBool("atWorld1", false);
		anim.SetBool("atWorld2", true);
	}
	
	public void DisableFirstLeft(Animator anim)
	{
		anim.SetBool("atWorld1", true);
		anim.SetBool("atWorld2", false);
	}
	
	public void EnableSecondLeft(Animator anim)
	{
		anim.SetBool("atWorld2", false);
		anim.SetBool("atWorld3", true);
	}
	
	public void DisableSecondLeft(Animator anim)
	{
		anim.SetBool("atWorld2", true);
		anim.SetBool("atWorld3", false);
	}

	public void DisableMenuAnimator(Animator anim)
	{
		anim.SetBool("isMenuDisplayed", false);
		btnStart.interactable=true;
		btnOptions.interactable=true;
		btnCredits.interactable=true;
		btnQuit.interactable=true;
	}
	
	public void EnableMenuAnimator(Animator anim)
	{
		anim.SetBool("isMenuDisplayed", true);
		btnStart.interactable=false;
		btnOptions.interactable=false;
		btnCredits.interactable=false;
		btnQuit.interactable=false;
	}
	
	public void ShowOptions(Animator optionsAnim)
	{
		optionsAnim.SetBool("ShowOptions", true);
	}
	
	public void HideMenu(Animator menuAnim)
	{
		menuAnim.SetBool("HideMenu", true);
	}
	
	public void HideOptions(Animator optionsAnim)
	{
		optionsAnim.SetBool("ShowOptions", false);
	}
	
	public void ShowMenu(Animator menuAnim)
	{
		menuAnim.SetBool("HideMenu", false);
	}
	
	public void NavigateTo(int scene)
	{
		Application.LoadLevel(scene);
	}

	public void ClickBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.8f, .8f); //Il pulsante si rimpicciolisce
		/*if (selectedButton.name == "btnOptions") 
		{
			Application.LoadLevel ("OptionsMenu");
		} */
		if (selectedButton.name == "btnCredits") 
		{
			Application.LoadLevel ("CreditsScene");
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
		selectedButton.transform.localScale = new Vector2(.7f, .7f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}


}
