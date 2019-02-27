using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateRescSignal : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text rescSignalText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		rescSignalText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		rescSignalText.text = boardSystem.RescSignalConditionLabel;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			rescSignalText.color = boardSystem.HudColor;
		}
		else
		{
			rescSignalText.color = notVisible;
		}
	}
}
