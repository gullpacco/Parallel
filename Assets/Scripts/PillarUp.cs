using UnityEngine;
using System.Collections;

public class PillarUp : Pillar {

    protected override void Awake()
    {
        base.Awake();

    }

    // Update is called once per frame
    void Update () {
	
	}

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            if (transform.position.y > baseY)
            {
                body.isKinematic = true;
                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    protected override void UnKinematic()
    {

        body.isKinematic = false;

    }
}
