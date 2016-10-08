using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{

    public float Speed_X, Speed_Y;
    float currentSpeed_X, currentSpeed_Y;
    float startX, startY;

    //protected Rigidbody2D body;
    float previousTime;
    public bool moving = false;
    public float minX, maxX, minY, maxY;
    bool goingUp;

    bool goingRight;
    public bool toDebug;
    
    void Awake()
    {
        minX = transform.position.x - minX;
        maxX += transform.position.x;
        minY = transform.position.y - minY;
        maxY += transform.position.y;
        startY = transform.position.y;
        startX = transform.position.x;
        SetValues();
        
    }

    // Use this for initialization
    void Start()
    {


    }

    public void SetValues()
    {
        currentSpeed_X = Speed_X;
        currentSpeed_Y = Speed_Y;
       
        if (Speed_Y > 0) goingUp = true;
        if (Speed_X > 0) goingRight = true;

        transform.position = new Vector3(startX, startY, transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            Move();
        }
    }


    void Move()
    {
        if (transform.position.y <= minY && !goingUp)
        {
            currentSpeed_Y = -currentSpeed_Y;
            goingUp = true;
            //body.velocity = new Vector2(body.velocity.x, laserSpeedY);
        }
        else if (transform.position.y >= maxY && goingUp)
        {
            currentSpeed_Y = -currentSpeed_Y;
            goingUp = false;

            //s            body.velocity = new Vector2(body.velocity.x, -laserSpeedY);
        }

        if (transform.position.x <= minX && !goingRight)
        {

            // body.velocity = new Vector2(laserSpeedX, body.velocity.y);
            currentSpeed_X = -currentSpeed_X;
            goingRight = true;
            if (toDebug)
            {
                Debug.Log(this.name + " at " + (previousTime - Time.time) + " " + (maxX-minX)/ currentSpeed_X);
                previousTime = Time.time;
               
            }


        }
        else if (transform.position.x >= maxX && goingRight)
        {
            // body.velocity = new Vector2(-laserSpeedX, body.velocity.y);
            currentSpeed_X = -currentSpeed_X;
            goingRight = false;
            if (toDebug)
            {
                Debug.Log(this.name + " at " + (previousTime - Time.time) + " " + (maxX - minX) / currentSpeed_X);
                previousTime = Time.time;
            }
        }

        transform.position = new Vector2(transform.position.x + currentSpeed_X * Time.deltaTime, transform.position.y + currentSpeed_Y * Time.deltaTime);
    }
}
