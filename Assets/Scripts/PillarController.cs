using UnityEngine;
using System.Collections;

public class PillarController : MonoBehaviour
{
    Rigidbody2D body;
    public bool goesUp;
    public bool goesDown;
    private float baseY;
    public float resettingSpeed;
    bool isFree;
    public bool goesBack;
    bool isGoingBack;
    bool playerContact = false;

    [HideInInspector]
    public bool locked;
    bool isGrounded;

    public Sprite[] sprites;
   // private static Sprite currentSprite;
    

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //currentSprite = GetComponent<SpriteRenderer>().sprite;
        if (goesBack)
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        else if (goesUp)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];

        }
        else if (goesDown)
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        else GetComponent<SpriteRenderer>().sprite = sprites[3];



    }

    // Use this for initialization
    void Start()
    {
        baseY = transform.position.y;
    
    }

    



    // Update is called once per frame
    void Update()
    {
        if(goesBack)
        StartCoroutine(CheckCollision());
        if (isGoingBack)
        {
            if (transform.position.y >= baseY + 0.01f)
            { transform.Translate(0, -resettingSpeed * Time.deltaTime, 0);

                if (transform.position.y < baseY + 0.01f)
                {
                    transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
                    isGoingBack = false;
                }

            }
            if (transform.position.y <= baseY -0.01f)
            {
                transform.Translate(0, resettingSpeed * Time.deltaTime, 0);
                if (transform.position.y > baseY - 0.01f)
                {
                    transform.position = new Vector3(transform.position.x, baseY, transform.position.z);

                    isGoingBack = false;
                }
            }
        }


    
    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        if (goesBack)
        {
            if (isGrounded)
            {
                if (coll.transform.tag == "Player")
                {
                    playerContact = true;

                    body.isKinematic = true;
                }
            }
        }

        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = true;

            if (goesUp && transform.position.y > baseY)
            {
                body.isKinematic = true;
                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

           else if (goesDown && transform.position.y < baseY)
            {
                body.isKinematic = true;

                body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            }
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {


       


        if (goesBack) {
            if (isGrounded)
            {
                if (coll.transform.tag == "Player")
                {
                    playerContact = true;
                    body.isKinematic = true;
                }
            }
            if (coll.gameObject.tag == "Player")
            {
                isFree = false;
                isGoingBack = false;
            }
            //else 

            ////{
            //    //Debug.Log("free");
            //    //isFree = true;
            //    StartCoroutine(CheckCollision()); 
            //        }
                }
    }

    void OnCollisionExit2D(Collision2D coll)
    {

        if (goesBack)
        {
            if (coll.transform.tag == "Player")
            {
                playerContact = false;
                Invoke("UnKinematic", 0.5f);
            }
        }
        

        if (coll.transform.tag=="Ground")
        isGrounded = false;

        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Pillar")
        {
            isFree = true;
        }

    }

    void UnKinematic()
    {
        if(!playerContact)
        body.isKinematic = false;

    }

    IEnumerator CheckCollision()
    {
        yield return new WaitForSeconds(0.2f);
        if (isFree)
        {
            isGoingBack = true;
        }
        StopAllCoroutines();
    }

    public void ResetPillar()
    {
        if (!locked)
        {
            transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
            isFree = false;
            isGoingBack = false;
            body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Invoke("Free", 0.2f);
            body.isKinematic = false;
        }

    }

    void Free()
    {
        body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    public void ResetAnyPillar()
    {

    }
}
