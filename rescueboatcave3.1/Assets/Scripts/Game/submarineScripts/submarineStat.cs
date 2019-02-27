using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class submarineStat : MonoBehaviour
{


    /*
   * Ship Stuff
   */
    public GameObject Alarmlight;
    public CapsuleCollider subCollider;
    public Animator game;
    public Light Light;
    public State_HUD hudstat;
    public animator_helper ani_help;
    public GameObject ship;
   


    public float health;
    public bool collideWarning;

    public float status = 0;

    public float air;
    public float airmax = 100;
    
    const float AIR_LOSS_FACTOR = 0.3f;

    public bool engineIsOn = true;


    public bool lightInsideIsOn = false;
    public bool lightOutsideIsOn = false;

    public bool isAlarmOn;

    public int health_max = 100;
    public bool started = false;






    // Use this for initialization
    void Start()
    {
        // sets light inside the ship on start out
        Light.intensity = 0;
        game = GetComponent<Animator>();
        subCollider = GetComponentInChildren<CapsuleCollider>();
        Alarmlight.GetComponent<Light>().gameObject.SetActive(false);
        ani_help = GetComponent<animator_helper>();
    }

    // Update is called once per frame
    void Update()
    {
     
        StartCoroutine(isAlarmlight());
        if (started)
        {
            StartCoroutine(updateHUD());
            StartCoroutine(AirControll());
        }
    }

    public void searchHUD()
    {
        hudstat = GetComponentInChildren<State_HUD>();
        hudstat.setShip(ship);
        started = true;
    }


    IEnumerator updateHUD()
    {
        hudstat.RadioContact = game.GetBool("isoverSend");
        hudstat.CollisionWarning = collideWarning;
        hudstat.OxygenLevel = (byte)air;
        hudstat.BatteryLevel = 40;
        hudstat.PressureLevel = 69;
        hudstat.HullLevel = (byte)health;
        hudstat.BoardPcCondition = game.GetBool("skip");
        hudstat.AutoPilotCondition = game.GetBool("autopilot");
        hudstat.EngineCondition = true; // yep its a hack, but the engines are ok when the hud is visible 
        hudstat.CraneCondition = game.GetBool("isoverOxygen");
        hudstat.activeHud =ani_help.activeHUD ;
        ani_help.HudLock = hudstat.HudLock;

        yield return null;
    }

  
    IEnumerator AirControll()
    {
        air -= Time.deltaTime * AIR_LOSS_FACTOR;
        if (air < 50)
        {
            AirLow();
        }

        yield return null;
    }

    public void AirLow()
    {
        if (!game.GetBool("airLow"))
        {
            game.SetTrigger("airLowTrigger");
        }
        game.SetBool("airLow", true);
     
    }

    public void refillOxygen()
    {
        air = airmax;
        game.SetBool("oxygen full", true);
        game.SetBool("airLow", false);
        
    }

    public void precautionCollisionDetection(bool isCollide)
    {
        collideWarning = isCollide;
    }


    public IEnumerator isAlarmlight()
    {
        if (game.GetBool("airLow") && isAlarmOn == false)
        {
            isAlarmOn = true;
            Alarmlight.GetComponent<Light>().gameObject.SetActive(game.GetBool("airLow"));
            Alarmlight.GetComponent<AudioSource>().Play();
        }
        else if ( isAlarmOn == true && !game.GetBool("airLow"))
        {
            isAlarmOn = false;
            Alarmlight.GetComponent<Light>().gameObject.SetActive(game.GetBool("airLow"));
            Alarmlight.GetComponent<AudioSource>().Stop();
        }

        yield return null;
    }

    public void reduce_health(int reduce_by)
    {
        health -= reduce_by;
        if (health <= 0.0)
        {
            destroySubmarine();
        }
    }


    public void halfdamage()
    {
        health = health - (health_max / 2);
        if (health <= 0.0)
        {
            destroySubmarine();
        }
    }
  
    public void destroySubmarine()
    {
        health = 0;
        ani_help.restart();
        game.StopPlayback();
        restartSubmarine();
    }

    public void restartSubmarine()
    {
        refillOxygen();
        health = health_max;
    }

    public void setLightInside(float intensity)
    {
        Light.intensity = intensity;

    }

}