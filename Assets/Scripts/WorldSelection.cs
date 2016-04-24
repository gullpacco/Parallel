using UnityEngine;
using System.Collections;

public class WorldSelection : MonoBehaviour {

	public GameObject[] worldPillars;
	public int world=0;

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.gameObject == worldPillars [0]) {
			world = 1;

		} 
		else if (coll.gameObject == worldPillars [1]) 
		{
			world = 2;
		} 
		else if (coll.gameObject == worldPillars [2]) 
		{
			world = 3;
		}
	}
}
