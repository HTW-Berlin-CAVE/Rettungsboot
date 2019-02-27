using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextExplorationCourse : MonoBehaviour {

	public byte hudMode;


	private State_HUD boardSystem;
	private Text courseText;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		courseText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
	}

	void Update () {
		GetCourse();
		AdaptToHudSetting();
	}

	private void GetCourse() 
	{
		courseText.text = boardSystem.Course;
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			courseText.color = boardSystem.HudColor;
		}
		else
		{
			courseText.color = notVisible;
		}
	}

}
