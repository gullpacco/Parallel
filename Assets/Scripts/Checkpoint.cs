using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    int triggeredPlayers = 0;
    bool canTrigger = true;
    CheckPointManager cpm;

	// Use this for initialization
	void Start () {
        cpm = GameObject.FindObjectOfType<CheckPointManager>(); 
	}
	
	// Update is called once per frame
	void Update () {
        if (triggeredPlayers == 2)
        {
            cpm.ActivateCheckpoint(this);
            triggeredPlayers = 0;
            canTrigger = false;
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (canTrigger)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (!coll.gameObject.GetComponent<PlayerController>().getCheckpointStatus())
                {
                    triggeredPlayers++;
                    coll.gameObject.GetComponent<PlayerController>().ReachCheckpoint(true);
                }

            }
        }
    }
}
