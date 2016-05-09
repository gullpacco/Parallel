﻿using UnityEngine;
using System.Collections;

public abstract class Laser : MonoBehaviour {

    protected RaycastHit2D hit;
    protected LineRenderer las;
    public LayerMask playerMask;
    protected Vector3 distance;
    protected GameObject particle;
    protected float distanceToReach,
                    currentEnd;
    protected bool distChanged = true;
    public Material LasMaterial;
    bool hasStarted;
    public float laserSpeedX, laserSpeedY;

    protected Rigidbody2D body;
    public bool moving;
    public float minX, maxX, minY, maxY;
    public bool intermittent;
    public float offTime, onTime;
    protected bool isOn=true;


    protected virtual void Awake()
    {
         gameObject.AddComponent<LineRenderer>() ;
        las = GetComponent<LineRenderer>();
        las.material = LasMaterial;
        particle = transform.GetChild(0).gameObject;
        las.SetPosition(0, transform.position);

        las.SetPosition(1, transform.position);
        las.SetWidth(0.2f, .2f);

        //if (moving)
        //{
        //    body.velocity = new Vector2(laserSpeedX, laserSpeedY);
        //    body = GetComponent<Rigidbody2D>();
        //}

            Invoke("Shoot", 0.6f);

    }

    // Use this for initialization
    void Start () {
        minX = transform.position.x-minX;
        maxX += transform.position.x;
        minY = transform.position.y-minY;
        maxY += transform.position.y;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
      
            if (!hasStarted)
            {
       
                for (int i = 0; i < 20; i++)
                {
                    LaserLength();

                    if (distChanged)
                        ExtendBeam();
                    else
                        FinalDist();

                    las.SetPosition(0, transform.position);
                    las.SetPosition(1, distance);

                    particle.transform.position = distance;
                }

            }

            else
            {
            if (isOn)
            {
                if (intermittent)
                StartCoroutine(Switch(false, onTime));
                
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

                StartCoroutine(Switch(true, offTime));
            }

        }

        if (moving)
        {
            Move();
        }

    }

    void Move()
    {
        if (transform.position.y <= minY)
        {

            laserSpeedY = -laserSpeedY;
            //body.velocity = new Vector2(body.velocity.x, laserSpeedY);
        }
        else if (transform.position.y >= maxY)
        {
            laserSpeedY = -laserSpeedY;

//s            body.velocity = new Vector2(body.velocity.x, -laserSpeedY);
        }

        if (transform.position.x <= minX)
        {

           // body.velocity = new Vector2(laserSpeedX, body.velocity.y);
            laserSpeedX = -laserSpeedX;
        }
        else if (transform.position.x >= maxX)
        {
            // body.velocity = new Vector2(-laserSpeedX, body.velocity.y);
            laserSpeedX = -laserSpeedX;
        }

        transform.position = new Vector2(transform.position.x + laserSpeedX * Time.deltaTime, transform.position.y + laserSpeedY * Time.deltaTime);
    }

    void Shoot()
    {
        hasStarted = true;
    }

    IEnumerator Switch(bool state, float time)
    {
        Debug.Log(time);

        yield return new WaitForSeconds(time);

        isOn = state;
        StopAllCoroutines();
    }

    protected abstract void LaserLength();
    protected abstract void ExtendBeam();
    protected abstract void FinalDist();
   
}
