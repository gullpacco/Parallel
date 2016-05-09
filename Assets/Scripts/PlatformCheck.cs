using UnityEngine;
using System.Collections;

public class PlatformCheck : MonoBehaviour {

    // Use this for initialization
    Pillar[] selectedPillars;
    int pillarCount = 0;
    PlayerController[] players;
    int layerNumber;


    void Awake() {
        players = GameObject.FindObjectsOfType<PlayerController>();
        selectedPillars = new Pillar[GameObject.FindObjectsOfType<Pillar>().Length];
        layerNumber = GameObject.FindObjectOfType<PillarElastic>().gameObject.layer;
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

        if(players[0].transform.position.x> players[1].transform.position.x)
        {
            transform.position = new Vector2(players[1].transform.position.x, transform.position.y);
           
        }
        else
            transform.position = new Vector2(players[0].transform.position.x, transform.position.y);

    }

    void OnTriggerEnter2D (Collider2D coll)
    {
        Pillar currentP = new Pillar();
        bool doubled = false;

        if (coll.tag == "Pillar")
        {
            //Component[] cs = (Component[])coll.transform.parent.GetComponents(typeof(Component));
            //foreach (Component c in cs)
            //{
            //    Debug.Log(c.GetType());
            //    if (c.GetType() == typeof(PillarElastic))
            //    {
            //        currentP = coll.transform.parent.GetComponent<PillarElastic>();
            //        break;

            //    }
            //    else if (c.GetType() == typeof(PillarLock))
            //    {
            //        currentP = coll.transform.parent.GetComponent<PillarLock>();
            //        break;

            //    }

            //    else if (c.GetType() == typeof(Pillar))
            //    {
            //        currentP = coll.transform.parent.GetComponent<Pillar>();
            //        break;
            //    }

            //}

           //if (coll.transform.parent != null)
      
           //     currentP = coll.transform.parent.GetComponent<Pillar>();
            
           //else currentP = coll.gameObject.GetComponent<Pillar>();

            if(coll.transform.parent != null & coll.transform.parent.tag=="Pillar")
                currentP = coll.transform.parent.GetComponent<Pillar>();
            else currentP = coll.gameObject.GetComponent<Pillar>();

            if (pillarCount == 0)
            { selectedPillars[0] = currentP;

                pillarCount = 1;
            }
            else
            {
                foreach (Pillar pillar in selectedPillars)
                {
                    if (currentP == pillar)
                    {
                        doubled = true;
                        break; }

                }

                if(!doubled)
                 selectedPillars[pillarCount++] = currentP;


            }
            Debug.Log(pillarCount);

        }

    }

    public void CheckpointReached()
    {

        
       for (int j=0; j<pillarCount; j++)
       {
            Debug.Log(selectedPillars.Length);
           selectedPillars[j].locked = true;
           selectedPillars[j] = null;
       }
       pillarCount = 0;
    }
}
