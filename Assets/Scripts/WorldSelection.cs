using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldSelection : MonoBehaviour {

	LevelSelection levelSelection;

	public GameObject[] worldPillars;
	public int world=0;

	public Text txtWorld1;
	public Text txtWorld2;
	public Text txtWorld3;

	void Start () 
	{
		GameObject player2 = GameObject.Find ("Player2");
		levelSelection = player2.GetComponent<LevelSelection>();
	}
		
	void OnTriggerEnter2D(Collider2D coll)
	{
		/*
		if (levelSelection.launched == true && (coll.gameObject == worldPillars [0] || coll.gameObject == worldPillars [1] || coll.gameObject == worldPillars [2])){
			StopAllCoroutines ();
			world = 0;
			txtWorld1.color = Color.black;txtWorld2.color = Color.black;txtWorld3.color = Color.black;
			levelSelection.txtLevel1.color = Color.black;levelSelection.txtLevel2.color = Color.black;levelSelection.txtLevel3.color = Color.black;levelSelection.txtLevel4.color = Color.black;levelSelection.txtLevel5.color = Color.black;levelSelection.txtLevel6.color = Color.black;levelSelection.txtLevel7.color = Color.black;levelSelection.txtLevel8.color = Color.black;levelSelection.txtLevel9.color = Color.black;levelSelection.txtLevel10.color = Color.black;
		}else{
		*/
		if (levelSelection.launched != true) {
			if (coll.gameObject == worldPillars [0]) {
				world = 1;
				txtWorld1.color = Color.red;
				txtWorld2.color = Color.black;
				txtWorld3.color = Color.black;
			} else if (coll.gameObject == worldPillars [1]) {
				world = 2;
				txtWorld1.color = Color.black;
				txtWorld2.color = Color.red;
				txtWorld3.color = Color.black;
			} else if (coll.gameObject == worldPillars [2]) {
				world = 3;
				txtWorld1.color = Color.black;
				txtWorld2.color = Color.black;
				txtWorld3.color = Color.red;
			}
		}
	}
}
