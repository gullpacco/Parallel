﻿using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour
{


    protected float baseY;
    protected bool changingColour = false;

    [HideInInspector]
    public bool locked;
    public bool isPushed;

    protected bool [] playerContact = new bool [2];
    protected bool isGrounded;
    protected bool finalPosReached;
    protected Color baseColor;
    protected SpriteRenderer sr;

    protected Rigidbody2D body;

    public bool pushedByPlayer;
    public bool pushedByPillar;
    public Pillar pillarPushing;


    protected virtual void Awake()
    {
        baseY = transform.position.y;
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
        body = GetComponent<Rigidbody2D>();

    }


    // Use this for initialization
    protected virtual void Start()
    {

    }

    // Update is called once per frame
   

    public virtual void ResetPillar()
    {
        if (!locked)
        {
            transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
            //isFree = false;
            //isGoingBack = false;
            body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Invoke("Free", 0.2f);
            //iskin?
            body.isKinematic = false;
            sr.color = baseColor;
            changingColour = false;
        }

    }

    void Free()
    {
        body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }


    //protected virtual void OnCollisionEnter2D(Collision2D coll)
    //{


    //    //if (coll.gameObject.tag == "Ground")
    //    //{
    //    //    isGrounded = true;
    //    //}

    //}

    //protected virtual void OnCollisionExit2D(Collision2D coll)
    //{




    //}

    //protected virtual void OnCollisionStay2D(Collision2D coll)
    //{



    //}

}