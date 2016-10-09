using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour
{


    protected float baseY;
    protected bool changingColour = false;
    public bool toDebug;
    protected int facingUp;

    [HideInInspector]
    public bool locked;
   
    public bool isPushed;

    protected bool [] playerContact = new bool [2];
    protected bool isGrounded;
    protected bool finalPosReached;
    protected Color baseColor;
    protected SpriteRenderer sr;

    protected GameObject []arrowArray; 
    protected Rigidbody2D body;

    public bool pushedByPlayer;
    public bool pushedByPillar;
    public Pillar pillarPushing;


    public Sprite square, arrow;

    protected virtual void Awake()
    {
        baseY = transform.position.y;
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
        body = GetComponent<Rigidbody2D>();
        int arrowNumber=0;
        if (body.mass < 1)
        {
            arrowNumber = 3;
        } 
        else if (body.mass < 6)
        {
            arrowNumber = 2;
        }
        else
        {
            arrowNumber = 1;
        }
        arrowArray = new GameObject[arrowNumber];
        for(int c=0; c < arrowNumber; c++)
        {
            GameObject go = new GameObject();
            go.name = "arrowSprite";
            go.transform.position = transform.position;
            SpriteRenderer sr1 = go.AddComponent<SpriteRenderer>();
            sr1.sprite = square;
            sr1.color = new Color(0.1f, 0.6f, 0.1f);
            sr1.sortingLayerName = "Main";
            sr1.sortingOrder = 6;
            go.transform.parent = this.transform;
            go.transform.localScale = new Vector3(1/transform.lossyScale.x, 1 / transform.lossyScale.y, 1);
            if( c == 1)
                {
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + transform.localScale.y / 2, transform.position.z);
                }
            else if (c == 2)
            {
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - transform.localScale.y / 2, transform.position.z);

            }
            arrowArray[c] = go;
        }

    }


    // Use this for initialization
    protected virtual void Start()
    {
        
    }



    protected virtual void Update()
    {


        if (transform.position.y < baseY - 0.01f)
        {
            if (facingUp>0)
            {
                for (int c = 0; c < arrowArray.Length; c++)
                {
                    arrowArray[c].GetComponent<SpriteRenderer>().sprite = arrow;
                    {

                        if(arrowArray[c].transform.localScale.y>0)
                        arrowArray[c].transform.localScale = new Vector3(arrowArray[c].transform.localScale.x, -arrowArray[c].transform.localScale.y, arrowArray[c].transform.localScale.z);


                    }
                }
            } 

            facingUp = 0;

        }

        else if (transform.position.y > baseY + 0.01f)
        {
            
            if (facingUp <2)
            {
                for (int c = 0; c < arrowArray.Length; c++)
                {
                    arrowArray[c].GetComponent<SpriteRenderer>().sprite = arrow;
                    if (arrowArray[c].transform.localScale.y < 0)

                        arrowArray[c].transform.localScale = new Vector3(arrowArray[c].transform.localScale.x, -arrowArray[c].transform.localScale.y, arrowArray[c].transform.localScale.z);

                    
                }
            }
            facingUp = 2;

        }
        else
        {
            for (int c = 0; c < arrowArray.Length; c++)
            {
                arrowArray[c].GetComponent<SpriteRenderer>().sprite = square;
            }
            facingUp = 1;
        }
        

    }   

    public virtual void ResetPillar()
    {
        if (!locked)
        {
            transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
            //isFree = false;
            //isGoingBack = false;
            body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Invoke("Free", 0.2f);
            //iskin?
            body.isKinematic = false;
            sr.color = baseColor;
            changingColour = false;
        }

    }

    void Free()
    {
        body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }


    //protected virtual void OnCollisionEnter2D(Collision2D coll)
    //{


    //    //if (coll.gameObject.tag == "Ground")
    //    //{
    //    //    isGrounded = true;
    //    //}

    //}

    //protected virtual void OnCollisionExit2D(Collision2D coll)
    //{




    //}

    //protected virtual void OnCollisionStay2D(Collision2D coll)
    //{



    //}

}