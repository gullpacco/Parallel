using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {

    Checkpoint[] checkpoints;
    int currentCheckpoint = -1;
    PlayerController[] players;
    Pillar[] pillars;
    CameraController mainCamera;
    Glitch glitch;
    Laser[] lasers;
    ObjectMovement[] moving;
  //  ShooterController[] shooters;

    void Awake()
    {
        checkpoints = GameObject.FindObjectsOfType<Checkpoint>();
        players = GameObject.FindObjectsOfType<PlayerController>();
        mainCamera = GameObject.FindObjectOfType<CameraController>();
        pillars = GameObject.FindObjectsOfType<Pillar>();
        glitch = FindObjectOfType<Glitch>();
        lasers = FindObjectsOfType<Laser>();
        moving = FindObjectsOfType<ObjectMovement>();

       // shooters = GameObject.FindObjectsOfType<ShooterController>();
    }

	// Use this for initialization
	void Start () {
       
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

        for (int j = 0; j < lasers.Length; j++)
        {

            lasers[j].Reset();
        }

        for (int j = 0; j < moving.Length; j++)
        {

            moving[j].SetValues();
        }

        //for (int k=0; k<shooters.Length; k++)
        //{
        //    shooters[k].ResetShooter();
        //}
        //if (currentCheckpoint >= 0)
        //{ 
        float spawnPoint = checkpoints[currentCheckpoint].gameObject.transform.position.x;
        glitch.Reset(spawnPoint);
        return spawnPoint;


       //}
       // else Application.LoadLevel(Application.loadedLevel);
       // return 0;
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
