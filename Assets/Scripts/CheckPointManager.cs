using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {

    Checkpoint[] checkpoints;
    int currentCheckpoint = -1;
    PlayerController[] players;
    PillarController[] pillars;

	// Use this for initialization
	void Start () {
        checkpoints = GameObject.FindObjectsOfType<Checkpoint>();
        players = GameObject.FindObjectsOfType<PlayerController>();

        pillars = GameObject.FindObjectsOfType<PillarController>();
    }

    // Update is called once per frame
    void Update () {
       
	}

    public float Respawn()
    {
        for (int j = 0; j < pillars.Length; j++)
        {
            pillars[j].ResetPillar();
        }
        if (currentCheckpoint >= 0)
        { 
         return checkpoints[currentCheckpoint].gameObject.transform.position.x;

       }
        else Application.LoadLevel(Application.loadedLevel);
        return 0;
    }

    public void ActivateCheckpoint(Checkpoint cp)
    {
        for (int i=0; i<checkpoints.Length; i++)
        {

            if (cp == checkpoints[i])
            {
                currentCheckpoint = i;
                for (int j=0; j < players.Length; j++)
                {
                    players[j].ReachCheckpoint(false);
                }

                return;

            }
        }
    }
}
