using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{

    public float Speed_X, Speed_Y;

    //protected Rigidbody2D body;
    float previousTime;
    public bool moving = false;
    public float minX, maxX, minY, maxY;
    bool goingUp;
    bool goingRight;
    public bool toDebug;

    // Use this for initialization
    void Start()
    {
        minX = transform.position.x - minX;
        maxX += transform.position.x;
        minY = transform.position.y - minY;
        maxY += transform.position.y;
        if (Speed_Y > 0) goingUp = true;
        if (Speed_X > 0) goingRight = true;


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
            Speed_Y = -Speed_Y;
            goingUp = true;
            //body.velocity = new Vector2(body.velocity.x, laserSpeedY);
        }
        else if (transform.position.y >= maxY && goingUp)
        {
            Speed_Y = -Speed_Y;
            goingUp = false;

            //s            body.velocity = new Vector2(body.velocity.x, -laserSpeedY);
        }

        if (transform.position.x <= minX && !goingRight)
        {

            // body.velocity = new Vector2(laserSpeedX, body.velocity.y);
            Speed_X = -Speed_X;
            goingRight = true;
            if (toDebug)
            {
                Debug.Log(this.name + " at " + (previousTime - Time.time) + " " + (maxX-minX)/Speed_X );
                previousTime = Time.time;
               
            }


        }
        else if (transform.position.x >= maxX && goingRight)
        {
            // body.velocity = new Vector2(-laserSpeedX, body.velocity.y);
            Speed_X = -Speed_X;
            goingRight = false;
            if (toDebug)
            {
                Debug.Log(this.name + " at " + (previousTime - Time.time) + " " + (maxX - minX) / Speed_X);
                previousTime = Time.time;
            }
        }

        transform.position = new Vector2(transform.position.x + Speed_X * Time.deltaTime, transform.position.y + Speed_Y * Time.deltaTime);

   
  



    }
}
