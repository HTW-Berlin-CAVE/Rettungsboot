using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
 
    public AudioClip StartingSound;
    public AudioClip RunningSound;
    public AudioClip StoppingSound;

    public CustomControls playerMovement;
    Vector3 acceleration;

    public AudioSource Source;
    float Pitch;
    bool isidle;

    // Use this for initialization
    void Start()
    {
        Source = gameObject.AddComponent<AudioSource>();
        Source.clip = StartingSound;
        isidle = true;
        Source.volume = 0.4f;

    }

    // Update is called once per frame
    void Update()
    {
        Pitch = 0.9f * Pitch + 0.10f * (playerMovement.returnMagnitude() * 100f) ;
        
        Source.pitch = Pitch * 0.002f + 1f;
        if (Source.isPlaying == false && !isidle)
        {
            Source.clip = RunningSound;
            Source.loop = true;
            Source.Play();
        }

    }

    public void silent()
    {
        isidle = true;
        Source.Stop();
    }


    public void starting_engine()
    {
        Source.Play();
        Pitch = 1;
        isidle = false;
 
    }


    public void stop_enginge()
    {
        Source.clip = StoppingSound;
        Source.Play();
        Source.loop = false;
    }
}
