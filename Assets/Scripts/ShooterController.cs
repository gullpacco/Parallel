using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

    public Transform [] spawnPoints;
    public bool[] shootingPoints;
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate=0.3f;
    public float bulletLifeTime = 1.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Shoot());
	}

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(fireRate);

        for (int i = 0; i < shootingPoints.Length; i++)
        {
            if (shootingPoints[i])
            {
                GameObject newBullet = Instantiate(bullet, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject;
                //if (i == 0)
                //newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.forward*bulletSpeed);

                switch (i)
                {
                    case 0:
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
                        break;
                    case 1:
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                        break;
                    case 2:
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                        break;
                    case 3:
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                        break;

                }
                Destroy(newBullet, bulletLifeTime);
                StopAllCoroutines();
            }
        }
    }
}
