using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {

	public Dropdown drpResolution;
	
	//public Slider sldBrightness;
	
	//public Slider sldMusic;
	//public Slider sldFX;
	
	public AudioSource audioSrc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.25f, .12f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.2f, .1f); //Il pulsante si rimpicciolisce
	}
	public void ChangeResolution()
	{
		if(drpResolution.value==0)
		{
			Screen.SetResolution(512, 384, true);
		}
		if(drpResolution.value==1)
		{
			Screen.SetResolution(640, 400, true);
		}
		if(drpResolution.value==2)
		{
			Screen.SetResolution(640, 480, true);
		}
		if(drpResolution.value==3)
		{
			Screen.SetResolution(800, 600, true);
		}
		if(drpResolution.value==4)
		{
			Screen.SetResolution(1024, 768, true);
		}
		if(drpResolution.value==5)
		{
			Screen.SetResolution(1280, 600, true);
		}
		if(drpResolution.value==6)
		{
			Screen.SetResolution(1280, 720, true);
		}
		if(drpResolution.value==7)
		{
			Screen.SetResolution(1280, 768, true);
		}
		if(drpResolution.value==8)
		{
			Screen.SetResolution(1360, 768, true);
		}
		if(drpResolution.value==9)
		{
			Screen.SetResolution(1366, 758, true);
		}
	}
	
	public void ChangeBrightness()
	{
		
	}
	
	public void ChangeMusicVolume()
	{
		audioSrc.volume=GameObject.Find("sldMusicVolume").GetComponent<UnityEngine.UI.Slider>().value;
	}
	
	public void KeyToJoy(Animator anim)
	{
		anim.SetBool("ShowJoypad", false);
	}
	
	public void JoyToKey(Animator anim)
	{
		anim.SetBool("ShowJoypad", true);
	}
}
