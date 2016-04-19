using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour {

    public Transform [] spawnPoints;
    public bool[] shootingPoints;
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate=0.3f;
    public float bulletLifeTime = 1.5f;

    GameObject[] poolBullets;
    int currentBullet = 0;

    void Awake()
    {
        poolBullets  = new GameObject[transform.childCount - 4];
        for (int j=4; j<transform.childCount; j++)
        {
            poolBullets[j - 4] = transform.GetChild(j).gameObject;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Shoot());
	}

    public void ResetShooter()
    {
        for (int i=0; i<poolBullets.Length; i++)
        {
            if(poolBullets[i].activeSelf)
            poolBullets[i].GetComponent<BulletController>().Countdown(0);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(fireRate);

        for (int i = 0; i < shootingPoints.Length; i++)
        {
            if (shootingPoints[i])
            {
                //GameObject newBullet = Instantiate(bullet, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject;
                //if (i == 0)
                //newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.forward*bulletSpeed);
                poolBullets[currentBullet].SetActive(true);
                poolBullets[currentBullet].transform.position = spawnPoints[i].position;
                poolBullets[currentBullet].transform.rotation = spawnPoints[i].rotation;

                switch (i)
                {
                    case 0:
                        poolBullets[currentBullet].GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
                        break;
                    case 1:
                        poolBullets[currentBullet].GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                        break;
                    case 2:
                        poolBullets[currentBullet].GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                        break;
                    case 3:
                        poolBullets[currentBullet].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                        break;

                }
                //Destroy(newBullet, bulletLifeTime);
                poolBullets[currentBullet].GetComponent<BulletController>().Countdown(bulletLifeTime);
                if (currentBullet < poolBullets.Length-1)
                {
                    currentBullet++;
                }
                else currentBullet = 0;
            }
            

        }
        StopAllCoroutines();
    }

  
}
