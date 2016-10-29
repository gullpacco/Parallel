using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    int triggeredPlayers = 0;
    bool canTrigger = true;
    CheckPointManager cpm;
    PlatformCheck platformCheck;
    GameObject child;
    ParticleSystem rotatingParticles;
    bool first;


    public bool First
    {
        get
        {
            return first;
        }

        set { first = value; }
    }

    public int TriggeredPlayers
    {
        set { triggeredPlayers = value; }

    }

    public bool CanTrigger
    {
        get
        {
            return canTrigger;
        }

    }

    void Awake()
    {
        cpm = GameObject.FindObjectOfType<CheckPointManager>();
        platformCheck = GameObject.FindObjectOfType<PlatformCheck>();
        child = transform.GetChild(0).gameObject;
        rotatingParticles = GetComponentInChildren<ParticleSystem>();

    }

    // Use this for initialization
    void Start () {
        if (first)
            child.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
       if(!first)
            child.transform.Rotate(0, 0, 10 * Time.deltaTime);
        if (triggeredPlayers >= 2 )
        {
            if (canTrigger)
            {
                if (!first)
                {
                    AudioManager.instance.PlaySound("S_Checkpoint_Reached");
                    if (rotatingParticles.startLifetime > 1)
                    {
                        rotatingParticles.startLifetime = 1;
                        rotatingParticles.startSpeed = 3;
                    }
                }
                
                cpm.ActivateCheckpoint(this);
               // triggeredPlayers = 0;
                canTrigger = false;
                platformCheck.CheckpointReached();
            }
            if (!first)
            {
                if (rotatingParticles.startLifetime > 0.55f)
                    rotatingParticles.startLifetime -= 0.005f;
                else
                    Invoke("StopParticles", .8f);
            }
        }

    }

    void StopParticles()
    {
        rotatingParticles.emissionRate=0;
        rotatingParticles.Stop();
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
