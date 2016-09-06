using UnityEngine;
using System.Collections;
using System;

public class LaserLeft : Laser {


        protected override void Awake()
    {
        base.Awake();
        las.SetPosition(0, transform.position);

    }

	protected override void FixedUpdate () {
        base.FixedUpdate();

    }

    protected override void LaserLength()
    {

        hit = Physics2D.Raycast(transform.position, Vector2.left, 1000);

        if (hit.collider != null)
        {

            if (hit.collider.tag == "Player" )
            {

                if( hit.distance >= minDistance)

                   
                {
                    hit.transform.gameObject.GetComponent<PlayerController>().SlowMo();
                    distanceToReach = hit.point.x;

                }

            }

            else distanceToReach = hit.point.x;




        }
        else distanceToReach = -1000;
        if (distanceToReach != currentEnd)
            distChanged = true;


    }

    protected override void ExtendBeam()
    {
        //currentEnd -= 0.5f;
        //if (currentEnd > distanceToReach)
        //{
        //    distance = new Vector3(currentEnd, transform.position.y, transform.position.z);
        //}
       // else
        {
            distance = new Vector3(distanceToReach, transform.position.y, transform.position.z);
            distChanged = false;
            currentEnd = distanceToReach;

        }

    }

    protected override void addColliderToLine()
    {
        base.addColliderToLine();
        midPoint.x = midPoint.x - colliderOffset / 2;
        col.transform.position = midPoint;

    }

    protected override void FinalDist()
    {
        distance = new Vector3(distanceToReach, transform.position.y, transform.position.z);
    }
}
