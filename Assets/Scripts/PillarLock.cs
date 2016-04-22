using UnityEngine;
using System.Collections;

public class PillarLock : Pillar
{

    bool canMove = true;

    protected override void Awake()
    {
        base.Awake();

    }
   

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Ground")
        {


            {
                body.isKinematic = true;
                finalPosReached = true;
                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            }
        }
    }

   
  

    //protected override void UnKinematic()
    //{
      
    //        body.isKinematic = false;

    //}

}
