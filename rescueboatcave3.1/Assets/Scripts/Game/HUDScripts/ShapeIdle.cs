using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeIdle : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		notVisible = new Color (0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		AdaptToStartUpSequence();
	}

	private void AdaptToHudSetting()
	{
		if (boardSystem.HudLock == false)
		{
			if (hudMode == boardSystem.Hud)
			{
				this.GetComponent<SpriteRenderer>().color = boardSystem.HudColor;
			}
			else
			{
				this.GetComponent<SpriteRenderer>().color = notVisible;
			}
		}
	}

	private void AdaptToStartUpSequence()
	{
		if (boardSystem.HudLock == true)
		{
			if (boardSystem.POSTPhase == false)
			{
				this.GetComponent<SpriteRenderer>().color = boardSystem.HudColor;
			}
			else
			{
				this.GetComponent<SpriteRenderer>().color = notVisible;
			}
		}
	}
}
