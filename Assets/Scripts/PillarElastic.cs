using UnityEngine;
using System.Collections;

public class PillarElastic : Pillar
{

    bool isFree;
    bool isGoingBack;
    public float resettingSpeed;
    bool[] pillarsInContact = new bool[2];

    protected override void Awake()
    {
        base.Awake();

    }


    //protected override void Start () {

    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pillarsInContact[0] | pillarsInContact[1] | playerContact[0])
            isFree = false;
        else isFree = true;

        StartCoroutine(CheckCollision());

        //lerp
        if (isGoingBack)
        {
            if (transform.position.y >= baseY + 0.01f)
            {
                transform.Translate(0, -resettingSpeed * Time.deltaTime, 0);

                if (transform.position.y < baseY + 0.01f)
                {
                    transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
                    isGoingBack = false;
                }

            }
            if (transform.position.y <= baseY - 0.01f)
            {
                transform.Translate(0, resettingSpeed * Time.deltaTime, 0);
                if (transform.position.y > baseY - 0.01f)
                {
                    transform.position = new Vector3(transform.position.x, baseY, transform.position.z);

                    isGoingBack = false;
                }
            }
        }
    }

    public override void ResetPillar()
    {
        base.ResetPillar();
        if (!locked)
        {
            isFree = false;
            isGoingBack = false;
        }

    }



    IEnumerator CheckCollision()
    {
        yield return new WaitForSeconds(0.2f);
        if (isFree)
        {
            isGoingBack = true;
        }
        StopAllCoroutines();
    }

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collider = coll.gameObject;

        if (isGrounded)
        {
            if (collider.tag == "Player")
            {
                playerContact[0] = true;

                body.isKinematic = true;
            }

        }

        if (collider.tag == "Pillar")
        {
            if (pillarsInContact[0])
                pillarsInContact[1] = true;
            else
                pillarsInContact[0] = true;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (isGrounded)
        {
            if (coll.transform.tag == "Player")
            {
                playerContact[0] = true;
                body.isKinematic = true;
            }
        }
        if (coll.gameObject.tag == "Player")
        {
            isFree = false;
            isGoingBack = false;
        }
    }


    void OnCollisionExit2D(Collision2D coll)
    {

            if (coll.transform.tag == "Player")
            {
                playerContact[0] = false;
                Invoke("UnKinematic", 0.5f);
            }
        


        if (coll.transform.tag == "Ground")
            isGrounded = false;

        if (coll.transform.tag == "Pillar")
        {
            if (pillarsInContact[1])
                pillarsInContact[1] = false;
            else if (pillarsInContact[0])
                pillarsInContact[0] = false;
        }

    }

    protected  override void UnKinematic()
    {
        if (!playerContact[0])
            body.isKinematic = false;

    }
}
