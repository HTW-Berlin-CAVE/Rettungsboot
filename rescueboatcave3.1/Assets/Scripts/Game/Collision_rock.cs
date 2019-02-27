using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_rock : MonoBehaviour {

    [SerializeField]
    private submarineStat stats;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip scrap; 

    // Use this for initialization
    void Start () {

    }

    private void OnCollisionEnter(Collision collision)
    { 
        audioSource.clip = scrap;
        audioSource.Play();
        stats.halfdamage();
    }
}
