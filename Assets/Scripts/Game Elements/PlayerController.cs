using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool isOne;
    private float sliderSpeed;
    public float speed;
    public float jumpForce;
    [HideInInspector]
    bool canDie = true;
     bool isGrounded=true;
    int deaths;
    Rigidbody2D body;
     Text deathText;
    public PlayerController other;
    bool canGoForward=true;
    bool canGoBack = true;




    bool checkPointReached;
    public float screenSize = 34f;
    public float screenHeight = 10f;
    CheckPointManager cpm;

    bool isJumping=false;
    bool locked = false;

    float regTime;
    float lastY;




    [Header("Sounds")]
    public string jumpSound;
    public string landSound, shotSound;

	public static string jumpUp="w";
	public static string moveFrontUp="d";
	public static string moveBackUp="a";
	
	public static string jumpDown="down";
	public static string moveFrontDown="right";
	public static string moveBackDown="left";

    // Use this for initialization
    void Start () {
        GameObject firstGo = GameObject.Find("Checkpoint");
        firstGo.transform.position = new Vector3(transform.position.x, transform.position.y);
        body = GetComponent<Rigidbody2D>();
        sliderSpeed = 0;
        cpm = GameObject.FindObjectOfType<CheckPointManager>();

        if (isOne)
        {
            deathText = GameObject.FindGameObjectWithTag("P1D").GetComponent<Text>();
        }
        else
        {
            deathText = GameObject.FindGameObjectWithTag("P2D").GetComponent<Text>();

        }

        regTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame



    void FixedUpdate()
    {
        StartCoroutine(SaveNewY());
        if (!isGrounded)
        {
            sliderSpeed = 0;
        }
        
       if(canDie) {
           

                if (transform.position.x - other.transform.position.x < screenSize)
            {
                canGoForward = true;
            }
            else
            {
                canGoForward = false;
            }


            if (other.transform.position.x - transform.position.x < screenSize)
            {
                canGoBack = true;
            }
            else
            {
                canGoBack = false;
            }

            if (isOne)
            {
                if (transform.position.y > screenHeight)
                    body.velocity = new Vector2(body.velocity.y, 0);

                if ((Input.GetKey(jumpUp) || Input.GetAxis("LV")<0)&& !isJumping)
                {
                    if (isGrounded && !isJumping && !locked)
                    {
                        Jump();
                        AudioManager.instance.PlaySound(jumpSound);
                    }
                }
				
				//Debug.Log("/LH "+Input.GetAxis("LH")+" /LV "+Input.GetAxis("LV")+" /RH "+Input.GetAxis("RH")+" /RV "+Input.GetAxis("RV"));
				
				if ((Input.GetKey(moveFrontUp) ||  Input.GetAxis("LH")>0) && canGoForward)
                {
                   
                    body.velocity = new Vector2(speed + sliderSpeed, body.velocity.y);

                }
				 
                else if ((Input.GetKey(moveBackUp) || Input.GetAxis("LH")<0)  && canGoBack)
                {
                    body.velocity = new Vector2(-speed + sliderSpeed, body.velocity.y);

                }

                else
                {
                    body.velocity = new Vector2(sliderSpeed, body.velocity.y);

                }


            }

            else
            {
                if (transform.position.y < -screenHeight)
                    body.velocity = new Vector2(body.velocity.y, 0);
                if ((Input.GetKey(jumpDown) || Input.GetAxis("RV")>0) && !isJumping)
                {
                    if (isGrounded && !isJumping&& !locked)
                    {
                        JumpDown();
                        AudioManager.instance.PlaySound(jumpSound);
                    }
                }


                if ((Input.GetKey(moveFrontDown) ||  Input.GetAxis("RH")>0) && canGoForward)
                {
                    body.velocity = new Vector2(speed +sliderSpeed, body.velocity.y);

                }



                else if ((Input.GetKey(moveBackDown) ||  Input.GetAxis("RH")<0) && canGoBack)
                {
                    body.velocity = new Vector2(-speed + sliderSpeed, body.velocity.y);

                }

                else
                {
                    body.velocity = new Vector2(sliderSpeed, body.velocity.y);

                }


            }
        }
    }

   

    void Move()
    {
        if (transform.position.x < other.transform.position.x + 7.5)

            body.velocity = new Vector2(speed, 0);
        else
            body.velocity = new Vector2(speed, 0);


    }

    IEnumerator SaveNewY()
    {
        yield return new WaitForEndOfFrame();
        lastY = transform.position.y;
    }

    void LeftMove()
    {
        body.velocity = new Vector2(-speed, 0);

    }

    void Stop()
    {
        body.velocity = new Vector2(0, 0);

    }


    void Jump()
    {
        body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        isGrounded = false;
        locked = true;
        Invoke("Unlock", 0.5f);

    }

    void JumpDown()
    {
        body.AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        isGrounded = false;
        locked = true;
        Invoke("Unlock", 0.5f);
    }

    void Unlock()
    {
        locked = false;
    }


   

	void OnCollisionEnter2D(Collision2D coll)
	{
        if(isGrounded)
            AudioManager.instance.PlaySound(landSound);

        if (coll.gameObject.tag == "MovingPlatform")
        {
            isJumping = false;
            transform.parent = coll.transform;
        }

    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground"|| coll.gameObject.tag.Contains("Pillar") || coll.gameObject.tag == "PillarElastic")
        {

            isJumping = false;
        }

        if (coll.gameObject.tag == "MovingPlatform")
        {
            isJumping = false;
            transform.parent = coll.transform;
        }


    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Pillar" || coll.gameObject.tag == "PillarElastic")
        {

            isJumping = true;
        }

        if (coll.gameObject.tag == "MovingPlatform")
        {

            isJumping = true;
            transform.parent = null;

        }
    }





    public void SetGround(bool ground)
    {
       
        isGrounded = ground;
    }

    public void ReachCheckpoint(bool reached)
    {
        checkPointReached = reached;
    }

    public bool getCheckpointStatus()
    {
        return checkPointReached;
    }

  

    void OnTriggerEnter2D(Collider2D coll)
    {


       if ((coll.tag == "Enemy" || coll.tag=="Lava")&& canDie)
        {
           
            SlowMo();

        }
       
    }


  

    public bool SlowMo()
    {
        if (canDie)
        {
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
            deaths++;
            deathText.text = "" + deaths;
            Invoke("Die", 0.15f);
            canDie = false;
            other.canDie = false;
            return true;
        }
        else return false;
    }

    void Die()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = regTime;

        transform.position = new Vector3(cpm.Respawn(), transform.position.y, transform.position.z);
        other.gameObject.transform.position = new Vector3(cpm.Respawn(), other.gameObject.transform.position.y, transform.position.z);
        canDie = true;
        other.canDie = true;
    }

    public void SetSliderSpeed(float sSpeed)
    {
        sliderSpeed = sSpeed;
    }

   
}

