using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateTime : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text timeText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		timeText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}
		
	void Update () {
		AdaptToHudSetting();
		timeText.text = boardSystem.PassedTimeLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			timeText.color = boardSystem.HudColor;
		}
		else
		{
			timeText.color = notVisible;
		}
	}


}
