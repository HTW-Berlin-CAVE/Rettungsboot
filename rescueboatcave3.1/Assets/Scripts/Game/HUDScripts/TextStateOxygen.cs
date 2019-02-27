using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateOxygen : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text oxygenText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		oxygenText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		oxygenText.text = boardSystem.OxygenLevelLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			oxygenText.color = boardSystem.HudColor;
		}
		else
		{
			oxygenText.color = notVisible;
		}
	}
}
