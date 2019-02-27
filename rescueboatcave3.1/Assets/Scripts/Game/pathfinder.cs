using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfinder : MonoBehaviour
{

    public GameObject submarine;
    public GameObject before_seamines;
    public GameObject behind_seamines;
    public GameObject oxygen;
    public GameObject send_amplifier;
    public Animator game;
    public getOxygen getO2;

   public float distance_before;
    public float distance_behind ;
    public float distance_oxygen ;
    public float distance_send;

    public GameObject[] waypoints;



    // Use this for initialization
    void Start()
    {
       // game = GetComponent<Animator>();
       // getO2 = GetComponent<getOxygen>();
    }

    // Update is called once per frame
    void Update()
    {

        //distance to the submarine
        distance_before = (submarine.transform.position - before_seamines.transform.position).magnitude;
        distance_behind = (submarine.transform.position - behind_seamines.transform.position).magnitude;
        distance_oxygen = (submarine.transform.position - oxygen.transform.position).magnitude;
        distance_send = (submarine.transform.position - send_amplifier.transform.position).magnitude;

        // when submarine is behind the seamines 
        if (distance_behind < 250)
        {
            game.SetBool("isbehindseamines", true);
        }
        else
        {
            game.SetBool("isbehindseamines", false);
        }


        // when its near the oxygen 
        if (distance_oxygen < 400)
        {
            game.SetBool("isnearOxygen", true);
            if (distance_oxygen < 50)
            {
                game.SetBool("isoverOxygen", true);
                getOxygen();
            }
            else
            {
                game.SetBool("isoverOxygen", false);
            }
        }
        else
        {
            game.SetBool("isnearOxygen", false);
        }

        // when its near the send amplifier
        if (distance_send < 400)
        {
            if (!game.GetBool("isnearSend"))
            {
                game.SetTrigger("isnearSendTrigger");
            }
            game.SetBool("isnearSend", true);
            if (distance_send < 100)
            {
                game.SetBool("isoverSend", true);
            }
            else
            {
                game.SetBool("isoverSend", false);
            }
        }
        else
        {
            game.SetBool("isnearSend", false);

        }


    }

    void getOxygen()
    {
        getO2.refillOxygen();
    }
}
