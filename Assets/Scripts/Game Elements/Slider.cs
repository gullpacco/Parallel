using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "PlayerGround")
        {
            coll.gameObject.GetComponent<PlayerGround>().SetSliderSpeed(speed);
        }
    }
}
