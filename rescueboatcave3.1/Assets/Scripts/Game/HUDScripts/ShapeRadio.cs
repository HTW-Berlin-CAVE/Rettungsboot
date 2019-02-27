using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeRadio : MonoBehaviour {

	public Sprite[] radioLevelShapes;
	public byte hudMode;


	private State_HUD boardSystem;
	private Color notVisible;
	private SpriteRenderer displayer;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		displayer = this.gameObject.GetComponent<SpriteRenderer>();
		displayer.sprite = radioLevelShapes[0];
	}
	
	// Update is called once per frame
	void Update () {
		AdaptToHudSetting();
		AdaptToRadioLevel();

	}

	private void AdaptToHudSetting()
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

	private void AdaptToRadioLevel()
	{
		if (boardSystem.RadioContact == true)
		{
			displayer.sprite = radioLevelShapes[boardSystem.RadioLevel];
			Debug.Log("Radio Level: " + boardSystem.RadioLevel);
		}
		else
		{
			displayer.sprite = radioLevelShapes[boardSystem.RadioLevel];
		}
	}
}
