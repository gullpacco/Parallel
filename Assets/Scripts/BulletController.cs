using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    int direction;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        //transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag != "Enemy")
        //Destroy(this.gameObject);
        {
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }

    public IEnumerator killBullet(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void Countdown (float time)
    {
        StartCoroutine(killBullet(time));
    }
}
