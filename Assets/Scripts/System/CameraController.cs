using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform [] playerToFollow;
    private int cursor = 0;
    public float offset, limit, increment;


	// Use this for initialization
	void Start () {
        playerToFollow = new Transform[2];

        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        for (int i =0; i<players.Length; i++)
        {
            playerToFollow[i] = players[i].gameObject.transform;
        }


	}
	
	// Update is called once per frame
	void Update () {
        //CameraCheck();
        transform.position = new Vector3((playerToFollow[0].position.x + playerToFollow[1].position.x)/2 -offset, transform.position.y, transform.position.z);
        if(offset>limit)
        offset += increment;
	}



    //void CameraCheck()
    //{
    //    float max = playerToFollow[cursor].position.x;
    //    for (int i=0; i < playerToFollow.Length; i++)
    //    {
    //        if (playerToFollow[i].position.x > playerToFollow[cursor].position.x)
    //            cursor = i;
    //    }
    //}
}
