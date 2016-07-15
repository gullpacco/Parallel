using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

    public float Speed_X, Speed_Y;

    protected Rigidbody2D body;
    public bool moving =false;
    public float minX, maxX, minY, maxY;

    // Use this for initialization
    void Start () {
        minX = transform.position.x - minX;
        maxX += transform.position.x;
        minY = transform.position.y - minY;
        maxY += transform.position.y;

        if (moving)
        {
            Move();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}


    void Move()
    {
        if (transform.position.y <= minY)
        {

            Speed_Y = -Speed_Y;
            //body.velocity = new Vector2(body.velocity.x, laserSpeedY);
        }
        else if (transform.position.y >= maxY)
        {
            Speed_Y = -Speed_Y;

            //s            body.velocity = new Vector2(body.velocity.x, -laserSpeedY);
        }

        if (transform.position.x <= minX)
        {

            // body.velocity = new Vector2(laserSpeedX, body.velocity.y);
            Speed_X = -Speed_X;
        }
        else if (transform.position.x >= maxX)
        {
            // body.velocity = new Vector2(-laserSpeedX, body.velocity.y);
            Speed_X = -Speed_X;
        }

        transform.position = new Vector2(transform.position.x + Speed_X * Time.deltaTime, transform.position.y + Speed_Y * Time.deltaTime);
    }
}
