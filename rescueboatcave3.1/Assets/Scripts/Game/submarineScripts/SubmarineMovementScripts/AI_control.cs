using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_control : MonoBehaviour {

    public Vector3 controls;
    public Animator game;

    // Use this for initialization
    void Start () {
        controls = Vector3.zero;
        game = gameObject.GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (game.GetBool("startDrivingAI"))
        {
            Debug.Log("AI driving");
            controls = new Vector3(1, 0, 0.2f);
            
        }
        else
            controls = Vector3.zero;
	}
}
