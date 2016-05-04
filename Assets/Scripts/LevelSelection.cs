﻿using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	public GameObject[] levelPillars;

	public int level=0;

	WorldSelection selectedWorld;

	void Start () {

		GameObject player1 = GameObject.Find ("Player1");
		selectedWorld = player1.GetComponent<WorldSelection>();
	}
		
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject == levelPillars[0])
		{
			level = 1;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (2);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (12);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (22);
			}

		}
		else if (coll.gameObject == levelPillars[1])
		{
			level = 2;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (3);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (13);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (23);
			}
		}
		else if (coll.gameObject == levelPillars[2])
		{
			level = 3;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (4);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (14);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (24);
			}
		}
		else if (coll.gameObject == levelPillars[3])
		{
			level = 4;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (5);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (15);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (25);
			}
		}
		else if (coll.gameObject == levelPillars[4])
		{
			level = 5;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (6);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (16);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (26);
			}
		}
		else if (coll.gameObject == levelPillars[5])
		{
			level = 6;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (7);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (17);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (27);
			}
		}
		else if (coll.gameObject == levelPillars[6])
		{
			level = 7;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (8);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (18);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (28);
			}
		}
		else if (coll.gameObject == levelPillars[7])
		{
			level = 8;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (9);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (19);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (29);
			}
		}
		else if (coll.gameObject == levelPillars[8])
		{
			level = 9;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (10);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (20);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (30);
			}
		}
		else if (coll.gameObject == levelPillars[9])
		{
			level = 10;

			if (selectedWorld.world == 1) 
			{
				Application.LoadLevel (11);
			}
			else if (selectedWorld.world == 2) 
			{
				Application.LoadLevel (21);
			}
			else if (selectedWorld.world == 3) 
			{
				Application.LoadLevel (31);
			}
		}
	}
}