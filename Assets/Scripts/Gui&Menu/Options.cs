using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Options : MonoBehaviour {

	public Dropdown drpResolution;
	
	public InputField fldJumpUp;
	public InputField fldMoveFrontUp;
	public InputField fldMoveBackUp;
	
	public InputField fldJumpDown;
	public InputField fldMoveFrontDown;
	public InputField fldMoveBackDown;
	
	private InputField fldTemp;
	private bool isFldSelected;
	//public Slider sldBrightness;
	
	//public Slider sldMusic;
	//public Slider sldFX;
	
	public AudioSource audioSrc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isFldSelected)
		{
			if(Input.GetKeyDown("up"))
			{
				fldTemp.text="up arrow key";
				if(fldTemp.name=="txtInputJump")
				{
					PlayerController.jumpUp="up";
				}
				else if(fldTemp.name=="txtInputMoveForward")
				{
					PlayerController.moveFrontUp="up";
				}
				else if(fldTemp.name=="txtInputMoveBack")
				{
					PlayerController.moveBackUp="up";
				}
				if(fldTemp.name=="txtInputJump (1)")
				{
					PlayerController.jumpDown="up";
				}
				else if(fldTemp.name=="txtInputMoveForward (1)")
				{
					PlayerController.moveFrontDown="up";
				}
				else if(fldTemp.name=="txtInputMoveBack (1)")
				{
					PlayerController.moveBackDown="up";
				}
			}	
			
			if(Input.GetKeyDown("down"))
			{
				fldTemp.text="down arrow key";
				if(fldTemp.name=="txtInputJump")
				{
					PlayerController.jumpUp="down";
				}
				else if(fldTemp.name=="txtInputMoveForward")
				{
					PlayerController.moveFrontUp="down";
				}
				else if(fldTemp.name=="txtInputMoveBack")
				{
					PlayerController.moveBackUp="down";
				}
				if(fldTemp.name=="txtInputJump (1)")
				{
					PlayerController.jumpDown="down";
				}
				else if(fldTemp.name=="txtInputMoveForward (1)")
				{
					PlayerController.moveFrontDown="down";
				}
				else if(fldTemp.name=="txtInputMoveBack (1)")
				{
					PlayerController.moveBackDown="down";
				}
			}
			
			if(Input.GetKeyDown("left"))
			{
				fldTemp.text="left arrow key";
				if(fldTemp.name=="txtInputJump")
				{
					PlayerController.jumpUp="left";
				}
				else if(fldTemp.name=="txtInputMoveForward")
				{
					PlayerController.moveFrontUp="left";
				}
				else if(fldTemp.name=="txtInputMoveBack")
				{
					PlayerController.moveBackUp="left";
				}
				if(fldTemp.name=="txtInputJump (1)")
				{
					PlayerController.jumpDown="left";
				}
				else if(fldTemp.name=="txtInputMoveForward (1)")
				{
					PlayerController.moveFrontDown="left";
				}
				else if(fldTemp.name=="txtInputMoveBack (1)")
				{
					PlayerController.moveBackDown="left";
				}
			}
			if(Input.GetKeyDown("right"))
			{
				fldTemp.text="right arrow key";
				if(fldTemp.name=="txtInputJump")
				{
					PlayerController.jumpUp="right";
				}
				else if(fldTemp.name=="txtInputMoveForward")
				{
					PlayerController.moveFrontUp="right";
				}
				else if(fldTemp.name=="txtInputMoveBack")
				{
					PlayerController.moveBackUp="right";
				}
				if(fldTemp.name=="txtInputJump(1)")
				{
					PlayerController.jumpDown="right";
				}
				else if(fldTemp.name=="txtInputMoveForward (1)")
				{
					PlayerController.moveFrontDown="right";
				}
				else if(fldTemp.name=="txtInputMoveBack (1)")
				{
					PlayerController.moveBackDown="right";
				}
			}
		}
	}
	
	public void jumpUpChanged(string text)
	{
		
		if(fldTemp.text=="up arrow key")
		{
			PlayerController.jumpUp="up";
		}
		else if(fldTemp.text=="down arrow key")
		{
			PlayerController.jumpUp="down";
		}
		else if(fldTemp.text=="left arrow key")
		{
			PlayerController.jumpUp="left";
		}
		else if(fldTemp.text=="right arrow key")
		{
			PlayerController.jumpUp="right";
		}
		else
		{
			PlayerController.jumpUp=text;
		}
	}
	public void moveFrontUpChanged(string text)
	{
		if(fldTemp.text=="up arrow key")
		{
			PlayerController.moveFrontUp="up";
		}
		else if(fldTemp.text=="down arrow key")
		{
			PlayerController.moveFrontUp="down";
		}
		else if(fldTemp.text=="left arrow key")
		{
			PlayerController.moveFrontUp="left";
		}
		else if(fldTemp.text=="right arrow key")
		{
			PlayerController.moveFrontUp="right";
		}
		else
		{
			PlayerController.moveFrontUp=text;
		}
	}
	public void moveBackUpChanged(string text)
	{
		if(fldTemp.text=="up arrow key")
		{
			PlayerController.moveBackUp="up";
		}
		else if(fldTemp.text=="down arrow key")
		{
			PlayerController.moveBackUp="down";
		}
		else if(fldTemp.text=="left arrow key")
		{
			PlayerController.moveBackUp="left";
		}
		else if(fldTemp.text=="right arrow key")
		{
			PlayerController.moveBackUp="right";
		}
		else
		{
			PlayerController.moveBackUp=text;
		}
	}
	public void jumpDownChanged(string text)
	{
		if(fldTemp.text=="up arrow key")
		{
			PlayerController.jumpDown="up";
		}
		else if(fldTemp.text=="down arrow key")
		{
			PlayerController.jumpDown="down";
		}
		else if(fldTemp.text=="left arrow key")
		{
			PlayerController.jumpDown="left";
		}
		else if(fldTemp.text=="right arrow key")
		{
			PlayerController.jumpDown="right";
		}
		else
		{
			PlayerController.jumpDown=text;
		}
	}
	public void moveFrontDownChanged(string text)
	{
		if(fldTemp.text=="up arrow key")
		{
			PlayerController.moveFrontDown="up";
		}
		else if(fldTemp.text=="down arrow key")
		{
			PlayerController.moveFrontDown="down";
		}
		else if(fldTemp.text=="left arrow key")
		{
			PlayerController.moveFrontDown="left";
		}
		else if(fldTemp.text=="right arrow key")
		{
			PlayerController.moveFrontDown="right";
		}
		else
		{
			PlayerController.jumpUp=text;
		}
	}
	public void moveBackDownChanged(string text)
	{
		if(fldTemp.text=="up arrow key")
		{
			PlayerController.moveBackDown="up";
		}
		else if(fldTemp.text=="down arrow key")
		{
			PlayerController.moveBackDown="down";
		}
		else if(fldTemp.text=="left arrow key")
		{
			PlayerController.moveBackDown="left";
		}
		else if(fldTemp.text=="right arrow key")
		{
			PlayerController.moveBackDown="right";
		}
		else
		{
			PlayerController.moveBackDown=text;
		}
	}
	public void selectInputField(InputField selectedFld)
	{
		fldTemp=selectedFld;
		isFldSelected=true;
	}
	
	public void deselectInputField()
	{
		fldTemp=null;
		isFldSelected=false;
	}
	
	public void OverBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.25f, .12f); //Il pulsante si rimpicciolisce
	}

	public void OutBtn(Button selectedButton)
	{
		selectedButton.transform.localScale = new Vector2(.2f, .1f); //Il pulsante si rimpicciolisce
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
	
	public void ChangeResolution(){if(drpResolution.value==0)
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
}
