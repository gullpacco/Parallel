using UnityEngine;
using System.Collections;

public class PlayerGround : MonoBehaviour {
    PlayerController parentPlayer;



    void Awake()
    {
        parentPlayer=  transform.parent.GetComponent<PlayerController>();

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	 void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Ground" | coll.tag=="Pillar" | coll.tag== "PillarElastic" || coll.tag=="MovingPlatform")
        {
            parentPlayer.SetGround(true);
        }
    }
	
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Ground" | coll.tag=="Pillar" | coll.tag== "PillarElastic" || coll.tag=="MovingPlatform")
        {
            parentPlayer.SetGround(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Ground" | coll.tag == "Pillar" | coll.tag == "PillarElastic" || coll.tag == "MovingPlatform")
        {
            parentPlayer.SetGround(false);
        }
    }


    public void SetSliderSpeed(float sSpeed)
    {
        parentPlayer.SetSliderSpeed(sSpeed);
        Debug.Log("speed");

    }
}
