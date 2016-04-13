﻿using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.X))
            Application.LoadLevel("Tutorial");
        if (Input.GetKeyDown(KeyCode.C))
            Application.LoadLevel("Intermedio");
    if(Input.GetKeyDown(KeyCode.V))
            Application.LoadLevel("Difficile");

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            Application.LoadLevel(nextLevel);
        }
    }

}