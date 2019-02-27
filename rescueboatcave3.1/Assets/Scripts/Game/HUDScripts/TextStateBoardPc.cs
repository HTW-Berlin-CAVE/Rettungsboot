using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateBoardPc : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text boardPcText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		boardPcText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		boardPcText.text = boardSystem.BoardPcConditionLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			boardPcText.color = boardSystem.HudColor;
		}
		else
		{
			boardPcText.color = notVisible;
		}
	}
}
