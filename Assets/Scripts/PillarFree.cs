using UnityEngine;
using System.Collections;
using System;

public class PillarFree : Pillar {
    //protected override void UnKinematic()
    //{
    //    throw new NotImplementedException();
    //}

    // Use this for initialization
 //   void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}



    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Free");

        if (coll.gameObject.tag == "Pillar")
        {
            if (coll.gameObject.GetComponent<Rigidbody2D>().isKinematic)
                body.isKinematic = true;
        }
    }


}
