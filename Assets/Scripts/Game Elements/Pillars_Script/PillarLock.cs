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
      
            //for(int i=0; i<arrowArray.Length; i++)
            //{
               
            //        arrowArray[i].GetComponent<SpriteRenderer>().sprite = arrow;

            //    if (GetComponent<EdgeCollider2D>().offset.y<0)
            //    {
            //        arrowArray[i].transform.localScale= new Vector3(arrowArray[i].transform.localScale.x, -arrowArray[i].transform.localScale.y, transform.localScale.z);

            //    }

            //    }
            
        

    }
   

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Ground")
        {

            {
                StartCoroutine(Lock());
                AudioManager.instance.PlaySound("S_Lock");
            }
        }
    }

    protected  void Update()
    {
        if (changingColour)
        {
            float distCovered = (Time.time - startTime) * colourSpeed;
            float fracJourney = distCovered / journeyLength;
            currentColor = Vector3.Lerp(myColor, black, fracJourney);
            sr.color = new Color(currentColor.x, currentColor.y, currentColor.z);

        }

    }

    public override void ResetPillar()
    {
        base.ResetPillar();
        //for (int i = 0; i < arrowArray.Length; i++)
        //{

        //    //arrowArray[i].GetComponent<SpriteRenderer>().sprite = arrow;
        //    //if (GetComponent<EdgeCollider2D>().offset.y < 0)
        //    //{
        //        arrowArray[i].GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.6f, 0.1f);


        //    //  }

        //}

    }


    IEnumerator Lock()
    {
        yield return new WaitForEndOfFrame();
        body.isKinematic = true;
        finalPosReached = true;
       // body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        startTime = Time.time;
        changingColour = true;
        journeyLength = Vector3.Distance(myColor, black);

        //for (int i = 0; i < arrowArray.Length; i++)
        //{

        //    arrowArray[i].GetComponent<SpriteRenderer>().color = new Color (black.x, black.y, black.z);
           

        //}



    
}

    //protected override void UnKinematic()
    //{
      
    //        body.isKinematic = false;

    //}

}
