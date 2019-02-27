using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStatePressure : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text pressureText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		pressureText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		pressureText.text = boardSystem.PressureLevelLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			pressureText.color = boardSystem.HudColor;
		}
		else
		{
			pressureText.color = notVisible;
		}
	}
}
