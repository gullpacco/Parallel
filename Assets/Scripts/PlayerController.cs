using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool isOne;
    private float baseSpeed;
    public float speed;
    public float jumpForce;
    public bool canDie = true;
     bool isGrounded=true;
    bool isFighting;
    int deaths;
    Rigidbody2D body;
     Text deathText;
    public float fightTime = 1;
    public PlayerController other;
    public GameObject currentEnemy;
    bool canGoForward=true;
    bool canGoBack = true;

    bool checkPointReached;
    public float screenSize = 34f;
    public float screenHeight = 10f;
    public float groundRadius;
    CheckPointManager cpm;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    bool isJumping=false;
    bool locked = false;

    float regTime;
    float lastY;

	public AudioClip jumpSample; 
	public AudioClip landSample; 
	private AudioSource jumpAudioSource;
   public  AudioClip shot;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        baseSpeed = speed;
        cpm = GameObject.FindObjectOfType<CheckPointManager>();

		jumpAudioSource = GetComponent<AudioSource>();
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
        
       if(canDie) {
            //if (!locked)
            //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


                //RaycastHit2D hit= Physics2D.Raycast(transform.position, Vector2.left);
                //{
                //    if (hit)
                //    {
                //        Debug.Log(hit.transform.tag);
                //        if (hit.transform.CompareTag("Ground"))
                //        {
                //            isGrounded = true;
                //        }
                //        else isGrounded = false;
                //    }
                //    else isGrounded = false;
                //}

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

                if (Input.GetKey(KeyCode.W) && !isJumping)
                {
                    if (isGrounded && !isJumping)
                    {
                        Jump();
                        jumpAudioSource.PlayOneShot(jumpSample);
                    }
                }

                //if (Input.GetKeyDown(KeyCode.A))
                //{
                //    Fight();
                //}

                if (Input.GetKey(KeyCode.D) && canGoForward)
                {
                    //transform.Translate(speed * Time.deltaTime, 0, 0);
                    //   transform.localPosition += transform.forward * Time.deltaTime * 6f;
                    body.velocity = new Vector2(speed, body.velocity.y);

                }


                else if (Input.GetKey(KeyCode.A) && canGoBack)
                {
                    // transform.Translate(-speed * Time.deltaTime, 0, 0);
                    body.velocity = new Vector2(-speed, body.velocity.y);

                }

                else
                {
                    body.velocity = new Vector2(0, body.velocity.y);

                }


            }

            else
            {
                if (transform.position.y < -screenHeight)
                    body.velocity = new Vector2(body.velocity.y, 0);
                if (Input.GetKey(KeyCode.DownArrow) && !isJumping)
                {
                    if (isGrounded && !isJumping)
                    {
                        JumpDown();
                        jumpAudioSource.PlayOneShot(jumpSample);
                    }
                }


                if (Input.GetKey(KeyCode.RightArrow) && canGoForward)
                {
                    //transform.Translate(speed * Time.deltaTime, 0, 0);
                    body.velocity = new Vector2(speed, body.velocity.y);

                }



                else if (Input.GetKey(KeyCode.LeftArrow) && canGoBack)
                {
                    //transform.Translate(-speed * Time.deltaTime, 0, 0);
                    body.velocity = new Vector2(-speed, body.velocity.y);

                }

                else
                {
                    body.velocity = new Vector2(0, body.velocity.y);

                }


            }
        }
    }

   

    void Move()
    {
        if (transform.position.x < other.transform.position.x + 7.5)

            body.velocity = new Vector2(speed, 0);
        //transform.Translate(Vector3.forward * Time.deltaTime * 6f);
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
        //body.velocity = new Vector2(body.velocity.x, jumpForce);
        body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        isGrounded = false;
        locked = true;
        Invoke("Unlock", 0.1f);

    }

    void JumpDown()
    {
        //body.velocity = new Vector2(body.velocity.x, jumpForce);
        body.AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        isGrounded = false;
        locked = true;
        Invoke("Unlock", 0.1f);
    }

    void Unlock()
    {
        locked = false;
    }


    void Fight()
    {
        isFighting = true;
        Invoke("StopFighting", fightTime);
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
        if(isGrounded)
		jumpAudioSource.PlayOneShot(landSample);
	}
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground"|| coll.gameObject.tag == "Pillar")
        {

            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Pillar")
        {

            isJumping = true;
        }
    }


    public void SetGround(bool ground)
    {
        //if (!locked && canDie)
        //{
        //    if (isOne && transform.position.y <= lastY)
        //        isGrounded = true;
        //    else if (!isOne && transform.position.y >= lastY)
        //        isGrounded=true; }
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

    // void Throw()
    //{
    //    if (currentEnemy != null)
    //    {
    //        currentEnemy.GetComponent<EnemyController>().GetThrown();
    //        if (isOne)
    //        {
    //            currentEnemy.GetComponent<EnemyController>().isUp = true;
    //        }
    //        else currentEnemy.GetComponent<EnemyController>().isUp = false;

    //        currentEnemy = null;
    //    }


    //}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && canDie)
        {
            //Time.timeScale = 0.05f;
            //Time.fixedDeltaTime = Time.fixedDeltaTime * Time.timeScale;
            //deaths++;
            //deathText.text = "" + deaths;
            //Invoke("Die", 0.15f);
            //canDie = false;
            //other.canDie = false;
            //jumpAudioSource.PlayOneShot(shot);
            SlowMo();

        }


    }

    public void SlowMo()
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
            jumpAudioSource.PlayOneShot(shot);
        }
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

    //void EnemyFollow()
    //{
    //    currentEnemy.transform.position = new Vector3(transform.position.x - 3, transform.position.y);
    //}

    //void SlowDownHit()
    //{
    //    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
    //}
}

