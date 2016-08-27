using UnityEngine;
using System.Collections;

public abstract class Laser : MonoBehaviour {

    protected RaycastHit2D hit;
    protected LineRenderer las;
    public LayerMask playerMask;
    protected Vector3 distance;
    protected GameObject particle;
   // protected ParticleSystem parSystem;
    protected float distanceToReach,
                    currentEnd;
    protected bool distChanged = true;
    public Material LasMaterial;
    bool hasStarted;

    public bool intermittent;
    public float offTime, onTime, activationOffset;
    protected bool isOn=true;
    bool offsetEnded;
    bool isinvoking;

    public bool triggerBased;
    EventTrigger trigger;
    bool skipOn;

    float previousTimeOn, previousTimeOff;
    int skip=4;


    protected virtual void Awake()
    {
         gameObject.AddComponent<LineRenderer>() ;
        las = GetComponent<LineRenderer>();
        las.material = LasMaterial;
        particle = transform.GetChild(0).gameObject;
        particle.transform.position = transform.position;
       // parSystem = particle.GetComponent<ParticleSystem>();
        las.SetPosition(0, transform.position);

        las.SetPosition(1, transform.position);
        las.SetWidth(0.2f, .2f);
        if(!triggerBased)
        GetComponent<BoxCollider2D>().enabled = false;
        //if (moving)
        //{
        //    body.velocity = new Vector2(laserSpeedX, laserSpeedY);
        //    body = GetComponent<Rigidbody2D>();
        //}

        Invoke("EndOffset", activationOffset);

    }

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (offsetEnded || triggerBased)
        {
            //if (!hasStarted)
            //{

            //    for (int i = 0; i < 20; i++)
            //    {
            //        LaserLength();

            //        if (distChanged)
            //            ExtendBeam();
            //        else
            //            FinalDist();

            //        las.SetPosition(0, transform.position);
            //        las.SetPosition(1, distance);

            //        particle.transform.position = distance;
            //    }

            //}

            //else
            // {

            if (!isinvoking &&intermittent && !triggerBased)
            {
                StartInvoking();
                isinvoking = true;
            }
                if (isOn)
                {
                    //if (intermittent)
                    //    StartCoroutine(Switch(false, onTime));

                    LaserLength();

                    if (distChanged)
                        ExtendBeam();
                    else
                        FinalDist();

                    las.SetPosition(0, transform.position);
                    las.SetPosition(1, distance);

                    particle.transform.position = distance;
                }

                else
                {
                    las.SetPosition(0, transform.position);
                    las.SetPosition(1, transform.position);
                    particle.transform.position = transform.position;

                
                }

         //   }

       }

    }

    void EndOffset()
    {
        offsetEnded = true;
        Invoke("Shoot", 0.01f);

    }

    void Shoot()
    {
        hasStarted = true;
    }

    IEnumerator Switch(bool state, float time)
    {


        yield return new WaitForSeconds(time);
        intermittent = false;

        if (isOn) { 
        Debug.Log(this.name  + "On at " + (previousTimeOn - Time.time));

        previousTimeOn = Time.time; }

        else
        {
            Debug.Log(this.name + "Off at " + (previousTimeOff - Time.time));

            previousTimeOff = Time.time;
        }
        isOn = state;
        StopAllCoroutines();
        if (!isOn)
        {
            las.SetPosition(0, transform.position);
            las.SetPosition(1, transform.position);
            particle.transform.position = transform.position;
            if (skip < 4)
            {
                StartCoroutine(Switch(true, offTime - (offTime + onTime - previousTimeOff)));
                skip++;
            }
            else
            {
                StartCoroutine(Switch(true, offTime));
                skip = 0;
            }
        }

        else
        {
            if (skip < 4)
            {
                StartCoroutine(Switch(false, onTime - (offTime + onTime - previousTimeOn)));
                skip++;
            }
            else
            {
                StartCoroutine(Switch(false, onTime));
                skip = 0;
            }
        }
    }

    void StayOn()
    {
        isOn = true;
    }


    void StayOff()
    {
        isOn = false;

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("triggered " + isOn);

        EventTrigger tmp;
        if (coll.tag == "EventTrigger" && triggerBased)
        {
            Debug.Log("event " + isOn);


            tmp = coll.GetComponent<EventTrigger>();
            //if (tmp.Skip())
            //{
            //    Debug.Log("skip " + isOn);
            if (tmp.setOn)
            {
                if (!skipOn)
                {
                    isOn = true;
                    skipOn = tmp.skip;
                }
                else
                    skipOn = false;
            }
            else
                isOn = false;

           // }
        }
    }


    void StartInvoking()
    {
        InvokeRepeating("StayOn", 0, onTime + offTime);
        InvokeRepeating("StayOff", onTime, onTime + offTime);
    }
    protected abstract void LaserLength();
    protected abstract void ExtendBeam();
    protected abstract void FinalDist();
   
}
