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


    protected virtual void Awake()
    {
        las = GetComponent<LineRenderer>();
        particle = transform.GetChild(0).gameObject;
        las.SetPosition(0, transform.position);
        

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        LaserLength();

        if (distChanged)
            ExtendBeam();
        else
            FinalDist();

        las.SetPosition(0, transform.position);
        las.SetPosition(1, distance);
        particle.transform.position = distance;

    }


    protected abstract void LaserLength();
    protected abstract void ExtendBeam();
    protected abstract void FinalDist();
   
}
