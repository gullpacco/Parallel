using UnityEngine;
using System.Collections;

public class PlatformCheck : MonoBehaviour {

    // Use this for initialization
    PillarController[] selectedPillars;
    int pillarCount = 0;
    PlayerController[] players;



    void Awake() {
        players = GameObject.FindObjectsOfType<PlayerController>();
        selectedPillars = new PillarController[GameObject.FindObjectsOfType<PillarController>().Length];
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

        if(players[0].transform.position.x> players[1].transform.position.x)
        {
            transform.position = new Vector2(players[1].transform.position.x, transform.position.y);
           
        }
        else
            transform.position = new Vector2(players[0].transform.position.x, transform.position.y);

    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        PillarController currentP;
        bool doubled = false;

        if (coll.tag == "Pillar")
        {
            currentP = coll.transform.GetComponent<PillarController>();

            if (pillarCount == 0)
            { selectedPillars[0] = currentP;
                pillarCount=1;
            }
            else
            {
                foreach (PillarController pillar in selectedPillars)
                {
                    if (currentP == pillar)
                    {
                        doubled = true;
                        break; }

                }

                if(!doubled)
                 selectedPillars[pillarCount++] = currentP;

                Debug.Log(pillarCount);

            }
        }

    }

    public void CheckpointReached()
    {

        for (int j=0; j<pillarCount; j++)
        {
            selectedPillars[j].locked = true;
            selectedPillars[j] = null;
        }
        pillarCount = 0;
    }
}
