using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAllCollision : MonoBehaviour {

	public State_HUD boardSystem;
    public Text warningText;
    public Color notVisible;
    public Color flashing;
    public bool toggle;
    public bool flashInvoked;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		warningText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
		warningText.color = notVisible;
		flashing = new Color(boardSystem.HudColor.grayscale , 0, 0, boardSystem.HudColor.a);

	}

	void Update () {
		AdaptToCollisionWarning();
	}


	private void AdaptToCollisionWarning()
	{
		if (boardSystem.CollisionWarning == true)
		{
			if (flashInvoked == false)
			{
				toggle = false;
				warningText.color = flashing;
				InvokeRepeating("CollisionWarningFlash", 0.0F , 0.5F);
				flashInvoked = true;
			}
		}
		else
		{
			if (flashInvoked == true)
			{
				toggle = true;
				warningText.color = notVisible;
				CancelInvoke();
				flashInvoked = false;
			}
		}
	}

	private void CollisionWarningFlash()
	{
		if (toggle == false)
		{
			toggle = true;
			warningText.color = flashing;
		}
		else
		{
			toggle = false;
			warningText.color = notVisible;
		}
	}


}
