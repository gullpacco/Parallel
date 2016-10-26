using UnityEngine;
using System.Collections;


public class MenuController : MonoBehaviour {
	public GameObject menuPanel;
	public GameObject exitPanel;
	// Use this for initialization
	void Start () {

		menuPanel.SetActive (true);
		exitPanel.SetActive (false);
		AudioManager.instance.PlaySound("M_Prova_2");
//		Invoke("play", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void play(){
//
//		AudioManager.instance.PlaySound("M_Prova_1");
//
//	}

	public void StartGame()
	{
        AudioManager.instance.PlaySound("S_Button_Confirm");
		Application.LoadLevel (1);
	}
	
	public void QuitGame()
	{
        AudioManager.instance.PlaySound("S_Button_Confirm");

        Application.Quit ();

//		menuPanel.SetActive (false);
//		exitPanel.SetActive (true);

	}
//	public void YesQuit()
//	{
//		Application.Quit ();
//	}
//	public void YesQuit()
//	{
//		menuPanel.SetActive (true);
//		exitPanel.SetActive (false);
//	}
}
