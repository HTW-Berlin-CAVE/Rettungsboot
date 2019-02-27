using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateRadio : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text radioText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		radioText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		radioText.text = boardSystem.RadioConditionLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			radioText.color = boardSystem.HudColor;
		}
		else
		{
			radioText.color = notVisible;
		}
	}
}
