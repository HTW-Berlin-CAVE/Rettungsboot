using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateAutoPilot : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text autoPilotText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		autoPilotText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		autoPilotText.text = boardSystem.AutoPilotConditionLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			autoPilotText.color = boardSystem.HudColor;
		}
		else
		{
			autoPilotText.color = notVisible;
		}
	}
}
