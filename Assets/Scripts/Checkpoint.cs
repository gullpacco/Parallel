using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    int triggeredPlayers = 0;
    bool canTrigger = true;
    CheckPointManager cpm;
    PlatformCheck platformCheck;

    void Awake()
    {
        cpm = GameObject.FindObjectOfType<CheckPointManager>();
        platformCheck = GameObject.FindObjectOfType<PlatformCheck>();

    }

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        if (triggeredPlayers == 2 && canTrigger)
        {
            cpm.ActivateCheckpoint(this);
            triggeredPlayers = 0;
            canTrigger = false;
            platformCheck.CheckpointReached();
            Debug.Log(transform.position.x);
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
