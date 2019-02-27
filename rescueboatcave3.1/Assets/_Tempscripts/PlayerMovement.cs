using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool steer;

    public void ResetLocation()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.transform.SetPositionAndRotation(new Vector3(2164, 240, 479), new Quaternion(0, 0, 0, 1));
        steer = false;
    }


}
