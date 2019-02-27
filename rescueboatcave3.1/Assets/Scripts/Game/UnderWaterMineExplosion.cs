using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterMineExplosion : MonoBehaviour {

    bool touchedMine;

	public GameObject explosionEffect;
	private GameObject submarine;
    private submarineStat stat;
    AudioSource audioSource;
    public AudioClip explosionSound;
    //for testing
	private float explosionTime = 3f;

    GameObject fx;
    // Use this for initialization
    void Start () {
        
        //declare submarine here
        submarine = GameObject.Find("[CavePlayer]");
        audioSource = gameObject.AddComponent<AudioSource>();
        stat = GameObject.FindObjectOfType<submarineStat>();
        touchedMine = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (!touchedMine)
        {
            StartCoroutine(Explosion());
            touchedMine = true;
        }
       
       
    }


    IEnumerator Explosion(){
        audioSource.clip = explosionSound;
        audioSource.volume = 0.5f;
        audioSource.Play();
        fx = Instantiate(explosionEffect, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        fx.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(fx);
        Destroy(gameObject);
        stat.destroySubmarine();
	}
}
