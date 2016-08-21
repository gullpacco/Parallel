using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {


   public  bool setOn;
    public bool skip;
    public int skipNumber;
    public int initialSkip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool Skip()
    {

        if (skip)
        {
            if (initialSkip >= skipNumber)
            {
                initialSkip = 0;
                return true;
            }
            else
            {
                initialSkip++;
                return false;
            }
        }

        else
        {
            return true;
        }
    }


}
