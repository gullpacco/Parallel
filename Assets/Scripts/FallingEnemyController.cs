using UnityEngine;
using System.Collections;

public class FallingEnemyController : MonoBehaviour {

    public bool isSmashed;
    public Rigidbody2D body;
   public float speed;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isSmashed)
            Move();
	}

    void Move()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
    }
    

    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        if (coll.gameObject.transform.position.y<transform.position.y+0.3f)
    //        {
    //            isSmashed = true;
    //            body.gravityScale = 1;
    //        }
    //    }
    //}
}
