using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeExploration : MonoBehaviour {

	public byte hudMode;
    public MeshRenderer radarmesh;


	private State_HUD boardSystem;
	private Color notVisible;


	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		notVisible = new Color(0, 0, 0, 0);
        GameObject radar = GameObject.FindWithTag("radar");
        radarmesh = radar.GetComponent<MeshRenderer>();
       
	}

	void Update () {
		AdaptToHudSetting();
	}

	private void AdaptToHudSetting()
	{
		if (hudMode == boardSystem.Hud)
		{
			this.GetComponent<SpriteRenderer>().color = boardSystem.HudColor;
            // radar.SetActive(true);
            radarmesh.enabled = true;
		}
		else
		{
			this.GetComponent<SpriteRenderer>().color = notVisible;
            //radar.SetActive(false);
            radarmesh.enabled = false;
		}
	}
}
