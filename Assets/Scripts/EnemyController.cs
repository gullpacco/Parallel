using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public bool isThrown;
    bool isForward;
    public bool isUp;
    public float thrownSpeed = 7;
    Rigidbody2D body;
    public float reactivationTime = 2;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if (isForward)
        {
            Roll();
        }
	}

    void Roll()
    {
        body.velocity = new Vector2(thrownSpeed, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.tag=="World" &&isThrown)
        //{
        //    Debug.Log("Collided");

        //    if (isForward)
        //    {
        //        isForward = false;
        //        if (isUp)
        //            transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        //        else transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        //        body.velocity = new Vector2(-thrownSpeed, 0);
        //    }

           
           
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "World" && isThrown)
        {
            Debug.Log("Collided");

            if (isForward)
            {
                isForward = false;
                if (isUp)
                    transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
                else transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                body.velocity = new Vector2(-thrownSpeed, 0);
            }


            //if (!isForward)
            //{
            //    isForward = true;
            //    body.velocity = new Vector2(thrownSpeed, 0);
            //}


        }

    }

    public  void GetThrown()
    {
        transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        isThrown = true;
        isForward = true;
        Invoke("ReactivateCollider", 1);
    }

    void ReactivateCollider()
    {

        GetComponent<BoxCollider2D>().enabled = true;
    }
}
