
using System.Collections;
using UnityEngine;
using JoyconLib;
using Htw.Cave.Joycon;

public class animator_helper : MonoBehaviour
{

    public Animator game;
    public AudioClip seamineExplosion;

    public GameObject HUDSpawnPoint;
    public SpawnHUD spawnHUD;
    public EngineSound engine;
    public submarineStat stat;
    public PlayerMovement playerMovement;
    public AudioSource audioSource;

    public bool isstarted;
    public int activeHUD;
    public bool HudLock;

    // Use this for initialization
    void Start()
    {

        HudLock = true;
        isstarted = false;
        activeHUD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        forceRestart();

        if (!isstarted)
        {
            startGame();
        }

        if (isstarted)
        {
            userinput();
            CheckHudSelection();
        }

    }

    private void startGame()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            game.SetTrigger("isAnyKeypressed");
            PlayerMovement.steer = true;
            spawnHUD.spawnHUD();
            isstarted = true;
        }

        if (JoyconHelper.GetRightJoycon() != null)
        {
            if (JoyconHelper.GetRightJoycon().GetButtonDown(Joycon.Button.PLUS))
            {
                game.SetTrigger("isAnyKeypressed");
                PlayerMovement.steer = true;
                spawnHUD.spawnHUD();
                isstarted = true;
            }
        }
    }

    void forceRestart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            stat.destroySubmarine();
        }

        if (JoyconHelper.GetRightJoycon() != null)
        {
            if (JoyconHelper.GetRightJoycon().GetButtonDown(Joycon.Button.DPAD_UP))
            {
                stat.destroySubmarine();
            }
        }

    }

    void userinput()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (game.GetBool("autopilot"))
            {
                game.SetBool("autopilot", false);
            }
            else
            {
                game.SetBool("autopilot", true);
            }
        }
        if (JoyconHelper.GetRightJoycon() != null)
        {
            if (JoyconHelper.GetRightJoycon().GetButtonDown(Joycon.Button.DPAD_DOWN))
            {
                if (game.GetBool("autopilot"))
                {
                    game.SetBool("autopilot", false);
                }
                else
                {
                    game.SetBool("autopilot", true);
                }
            }
        }

    }



    private void CheckHudSelection()
    {
        if (HudLock == false)
        {
            if (activeHUD == 0)
            {
                activeHUD = 3;
            }
        }
    }


    public void restart()
    {
        //hier muss noch eine übergangscreen oder sowas eingebauen werden
        game.SetBool("autopilot", false);
        game.SetBool("startDrivingAI", false);
        AudioSource audio = gameObject.GetComponentInChildren<AudioSource>();
        audio.Stop();
        engine.silent();
        stat.started = false;
        isstarted = false;
        HudLock = true;
        spawnHUD.destroyHUD();
        activeHUD = 0;
        StartCoroutine(moveAndResetSubmarine());
        game.Play("restart", 0, 0);
        PlayerMovement.steer = false;
    }

    IEnumerator moveAndResetSubmarine()
    {

        yield return new WaitForSeconds(1);
        playerMovement.ResetLocation();
    }

}
