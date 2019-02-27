using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateHull : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text hullText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		hullText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		hullText.text = boardSystem.HullLevelLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			hullText.color = boardSystem.HudColor;
		}
		else
		{
			hullText.color = notVisible;
		}
	}
}
