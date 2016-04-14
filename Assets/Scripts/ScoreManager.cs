using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text timer;
    public Text finalTime;
    public int lvNum;
    public Text bestTimeText;
    public string bestTime;
    string playerName;
    string bestPlayerName;
    public int seconds,
                  minutes,
                   hours;
    string secondFormat = "00", minuteFormat = "00", hourFormat = "00";

    public int highScore;
    public GameObject endLevelMenu;
    public Text bestFinal;

    public int currentScore;
    // Use this for initialization

        void Awake()
    {

        lvNum = Application.loadedLevel;

        if (PlayerPrefs.HasKey("HighScore" + lvNum))
        //// PlayerPrefs.SetInt("HighScore",3000);
        {

            highScore = PlayerPrefs.GetInt("HighScore" + lvNum);

        }


        if (PlayerPrefs.HasKey("BestTime" + lvNum))
        {
            bestTime = "Best Time: " + PlayerPrefs.GetString("BestTime" + lvNum);
            Debug.Log(lvNum);
        }

        else bestTime = "Best Time: 00 : 10 : 00";
        bestTimeText.text = bestTime;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(IncreaseSecond());
        timer.text = hourFormat + " : " + minuteFormat + " : " + secondFormat;


    }

    public void SetHighScore()
    {
        Time.timeScale = 0;
        finalTime.text = timer.text;
        currentScore = seconds + minutes * 60 + hours * 60 * 60;

        
        if (currentScore < highScore)
        {
            
            PlayerPrefs.SetInt("HighScore" + lvNum, currentScore);
            PlayerPrefs.SetString("BestPlayer" + lvNum, playerName);
            PlayerPrefs.SetString("BestTime" + lvNum, timer.text);
        }
        
        bestFinal.text = PlayerPrefs.GetString("BestTime" + lvNum);
        endLevelMenu.SetActive(true);

    }

    


    public void reset()
    {

        minutes = 0;
        hours = 0;
        seconds = 0;
        secondFormat = "00";
        hourFormat = "00";
        minuteFormat = "00";
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
        else secondFormat = "" + seconds;
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
