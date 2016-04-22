using UnityEngine;
using System.Collections;

public class PillarDown : Pillar
{

     string [] playerCollisions = new string [2];
    bool canMove = true;

    protected override void Awake()
    {
        base.Awake();

    }

    // Update is called once per frame
    void Update()
    {
        // if (isGrounded && !playerContact[0] && !playerContact[1])
        // {
        //     body.isKinematic = true;
        // }
        //else if (playerContact[0] || playerContact[1] && !finalPosReached)
        //   body.isKinematic = false;

        //if (!finalPosReached)
        //{
        //    if (transform.position.y > baseY && isGrounded && !canMove)
        //        body.isKinematic = true;
        //    if (canMove)
        //    {
        //        body.isKinematic = false;
        //    }
        //}
    }

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        //if (coll.transform.tag == "Player")
        //{
        //    if (coll.transform.position.y > transform.position.y)
        //        canMove = true;
        //}

        //base.OnCollisionEnter2D(coll);

        //bool contained=false;
        //if (coll.transform.tag == "Player")
        //{
        //    for(int i=0; i < 2; i++)
        //    {
        //        if (playerCollisions[i] == coll.transform.name)
        //        { contained = true;
        //            Debug.Log(coll.transform.name);
        //        }
        //    }

        //    if (!contained)
        //    {
        //        for (int i = 0; i < 2; i++)
        //        {
        //            if (playerCollisions[i] == null)
        //            {
        //                playerCollisions[i] = coll.transform.name;
        //                playerContact[i] = true;
        //                break;
        //            }
        //        }
        //    }
        //}
        Debug.Log(coll.transform.tag);

        if (coll.transform.tag == "Ground")
        {
            //isGrounded = true;
            //body.isKinematic = true;

            if (transform.position.y < baseY)
            {
                body.isKinematic = true;
                finalPosReached = true;
                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            }
            //else canMove = false;

            //else Invoke("UnKinematic", 0.1f);
        }
        //if (coll.transform.tag == "Player")
        //{
        //    if (playerContact[0])
        //        playerContact[1] = true;
        //    else
        //        playerContact[0] = true;
        //            }

        //if(isGrounded && !playerContact[0] && !playerContact[1])
        //{
        //    body.isKinematic = true;
        //}
        //if (playerContact[0] || playerContact[1] && !finalPosReached)
        //    body.isKinematic = false;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.tag);
        if (coll.tag == "Ground")
        {

            if (transform.position.y < baseY)
            {
                body.isKinematic = true;
                finalPosReached = true;
                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            }
        }
    }

    protected override void OnCollisionStay2D(Collision2D coll)
    {
        //base.OnCollisionStay2D(coll);
        //if(coll.transform.tag=="Ground")
        //{ isGrounded = true; }

        //if (isGrounded && !finalPosReached)
        //{
        //    if (playerContact[0] && playerContact[1])
        //        body.isKinematic = false;
        //    else if(playerContact[0] | playerContact[1])
        //    {
        //        body.isKinematic = true;
        //    }
        //}
    }

    protected override void OnCollisionExit2D(Collision2D coll)
    {
        //if (coll.transform.tag == "Player")
        //{
        //    if (playerContact[1])
        //        playerContact[1] = false;
        //    else if (playerContact[0])
        //        playerContact[0] = false;

        //}

        //if (coll.transform.tag == "Player")
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        if (playerCollisions[i] == coll.transform.name)
        //        {
        //            playerCollisions[i] = null;
        //            playerContact[i] = false;
        //            Debug.Log(i);
        //            break;
        //        }
        //    }
        //}


        //if (coll.transform.tag == "Ground")
        //{
        //    isGrounded = false;

        //}
    }

    //void UnGround()
    //{
    //    if(!playerContact[0] || !playerContact[1])
    //    isGrounded = false;
    //}
  

    protected override void UnKinematic()
    {
      
            body.isKinematic = false;

    }

}
