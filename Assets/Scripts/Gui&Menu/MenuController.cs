using UnityEngine;
using System.Collections;


public class MenuController : MonoBehaviour {
	public GameObject menuPanel;
	public GameObject exitPanel;

    public GameObject Loading;
    private float loadingTimer = 0;

    // Use this for initialization
    void Start () {

        Loading.SetActive(false);

		menuPanel.SetActive (true);
		exitPanel.SetActive (false);
		AudioManager.instance.PlaySound("M_Prova_2");
//		Invoke("play", 1);
	}
	
	// Update is called once per frame
	void Update () {

        if (Loading.activeInHierarchy)
        {
            loadingTimer += Time.unscaledDeltaTime;
            Debug.Log(loadingTimer);
            if (loadingTimer >= 2)
                Application.LoadLevel(1);
        }

    }

//	void play(){
//
//		AudioManager.instance.PlaySound("M_Prova_1");
//
//	}

	public void StartGame()
	{
        AudioManager.instance.PlaySound("S_Button_Confirm");
        Loading.SetActive(true);
		//Application.LoadLevel (1);
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
