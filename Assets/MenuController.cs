using UnityEngine;
using System.Collections;


public class MenuController : MonoBehaviour {
	public GameObject menuPanel;
	public GameObject exitPanel;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		//Application.loadedLevel (0);
	}

	public void loadLevel ()
	{
		Application.LoadLevel(1);
	}
	
	public void QuitGame()
	{
		//menuPanel.GetComponent<TweenAlpha>.
		menuPanel.SetActive (false);
		exitPanel.SetActive (true);

	}
}
