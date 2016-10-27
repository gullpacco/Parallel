using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {

    public string nextLevel;
     ScoreManager sm;
    string playerEnded;


	// Use this for initialization
	void Start () {
        sm = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {

      

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if (playerEnded == null)
                playerEnded = coll.gameObject.name;
            else if (coll.gameObject.name != playerEnded)
            {
                //Application.LoadLevel(nextLevel);
                sm.SetHighScore();
                GameController.instance.ended = true;
                if (Application.loadedLevelName != "PietroMondo2_Medio2_Grafica 1")
                {                 
                    GameObject.Find("btnNext").GetComponent<Button>().Select();
                }

                else if (Application.loadedLevelName == "PietroMondo2_Medio2_Grafica 1")
                {                  
                    GameObject.Find("btnMainMenuEnd").GetComponent<Button>().Select();
                }
            }
        }
    }

  
}
