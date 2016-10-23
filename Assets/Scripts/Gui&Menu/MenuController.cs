using UnityEngine;
using System.Collections;


public class MenuController : MonoBehaviour {
	public GameObject menuPanel;
	public GameObject exitPanel;
	// Use this for initialization
	void Start () {
		menuPanel.SetActive (true);
		exitPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel (1);
	}
	
	public void QuitGame()
	{
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
