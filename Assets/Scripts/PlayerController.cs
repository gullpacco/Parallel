﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool isOne;
    private float baseSpeed;
    public float speed;
    public float jumpForce;
    bool isGrounded=true;
    bool isFighting;
    Rigidbody2D body;
    public float fightTime = 1;
    public PlayerController other;
    public GameObject currentEnemy;
    bool canGoForward=true;
    bool canGoBack = true;

    bool checkPointReached;
    public float screenSize = 34f;
    public float screenHeight = 10f;
    CheckPointManager cpm;


    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        baseSpeed = speed;
        cpm = GameObject.FindObjectOfType<CheckPointManager>();
	}

    // Update is called once per frame
    void FixedUpdate() {



        

        }

    void Update()
    {
 

        if(transform.position.x -other.transform.position.x < screenSize)
        {
            canGoForward = true;
        }
        else
        {
            canGoForward = false;
        }


        if ( other.transform.position.x -transform.position.x < screenSize)
        {
            canGoBack = true;
        }
        else
        {
            canGoBack = false;
        }

        if (isOne)
        {
            if (transform.position.y > screenHeight)
                body.velocity = new Vector2(body.velocity.y, 0);

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isGrounded)
                    Jump();
            }

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    Fight();
            //}

            if (Input.GetKey(KeyCode.D) && canGoForward)
            {
                //transform.Translate(speed * Time.deltaTime, 0, 0);
                //   transform.localPosition += transform.forward * Time.deltaTime * 6f;
                body.velocity = new Vector2(speed, body.velocity.y);

            }


           else if (Input.GetKey(KeyCode.A)&&canGoBack)
            {
              // transform.Translate(-speed * Time.deltaTime, 0, 0);
                body.velocity = new Vector2(-speed, body.velocity.y);

            }

            else
            {
                body.velocity = new Vector2(0, body.velocity.y);

            }


        }

        else
        {
            if (transform.position.y < -screenHeight)
                body.velocity = new Vector2(body.velocity.y, 0);
            if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                if (isGrounded)
                    JumpDown();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                Fight();
            }

            if (Input.GetKey(KeyCode.RightArrow) && canGoForward)
            {
                //transform.Translate(speed * Time.deltaTime, 0, 0);
                body.velocity = new Vector2(speed, body.velocity.y);

            }



           else if (Input.GetKey(KeyCode.LeftArrow) &&canGoBack)
            {
                //transform.Translate(-speed * Time.deltaTime, 0, 0);
                body.velocity = new Vector2(-speed, body.velocity.y);

            }

            else
            {
                body.velocity = new Vector2(0, body.velocity.y);

            }


        }
    }

   

    void Move()
    {
        if (transform.position.x < other.transform.position.x + 7.5)

            body.velocity = new Vector2(speed, 0);
        //transform.Translate(Vector3.forward * Time.deltaTime * 6f);
        else
            body.velocity = new Vector2(speed, 0);


    }

    void LeftMove()
    {
        body.velocity = new Vector2(-speed, 0);

    }

    void Stop()
    {
        body.velocity = new Vector2(0, 0);

    }


    void Jump()
    {
        //body.velocity = new Vector2(body.velocity.x, jumpForce);
        body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }

    void JumpDown()
    {
        //body.velocity = new Vector2(body.velocity.x, jumpForce);
        body.AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }


    void Fight()
    {
        isFighting = true;
        Invoke("StopFighting", fightTime);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground"|| coll.gameObject.tag == "Pillar")
        {

            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Pillar")
        {

            isGrounded = false;
        }
    }


    //void StopFighting()
    //{
    //    isFighting = false;
    //}

    public void ReachCheckpoint(bool reached)
    {
        checkPointReached = reached;
    }

    public bool getCheckpointStatus()
    {
        return checkPointReached;
    }

    // void Throw()
    //{
    //    if (currentEnemy != null)
    //    {
    //        currentEnemy.GetComponent<EnemyController>().GetThrown();
    //        if (isOne)
    //        {
    //            currentEnemy.GetComponent<EnemyController>().isUp = true;
    //        }
    //        else currentEnemy.GetComponent<EnemyController>().isUp = false;

    //        currentEnemy = null;
    //    }


    //}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //Application.LoadLevel(Application.loadedLevel);
            transform.position = new Vector3(cpm.Respawn(), transform.position.y, transform.position.z);
           other.gameObject.transform.position = new Vector3(cpm.Respawn(), other.gameObject.transform.position.y, transform.position.z);

        }
    }

    //void EnemyFollow()
    //{
    //    currentEnemy.transform.position = new Vector3(transform.position.x - 3, transform.position.y);
    //}

    //void SlowDownHit()
    //{
    //    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    //}
}
