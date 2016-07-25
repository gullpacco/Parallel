using UnityEngine;
using System.Collections;

public class PillarElastic : Pillar
{

    bool isFree;
    bool isGoingBack;
    public float resettingSpeed;
    float startTime;
    float journeyLength;
    Vector3 startPosition, endPosition;

  

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
       

       StartCoroutine( CheckCollision());

        if (pushedByPlayer||pushedByPillar)
        {
            isGoingBack = false;
        }

        //lerp
        if (isGoingBack)
        {
            {
                
                float distCovered = (Time.time - startTime) * resettingSpeed;
                float fracJourney = Mathf.Abs(distCovered / journeyLength);
                transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
                if (transform.position.y == baseY)
                isGoingBack = false;
            }

        }
    
    }

  


    public override void ResetPillar()
    {
        base.ResetPillar();
        if (!locked)
        {
            pushedByPlayer = false;
            pushedByPillar = false;
            isGoingBack = false;
        }

    }



    IEnumerator CheckCollision()
    {
        yield return new WaitForFixedUpdate();
        if (!pushedByPillar && !pushedByPlayer)
        {
            if (transform.position.y != baseY)
            {
                StartLerping();
            }
            else isGoingBack = false;


        }
        StopAllCoroutines();
    }

 

    void OnTriggerEnter2D(Collider2D coll)
    {
       
            if (coll.tag == "PlayerGround")
            {
                isGoingBack = false;
            pushedByPlayer = true;
            pushedByPillar = false;
            pillarPushing = null;
            }


        if (coll.tag == "PillarElastic")
        {
            Pillar pillar = coll.GetComponent<Pillar>();
            Debug.Log(pillar);
            if ((pillar.pushedByPillar || pillar.pushedByPlayer) && !pushedByPlayer)
            {
                if (pillar.pillarPushing != this)
                {
                    pushedByPillar = true;
                    pillarPushing = pillar;
                }


            }

        }
   
    }

    void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.tag == "PlayerGround")
        {
            //isFree = false;
            isGoingBack = false;
            //isPushed = true;
            pushedByPlayer = true;
            pushedByPillar = false;
            pillarPushing = null;
        }


        if (coll.tag == "PillarElastic")
        {
            Pillar pillar = coll.GetComponent<Pillar>();
            if ((pillar.pushedByPillar || pillar.pushedByPlayer) && !pushedByPlayer)
            {
                if (pillar.pillarPushing != this)
                {
                    pushedByPillar = true;
                    
                    pillarPushing = pillar;
                }



            }


        }
    }

    




    void OnTriggerExit2D(Collider2D coll)
    {


        // if (coll.transform.tag == "Player")
        if (coll.tag == "PlayerGround")
            pushedByPlayer = false;
        if (coll.tag == "PillarElastic")
        {
            pushedByPillar = false;

            pillarPushing = null;
        }
      

    }

  

        void StartLerping()
    {
        if (!pushedByPillar && !pushedByPlayer && !isGoingBack)
        {
            Debug.Log("StartLerping");
            isGoingBack = true;
            body.velocity = new Vector2(0, 0);
            startTime = Time.time;
            journeyLength = transform.position.y - baseY;
            startPosition = transform.position;
        }
    }

}
