using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateBattery : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text batteryText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		batteryText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		batteryText.text = boardSystem.BatteryLevelLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			batteryText.color = boardSystem.HudColor;
		}
		else
		{
			batteryText.color = notVisible;
		}
	}
}
