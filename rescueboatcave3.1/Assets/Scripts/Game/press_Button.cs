using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class press_Button : MonoBehaviour {
    
    public Animator game;
    public submarineStat stat;
    public bool isPressed;
	// Use this for initialization
	void Start () {
        game = gameObject.GetComponentInParent<Animator>();
        stat = gameObject.GetComponentInParent<submarineStat>();
    }

    void OnCollisionEnter()
    {
       if (isPressed)
        {
            
            game.SetBool("isButtonpressed", false);
            isPressed = false;
        }
       else if (!isPressed)
        {
            game.SetBool("isButtonpressed", true);
            isPressed = true;
        }


    }


}
