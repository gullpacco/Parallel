using UnityEngine;
using System.Collections;

public class HotKeyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Application.LoadLevel("Level_1");
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			Application.LoadLevel("Level_2");
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			Application.LoadLevel("Level_3");
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			Application.LoadLevel("Level_4");
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			Application.LoadLevel("Level_5");
		}
		if(Input.GetKeyDown(KeyCode.Alpha6)){
			Application.LoadLevel("Level_6");
		}
	}
}
