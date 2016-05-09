﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {

	WorldSelection worldSelection;

	public GameObject pillarCollided;
	public GameObject[] levelPillars;
	public int level=0;

	public bool launched=false;
	public bool space=false;

	public Text txtLevel1;
	public Text txtLevel2;
	public Text txtLevel3;
	public Text txtLevel4;
	public Text txtLevel5;
	public Text txtLevel6;
	public Text txtLevel7;
	public Text txtLevel8;
	public Text txtLevel9;
	public Text txtLevel10;

	//BlurEffect blur;

	void Start () 
	{
		Time.timeScale=1;

		GameObject player1 = GameObject.Find ("Player1");
		worldSelection = player1.GetComponent<WorldSelection>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space)){

			launched = false;
			StopAllCoroutines();
			worldSelection.txtWorld1.color = Color.black;worldSelection.txtWorld2.color = Color.black;worldSelection.txtWorld3.color = Color.black;
			txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel ("Menu2.0");
		}
	}
		
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (worldSelection.world!=0 && launched!=true && (coll.gameObject==levelPillars[0]||coll.gameObject==levelPillars[1]||coll.gameObject==levelPillars[2]||coll.gameObject==levelPillars[3]||coll.gameObject==levelPillars[4]||coll.gameObject==levelPillars[5]||coll.gameObject==levelPillars[6]||coll.gameObject==levelPillars[7]||coll.gameObject==levelPillars[8]||coll.gameObject==levelPillars[9])) 
		{
			if (coll.gameObject == levelPillars [0]) {
				level = 1;
				txtLevel1.color = Color.red;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [1]) {
				level = 2;
				txtLevel1.color = Color.black;txtLevel2.color = Color.red;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [2]) {
				level = 3;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.red;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [3]) {
				level = 4;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.red;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [4]) {
				level = 5;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.red;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [5]) {
				level = 6;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.red;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [6]) {
				level = 7;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.red;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [7]) {
				level = 8;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.red;txtLevel9.color = Color.black;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [8]) {
				level = 9;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.red;txtLevel10.color = Color.black;
			} else if (coll.gameObject == levelPillars [9]) {
				level = 10;
				txtLevel1.color = Color.black;txtLevel2.color = Color.black;txtLevel3.color = Color.black;txtLevel4.color = Color.black;txtLevel5.color = Color.black;txtLevel6.color = Color.black;txtLevel7.color = Color.black;txtLevel8.color = Color.black;txtLevel9.color = Color.black;txtLevel10.color = Color.red;
			}

			if (worldSelection.world == 1) {
				StartCoroutine(preloadLevel (level + 1));
			} else if (worldSelection.world == 2) {
				StartCoroutine(preloadLevel (level + 11));
			} else if (worldSelection.world == 3) {
				StartCoroutine(preloadLevel (level + 21));
			}
		}
	}

	IEnumerator preloadLevel(int levelToPreload) 
	{
		launched = true;

		yield return new WaitForSeconds(3f);

		AsyncOperation async=Application.LoadLevelAsync(levelToPreload);

		launched = false;

		StopAllCoroutines();
	}
}

