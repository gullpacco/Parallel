using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour {
	
	public Button btnStart;
	public Button btnOptions;
	public Button btnCredits;
	public Button btnQuit;
	
	public Button btnGoBack;
	public Dropdown drpResolution;
	
	public InputField txtInputJump;
	
	public Button btnW1L1;
	public Button btnW2L1;
	public Button btnW3L1;
	
	private bool btnStartSelected;
	private bool btnOptionsSelected;
	private bool btnCreditsSelected;
	private bool btnQuitSelected;
	
	//private bool onOptions;
	
	void Start() {
		Time.timeScale=1;
		btnStart.Select();
	}
	
	void Update()
	{
		/*if(Input.GetKeyDown(KeyCode.DownArrow) && btnStartSelected==false && btnOptionsSelected==false && btnCreditsSelected==false && btnQuitSelected==false && onOptions==false)
		{
			btnStart.Select();
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) && btnStartSelected==false && btnOptionsSelected==false && btnCreditsSelected==false && btnQuitSelected==false &&onOptions==false)
		{
			btnQuit.Select();
		}*/
		/*Debug.Log(PlayerController.jumpUp);
		Debug.Log(PlayerController.moveFrontUp);
		Debug.Log(PlayerController.moveBackUp);
		
		Debug.Log(PlayerController.jumpDown);
		Debug.Log(PlayerController.moveFrontDown);
		Debug.Log(PlayerController.moveBackDown);*/
	}
	public void EnableAnimator(Animator anim)
	{
		anim.SetBool("atWorld1", true);
		btnW1L1.Select();
	}
	
	public void DisableAnimator(Animator anim)
	{
		anim.SetBool("atWorld1", false);
		anim.SetBool("atWorld2", false);
		anim.SetBool("atWorld3", false);
		btnStart.Select();
	}
	
	public void EnableFirstLeft(Animator anim)
	{
		anim.SetBool("atWorld1", false);
		anim.SetBool("atWorld2", true);
		btnW2L1.Select();
	}
	
	public void DisableFirstLeft(Animator anim)
	{
		anim.SetBool("atWorld1", true);
		anim.SetBool("atWorld2", false);
		btnW1L1.Select();
	}
	
	public void EnableSecondLeft(Animator anim)
	{
		anim.SetBool("atWorld2", false);
		anim.SetBool("atWorld3", true);
		btnW3L1.Select();
	}
	
	public void DisableSecondLeft(Animator anim)
	{
		anim.SetBool("atWorld2", true);
		anim.SetBool("atWorld3", false);
		btnW2L1.Select();
	}

	public void DisableMenuAnimator(Animator anim)
	{
		anim.SetBool("isMenuDisplayed", false);
	}
	
	public void EnableMenuAnimator(Animator anim)
	{
		anim.SetBool("isMenuDisplayed", true);
	}
	
	public void ShowOptions(Animator optionsAnim)
	{
		optionsAnim.SetBool("ShowOptions", true);
		drpResolution.Select();
		//onOptions=true;
	}
	
	public void HideMenu(Animator menuAnim)
	{
		menuAnim.SetBool("HideMenu", true);
	}
	
	public void HideOptions(Animator optionsAnim)
	{
		optionsAnim.SetBool("ShowOptions", false);
		//onOptions=false;
	}
	
	public void ShowMenu(Animator menuAnim)
	{
		menuAnim.SetBool("HideMenu", false);
		btnStart.Select();
	}
	
	public void ShowControls(Animator optionsAnim)
	{
		optionsAnim.SetBool("ShowControls", true);
		txtInputJump.Select();
	}
	
	public void HideControls(Animator optionsAnim)
	{
		optionsAnim.SetBool("ShowControls", false);
		drpResolution.Select();
	}
	
	public void NavigateTo(int scene)
	{
		Application.LoadLevel(scene);
	}

	public void ClickBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.8f, .8f); //Il pulsante si rimpicciolisce
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
		selectedButton.transform.localScale = new Vector2(1.1f, 1.1f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}
	
	/*public void DeselectStartOver(Button selectedButton)
	{
		if((btnStartSelected!=false || btnOptionsSelected!=false || btnCreditsSelected!=false || btnQuitSelected!=false)&& onOptions==false)
		{
			GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
		}
	
		if(selectedButton==btnStart)
		{
			btnStartSelected=true;
			btnOptionsSelected=false;
			btnCreditsSelected=false;
			btnQuitSelected=false;
		}
		if(selectedButton==btnOptions)
		{
			btnStartSelected=false;
			btnOptionsSelected=true;
			btnCreditsSelected=false;
			btnQuitSelected=false;
		}
		if(selectedButton==btnCredits)
		{
			btnStartSelected=false;
			btnOptionsSelected=false;
			btnCreditsSelected=true;
			btnQuitSelected=false;
		}
		if(selectedButton==btnQuit)
		{
			btnStartSelected=false;
			btnOptionsSelected=false;
			btnCreditsSelected=false;
			btnQuitSelected=true;
		}
	}
	
	public void DeselectStartOut(Button selectedButton)
	{
		if(selectedButton==btnStart)
		{
			btnStartSelected=false;
		}
		if(selectedButton==btnOptions)
		{
			btnOptionsSelected=false;
		}
		if(selectedButton==btnCredits)
		{
			btnCreditsSelected=false;
		}
		if(selectedButton==btnQuit)
		{
			btnQuitSelected=false;
		}
	}*/

}
