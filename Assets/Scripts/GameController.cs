using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    bool paused = false;
    public GameObject pauseMenu;
    public static GameController instance;
    public bool ended;
    public Text timer;
    public int seconds,
                   minutes,
                    hours;
    string secondFormat ="00", minuteFormat="00", hourFormat="00";

    void Awake()
    {
        instance = this;
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
                Application.LoadLevel("MenuPrincipale");
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("next");
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
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                    paused = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    paused = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.M) && paused)
            {
                Application.LoadLevel("MenuPrincipale");
            }

            if (Input.GetKeyDown(KeyCode.R) && paused)
            {
                Application.LoadLevel(Application.loadedLevel);
            }

            StartCoroutine(IncreaseSecond());
            timer.text = hourFormat + " : " + minuteFormat + " : " + secondFormat;
        }

    }


    IEnumerator IncreaseSecond()
    {
        yield return new WaitForSeconds(1);


        if (seconds < 59)
        {
            seconds++;
        }
        else
        {
            seconds = 0;
            if (minutes < 59)
                minutes++;
            else
            {
                minutes = 0;
                hours++;
            }
        }

        if (seconds < 10)
        {
            secondFormat = "0" + seconds; ;
        }
        else secondFormat = ""+ seconds;
        if (minutes < 10)
        {
            minuteFormat = "0" + minutes;
        }
        else minuteFormat = "" + minutes;
        if (hours < 10)
            hourFormat = "0" + hours;
        else hourFormat = "" + hours;
        StopAllCoroutines();
    }

   

}
