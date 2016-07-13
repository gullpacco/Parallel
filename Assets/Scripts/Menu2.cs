using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour {
	
	public Button btnStart;
	public Button btnOptions;
	public Button btnCredits;
	public Button btnQuit;
	
	// Use this for initialization
	/*void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Cursor.visible = true;
		}
	}*/
	
    void Start() {
       
    }
    void Update() {
		
    }
	
	
	
	public void EnableAnimator(Animator anim)
	{
		anim.SetBool("isDisplayed", true);
	}
	
	public void EnableFirstLeft(Animator anim)
	{
		anim.SetBool("isDisplayed", false);
		anim.SetBool("isWorld1Displayed", true);
	}
	
	public void EnableSecondLeft(Animator anim)
	{
		anim.SetBool("isWorld1Displayed", false);
		anim.SetBool("isWorld2Displayed", true);
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
	
	public void NavigateTo(int scene)
	{
		Application.LoadLevel(scene);
	}

	public void ClickBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.8f, .8f); //Il pulsante si rimpicciolisce
		if (selectedButton.name == "btnOptions") 
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
/*
	public void OverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.9f, .9f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}
*/

}
