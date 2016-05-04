using UnityEngine;
using System.Collections;

public class WorldSelection : MonoBehaviour {

	public GameObject[] worldPillars;
	public int world=0;

	public Renderer colorRenderer;

	void Start () 
	{
		colorRenderer.GetComponent<Renderer> ();
	}

	void Update () 
	{
		

	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject == worldPillars [0]) {
			world = 1;
			colorRenderer.material.color= Color.red;
		} 
		else if (coll.gameObject == worldPillars [1]) 
		{
			world = 2;
			colorRenderer.material.color= Color.blue;
		} 
		else if (coll.gameObject == worldPillars [2]) 
		{
			world = 3;
			colorRenderer.material.color= Color.green;
		}
	}
}
