using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    bool paused = false;
    public GameObject pauseMenu;
    public static GameController instance;
    public bool ended;
    public bool complete;
    public GameObject [] textToHide;
    public Text hideText;

    void Awake()
    {
        instance = this;
        if (!complete)
        {
            GameObject collisions = GameObject.Find("Collisions").transform.GetChild(0).gameObject;
            if (collisions.activeSelf)
                collisions.SetActive(false);
            GameObject tmp = GameObject.Find("Collisions").transform.GetChild(1).gameObject;
            tmp.tag = "Ground";
            tmp.layer = 9;
        }
    }
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (ended)
        {
            if (Input.GetKeyDown(KeyCode.M))
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
            }
        }

        else
        {
            if (!paused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                    paused = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    paused = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.M) && paused)
            {
                Application.LoadLevel("Menu2.0");
            }

            if (Input.GetKeyDown(KeyCode.R) && paused)
            {
                Application.LoadLevel(Application.loadedLevel);
            }

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


   

}
