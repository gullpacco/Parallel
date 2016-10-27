using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject Loading;

    bool paused = false;
    public GameObject pauseMenu;
    public static GameController instance;
    public bool ended;
    public bool complete;
    public GameObject [] textToHide;
    public Text hideText;
    public Material groundMaterial;

    private float loadingTimer = 0;

    public string musicTrack;
    void Awake()
    {
        instance = this;
        if (!complete)
        {
            Loading.SetActive(false);

            GameObject[] gos = (GameObject[])FindObjectsOfType(typeof(GameObject));
            GameObject collisions;
            GameObject tmp;
            for (int i = 0; i < gos.Length; i++)
            {

                if (gos[i].name.Contains("Collisions"))
                {
                    if (gos[i].transform.childCount > 1)
                    {
                        collisions = gos[i].transform.GetChild(0).gameObject;
                        if (collisions.activeSelf)
                            collisions.SetActive(false);
                        tmp = gos[i].transform.GetChild(1).gameObject;

                    }
                    else
                        tmp = gos[i].transform.GetChild(0).gameObject;
                    tmp.tag = "Ground";
                    tmp.layer = 9;

                }

                else if (gos[i].name.Contains("Lava"))
                {
                    if (gos[i].transform.childCount > 0)
                    {

                        if (gos[i].transform.childCount > 1)
                        {

                            tmp = gos[i].transform.GetChild(1).gameObject;

                        }
                        else
                            tmp = gos[i].transform.GetChild(0).gameObject;
                        tmp.tag = "Lava";
                        tmp.layer = 16;

                    }
                }

                //else if (gos[i].name.Contains("Terreno"))
                //    {
                //        MeshRenderer renderer = gos[i].transform.GetChild(0).GetComponent<MeshRenderer>();
                //    renderer.sortingLayerName = "Main";
                //        renderer.sortingOrder = 3;
                //    renderer.material = groundMaterial;



                //}
                //if (gos[i].name.Contains("Traguardo") || gos[i].name.Contains("CheckPoint"))
                //{
                //    if (gos[i].transform.childCount > 0)
                //    {

                //        MeshRenderer renderer = gos[i].transform.GetChild(0).GetComponent<MeshRenderer>();
                //        renderer.material = groundMaterial;

                //        renderer.sortingLayerName = "Main";
                //        renderer.sortingOrder = 4;
                //    }



          //      }
            }
        }
    }
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
       if( AudioManager.instance.StopIfDifferent(musicTrack))
        StartCoroutine(PlayMusic());
	}

    IEnumerator PlayMusic()
    {
        yield return new WaitForEndOfFrame();
        AudioManager.instance.PlaySound(musicTrack);

    }

    // Update is called once per frame
    void Update () {

        NextLevel();

        if (ended)
        {
			
           /* if (Input.GetKeyDown(KeyCode.M))
            {
                Application.LoadLevel("Menu2.0");
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }*/
        }

        else
        {
            if (!paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown("joystick button 7"))
                {
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                    paused = true;
					GameObject.Find("btnResume").GetComponent<Button>().Select();
                }
            }
            else
            {
                if (Input.GetKeyDown("joystick button 7")|| Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    paused = false;
                }
				
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					Application.LoadLevel(1);
				}
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					Application.LoadLevel(2);
				}
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					Application.LoadLevel(3);
				}
				if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					Application.LoadLevel(4);
				}
            }
			/*
            if (Input.GetKeyDown(KeyCode.M) && paused)
            {
                Application.LoadLevel("Menu2.0");
            }

            if (Input.GetKeyDown(KeyCode.R) && paused)
            {
                Application.LoadLevel(Application.loadedLevel);
            }*/

        }

        if(!paused & !ended & Input.GetKeyDown(KeyCode.H))
        {
            for (int k = 0; k < textToHide.Length; k++)
            { if (textToHide[k].activeSelf)
                {
                    textToHide[k].SetActive(false);
                    hideText.text = "H: Show controls";
                }
                else
                {
                    textToHide[k].SetActive(true);
                    hideText.text = "H: Hide controls";
                }
                }
        }

    }

	public void OverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1.3f, 1.3f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(1f, 1f); //Il pulsante si rimpicciolisce
	}
	
	public void OverBtnEnd(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.4208f, .4208f); //Il pulsante si rimpicciolisce
	}

	public void OutBtnEnd(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.3104f,.3104f); //Il pulsante si rimpicciolisce
	}
	
	public void ClickBtn(Button selectedButton)
	{
		//selectedButton.transform.localScale = new Vector2(.8f, .8f); //Il pulsante si rimpicciolisce
		
		if (selectedButton.name == "btnResume") 
		{
			Time.timeScale = 1;
			pauseMenu.SetActive(false);
			paused = false;
		}
		else if (selectedButton.name == "btnRestart") 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		else if (selectedButton.name == "btnMainMenu") 
		{
			AudioManager.instance.stopAllMusic();
			Application.LoadLevel("MenuSceneLucca");
		}
		else if (selectedButton.name == "btnMainMenuEnd" && ended) 
		{
			Application.LoadLevel("MenuSceneLucca");
		}
		else if (selectedButton.name == "btnNext" && ended) 
		{
            Loading.SetActive(true);

		//	Application.LoadLevel(Application.loadedLevel + 1);
		}
		else if (selectedButton.name == "btnRestartEnd" && ended) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

    void NextLevel()
    {
       
        if (Loading.activeInHierarchy)
        {
            loadingTimer += Time.unscaledDeltaTime;
            Debug.Log(loadingTimer);
            if(loadingTimer >= 2)
                Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
