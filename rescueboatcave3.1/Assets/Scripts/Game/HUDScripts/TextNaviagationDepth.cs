using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNaviagationDepth : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text depthText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		depthText = this.gameObject.GetComponent<Text>();
		notVisible = new Color (0, 0, 0, 0);
	}

	void Update () {
		AdaptToHudSetting();
		depthText.text = boardSystem.Depth;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			depthText.color = boardSystem.HudColor;
		}
		else
		{
			depthText.color = notVisible;
		}
	}
}
