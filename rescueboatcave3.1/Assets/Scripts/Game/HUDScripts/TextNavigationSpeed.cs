using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNavigationSpeed : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text speedText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		speedText = this.gameObject.GetComponent<Text>();
		notVisible = new Color (0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		speedText.text = boardSystem.Speed;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			speedText.color = boardSystem.HudColor;
		}
		else
		{
			speedText.color = notVisible;
		}
	}
}
