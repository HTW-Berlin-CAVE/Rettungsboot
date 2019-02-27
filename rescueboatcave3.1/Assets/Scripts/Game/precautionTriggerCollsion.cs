using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class precautionTriggerCollsion : MonoBehaviour {

    public submarineStat stats;

    // Use this for initialization
    void Start () {
        stats = GetComponentInParent<submarineStat>();
    }

 
    private void OnCollisionEnter(Collision collision)
    {
        stats.precautionCollisionDetection(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        stats.precautionCollisionDetection(false);
    }

}
