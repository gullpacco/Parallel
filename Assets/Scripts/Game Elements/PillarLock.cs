using UnityEngine;
using System.Collections;

public class PillarLock : Pillar
{

    bool canMove = true;
    float startTime;
    float colourSpeed = 1f;
    float r, g, b;
    float journeyLength;
    Vector3 myColor, black, currentColor;

    protected override void Awake()
    {
        base.Awake();
        myColor = new Vector3(sr.color.r, sr.color.g, sr.color.b);
        black = new Vector3(101 / 255f, 101 / 255f, 101 / 255f);
        currentColor = myColor;
    }
   

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Ground")
        {
            Debug.Log(coll.gameObject);

            {
                StartCoroutine(Lock());
            }
        }
    }

    void Update()
    {

        if (changingColour)
        {
            float distCovered = (Time.time - startTime) * colourSpeed;
            float fracJourney = distCovered / journeyLength;
            currentColor = Vector3.Lerp(myColor, black, fracJourney);
            sr.color = new Color(currentColor.x, currentColor.y, currentColor.z);

        }

    }

   
   IEnumerator Lock()
    {
        yield return new WaitForEndOfFrame();
        body.isKinematic = true;
        finalPosReached = true;
        body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        startTime = Time.time;
        changingColour = true;
        journeyLength = Vector3.Distance(myColor, black);
        
    }

    //protected override void UnKinematic()
    //{
      
    //        body.isKinematic = false;

    //}

}
