using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeCrane : MonoBehaviour {


	private State_HUD boardSystem;
	private Color notVisible;

	// Use this for initialization
	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		notVisible = new Color(0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		AdaptToCraneCondition();
	}

	private void AdaptToCraneCondition()
	{
		if (boardSystem.CraneCondition == true)
		{
			this.GetComponent<SpriteRenderer>().color = boardSystem.HudColor;
		}
		else
		{
			this.GetComponent<SpriteRenderer>().color = notVisible;
		}
	}

	private void AdaptToHudSettings()
	{
//		if (hudMode == boardSystem.Hud)
//		{
//			this.GetComponent<SpriteRenderer>().color = boardSystem.HudColor;
//		}
//		else
//		{
//			this.GetComponent<SpriteRenderer>().color = notVisible;
//		}
	}
}
