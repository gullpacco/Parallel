using UnityEngine;
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


    protected virtual void Awake()
    {
         gameObject.AddComponent<LineRenderer>() ;
        las = GetComponent<LineRenderer>();
        las.material = LasMaterial;
        particle = transform.GetChild(0).gameObject;
        las.SetPosition(0, transform.position);
        Debug.Log(transform.position);
        las.SetPosition(1, transform.position);
        las.SetWidth(0.2f, .2f);

        Invoke("Uneh", 0.6f);

    }

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!hasStarted)
        {
            for (int i = 0; i < 20; i++) { 
            LaserLength();

            if (distChanged)
                ExtendBeam();
            else
                FinalDist();

            las.SetPosition(0, transform.position);
            //if(hasStarted)
            las.SetPosition(1, distance);

            particle.transform.position = distance;
        }

        }

        else { LaserLength();

            if (distChanged)
                ExtendBeam();
            else
                FinalDist();

            las.SetPosition(0, transform.position);
            //if(hasStarted)
            las.SetPosition(1, distance);

            particle.transform.position = distance;}
    }

    void Uneh()
    {
        hasStarted = true;
    }

    protected abstract void LaserLength();
    protected abstract void ExtendBeam();
    protected abstract void FinalDist();
   
}
