using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextIdleStartUp : MonoBehaviour {

	public byte hudMode;
	public string[] postTextPhrases =
	{
		"Checking RAM              ", ".", ".", ".", ".", ".", ".","    524288 KB          OK\n",
		"CPU DETECTED              ", "", ":PENTIUM III\n",
		"CPU CLOCK                   ", "", ":1.4 GHz\n",
		"PRIMARY  MASTER        ", "", "", ":NONE\n",
		"SECONDARY MASTER    ", "", ":LBA ATA100, 40022 MB\n","","","",
		"SERIAL PORT<S>           ", "", ":3F8; 2F8\n","","",
		"PARALLEL PORT(S)       ", "", "", "", ":NONE\n","",
		"DISPLAY TYPE               ", "", ":EGA/VGA\n","",
		"DDR AI ROW<S>            ", "", ":0 2 3\n",
		"No keyboard present.....", "\n_", "", "", "",
	};
	public string[] bootTextPhrases =
	{
		"/", "-", "\\", "|", "/", "-", "\\", "|"
	};


	private State_HUD boardSystem;
	private Text startUpText;
	private Color notVisible;

	private float postTextPhraseDuration;
	private float textStopwatch;
	private byte phraseIndexer;
	private bool postPhaseLastFrame;
	private bool bootPhaseLastFrame;
	private bool phaseEnd;

    



	void Start () {
		boardSystem = GameObject.Find("BoardSystem").GetComponent<State_HUD>();
		startUpText = this.gameObject.GetComponent<Text>();
		notVisible = new Color(0, 0, 0, 0);
		postTextPhraseDuration =
			((float) ((float) boardSystem.TimeDuringPOST / (float) (postTextPhrases.Length + 1)));
	//	Debug.Log("postTextPhraseDuration: " + postTextPhraseDuration);
		textStopwatch = 0;
		phraseIndexer = 0;
		startUpText.text = String.Empty;
	}
	
	void Update () {
		AdaptToHudSetting();
		AdaptToStartUpSequence();
	}
   
 /*  public IEnumerator Booting(float post, float boot)
    {
        AdaptToHudSetting();
        bool postPhase = false;
         bool bootPhase = false;
        postPhase = true;
        bootPhase = false;
        PlayPOSTText();

        yield return new WaitForSecondsRealtime(post);
        postPhase = false;
        bootPhase = true;
        PlayBootText();

        yield return new WaitForSecondsRealtime(post);

        CleanUpText();
        phaseEnd = false;
        postPhase = false;
        bootPhase = false;
        boardSystem.HudLock = false;

        yield return null;
    }

        */
	private void AdaptToHudSetting()
	{		
		if (hudMode == boardSystem.Hud)
		{
			startUpText.color = boardSystem.HudColor;
		}
		else
		{
			startUpText.color = notVisible;
		}	
	}

	private void AdaptToStartUpSequence()
	{
		CheckPhaseEnd();
		if (phaseEnd == true)
		{
			CleanUpText();
			phaseEnd = false;
		}
		if (boardSystem.POSTPhase == true)
		{
			PlayPOSTText();
		}
		if (boardSystem.BootPhase == true)
		{
			PlayBootText();
		}
		
	}
    

	private void CheckPhaseEnd()
	{
		if (postPhaseLastFrame != boardSystem.POSTPhase || bootPhaseLastFrame != boardSystem.BootPhase)
		{
			phaseEnd = true;
		}
		postPhaseLastFrame = boardSystem.POSTPhase;
		bootPhaseLastFrame = boardSystem.BootPhase;
	}

	private void PlayPOSTText()
	{
		byte phraseCount = (byte) (textStopwatch / postTextPhraseDuration);
		if (phraseCount < postTextPhrases.Length)
		{
			startUpText.text = String.Empty;
			for (byte i = 0; i < phraseCount; i++)
			{
				startUpText.text += postTextPhrases[i];
			}
		}
		textStopwatch += Time.deltaTime;
	//	Debug.Log("Text Stopwatch Post:" + textStopwatch);
	}


	private void PlayBootText()
	{
		float phraseCount = ((float) textStopwatch / (1F / (float) bootTextPhrases.Length));
	//	Debug.Log("Phrase Count: " + phraseCount);
		startUpText.text = bootTextPhrases[((int) phraseCount) % bootTextPhrases.Length];
		textStopwatch += Time.deltaTime;
	//	Debug.Log("Text Stopwatch Boot:" + textStopwatch);
	}

	private void CleanUpText()
	{
		startUpText.text = String.Empty;
		textStopwatch = 0;
		
	}
}
