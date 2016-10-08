using UnityEngine;
using System.Collections;

public class Glitch : MonoBehaviour {


    public BoostPoint[] boostPoints;
    int nextBP;
    float speed;


   [System.Serializable]
    public struct BoostPoint
    {

        public float position, speed;
    }
    // Use this for initialization
    void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
        BPCheck();
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

    }

    void BPCheck()
    {
        if (transform.position.x > boostPoints[nextBP].position)
        {
            speed = boostPoints[nextBP++].speed;
        }
    }

    public void Reset(float spawnPoint)
    {
        transform.position = new Vector3(spawnPoint - 13, 0, 0);
        nextBP = 0;
    }
}
