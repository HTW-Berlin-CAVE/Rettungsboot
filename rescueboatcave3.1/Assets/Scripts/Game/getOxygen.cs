using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getOxygen : MonoBehaviour {

    AudioClip impact;
    AudioSource audioSource;
    public submarineStat stat;
    public GameObject O2Container;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        stat = GetComponent<submarineStat>();
    }
	
	

     public void refillOxygen()
    {
        //playClamp();
        StartCoroutine(Oxygenfull());
    }
    IEnumerator Oxygenfull()
    {
        yield return new WaitForSeconds(5);
      //  Destroy(O2Container);
        stat.refillOxygen();
    }

 /*   void playClamp() {
        audioSource.volume = 0.4f;
    audioSource.PlayOneShot(impact, 0.7F);
}*/
}


