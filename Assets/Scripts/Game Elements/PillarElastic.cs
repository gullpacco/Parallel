using UnityEngine;
using System.Collections;

public class PillarElastic : Pillar
{

    bool isFree;
    bool isGoingBack;
    bool isPushed;
    public float resettingSpeed;
    float startTime;
    float journeyLength;
    Vector3 startPosition, endPosition;
    bool[] pillarsInContact = new bool[2];

    protected override void Awake()
    {
        base.Awake();
    }


    //protected override void Start () {

    //}

        protected override void Start()
    {
        endPosition = new Vector3(transform.position.x, baseY, transform.position.z);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (pillarsInContact[0] | pillarsInContact[1] | playerContact[0])
        //    isFree = false;
        //else isFree = true;

        StartCoroutine(CheckCollision());

        if (!isFree)
        {
            isGoingBack = false;
        }

        //lerp
        if (isGoingBack)
        {
           // if (transform.position.y > baseY)
            {
                //transform.Translate(0, -resettingSpeed * Time.deltaTime, 0);

                //if (transform.position.y < baseY + 0.01f)
                //{
                //    transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
                //    isGoingBack = false;
                //}

                float distCovered = (Time.time - startTime) * resettingSpeed;
                float fracJourney = Mathf.Abs(distCovered / journeyLength);
                transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
                //Debug.Log(distCovered);
                
            }

        }
        //if (transform.position.y <= baseY - 0.01f)
        //{
        //    transform.Translate(0, resettingSpeed * Time.deltaTime, 0);
        //    if (transform.position.y > baseY - 0.01f)
        //    {
        //        transform.position = new Vector3(transform.position.x, baseY, transform.position.z);

        //        isGoingBack = false;
        //    }
        //}
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
            if ( transform.position.y != baseY) {
                StartLerping();
                isPushed = false; }
            else isGoingBack = false;

        }
        StopAllCoroutines();
    }

   void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag != "Enemy" && coll.tag != "Triggers")
        {
            if (coll.tag == "PlayerGround")
            {
                isFree = false;
                isGoingBack = false;
                isPushed = true;
            }
            if (!isPushed)
            {
                isFree = false;
                isGoingBack = false;
            }
        }
    }

    void OnTriggernStay2D(Collider2D coll)
    {
        if (coll.tag != "Enemy" && coll.tag!= "Triggers")
        {

            if (coll.tag == "PlayerGround")
            {
                isFree = false;
                isGoingBack = false;
                isPushed = true;
            }
            if (!isPushed)
            {
                isFree = false;
                isGoingBack = false;
            }
        }
    }


    void OnTriggerExit2D(Collider2D coll)
    {



        // if (coll.transform.tag == "Player")
        if (coll.tag != "Enemy" && coll.tag != "Triggers")
        {
            //playerContact[0] = false;
            //Invoke("StartLerping", 0.5f);
            isFree = true;
            }

            
            


        //if (coll.transform.tag == "Ground")
        //    isGrounded = false;

        //if (coll.transform.tag == "Pillar")
        //{
        //    if (pillarsInContact[1])
        //        pillarsInContact[1] = false;
        //    else if (pillarsInContact[0])
        //        pillarsInContact[0] = false;
        //}

    }

    //void OnCollisionExit2D(Collision2D coll)
    //{
    //    {
           
    //        isFree = true;
    //    }
    //}

        void StartLerping()
    {
        if (isFree)
        {
            isGoingBack = true;
            body.velocity = new Vector2(0, 0);
            startTime = Time.time;
            journeyLength = transform.position.y - baseY;
            startPosition = transform.position;
        }
    }

    //protected  override void UnKinematic()
    //{
    //    //if (!playerContact[0])
    //     //   body.isKinematic = false;

    //}
}
