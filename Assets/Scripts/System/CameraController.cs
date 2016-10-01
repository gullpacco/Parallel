using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Transform [] playerToFollow;
    private int cursor = 0;
    public float offset, limit, increment;
    float playersDistance, lastPlayerDistance;
    public Parallax[] parallaxElements;

    [System.Serializable]
    public struct Parallax
    {
        public float parallaxSpeed;
        public Transform parallaxElement;
    }

    // Use this for initialization
    void Start () {
        playerToFollow = new Transform[2];

        PlayerController[] players = GameObject.FindObjectsOfType<PlayerController>();
        for (int i =0; i<players.Length; i++)
        {
            playerToFollow[i] = players[i].gameObject.transform;
        }
        playersDistance = (playerToFollow[0].position.x + playerToFollow[1].position.x)/2;
        lastPlayerDistance = playersDistance;

    }
	
	// Update is called once per frame
	void Update () {
        //CameraCheck();
        playersDistance = (playerToFollow[0].position.x + playerToFollow[1].position.x)/2;
        if (playersDistance != lastPlayerDistance)
        {
            CalculateParallax(playersDistance - lastPlayerDistance);
        }
        lastPlayerDistance = playersDistance;

        transform.position = new Vector3(playersDistance -offset, transform.position.y, transform.position.z);
        if(offset>limit)
        offset += increment;
	}


    void CalculateParallax(float difference)
    {
        for (int k=0; k<parallaxElements.Length; k++)
        {
            Transform par = parallaxElements[k].parallaxElement;
            float speed = parallaxElements[k].parallaxSpeed;
            par.position = new Vector3(par.position.x - difference * speed, par.position.y, par.position.z);
        }
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
