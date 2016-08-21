using UnityEngine;
using System.Collections;
using System;

public class LaserDown : Laser {



        protected override void Awake()
    {
        base.Awake();
        las.SetPosition(0, transform.position);


    }

    protected override void FixedUpdate() {
        base.FixedUpdate();

    }

    protected override void LaserLength()
    {

         hit = Physics2D.Raycast(transform.position, Vector2.down, 1000);

        if (hit.collider != null)
        {
            distanceToReach = hit.point.y;
            if (hit.collider.tag == "Player")
                hit.transform.gameObject.GetComponent<PlayerController>().SlowMo();

        }
        else distanceToReach = -1000;
        if (distanceToReach != currentEnd)
            distChanged = true;
        

    }

    protected override void ExtendBeam()
    {
        currentEnd -= 0.5f;
        //if (currentEnd > distanceToReach)
        //{
        //    distance = new Vector3(transform.position.x, currentEnd, transform.position.z);
        //}
        //else
        {
            distance = new Vector3(transform.position.x, distanceToReach, transform.position.z);
            distChanged = false;
            currentEnd = distanceToReach;

        }
    }

    protected override void FinalDist()
    {
        distance = new Vector3(transform.position.x, distanceToReach, transform.position.z);
    }
}
