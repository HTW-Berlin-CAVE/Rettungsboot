using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateEngine : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text engineText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		engineText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		engineText.text = boardSystem.EngineConditionLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			engineText.color = boardSystem.HudColor;
		}
		else
		{
			engineText.color = notVisible;
		}
	}
}
