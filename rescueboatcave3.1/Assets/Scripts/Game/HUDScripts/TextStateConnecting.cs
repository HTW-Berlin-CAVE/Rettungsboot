using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStateConnecting : MonoBehaviour {

	public string[] signalingMessage = {"Connecting", "Connecting.", "Connecting..", "Connecting..."};
	public byte hudMode;


	private State_HUD boardSystem;
	private Text connectingText;
	private Color notVisible;

	private float textTimeCounter;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		connectingText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
		textTimeCounter = 0;
	}

	void Update () {
		AdaptToHudSetting();
		if (boardSystem.RadioContact == true && boardSystem.RadioConnection == false)
		{
			RunConnectingLoop();
		}
		else
		{
			CancelConnectingLoop();
		}
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			connectingText.color = boardSystem.HudColor;
		}
		else
		{
			connectingText.color = notVisible;
		}
	}

	private void RunConnectingLoop()
	{
		textTimeCounter += Time.deltaTime * 3;
		if (textTimeCounter >= 4)
		{
			textTimeCounter = 0;
		}
		connectingText.text = signalingMessage[((byte) textTimeCounter) % 4];

	}

	private void CancelConnectingLoop()
	{
		textTimeCounter = 0;
		connectingText.text = String.Empty;
	}

}
