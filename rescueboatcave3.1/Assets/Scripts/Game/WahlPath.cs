using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WahlPath : MonoBehaviour {

    public Transform[] target;
    public float speed;
    private int current;
    float rotationSpeed = 0.7f;
    public bool turning = false;

    // Use this for initialization
    void Start () {
		
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        current = (current + 1) % target.Length;
        Quaternion rotation = Quaternion.LookRotation(-target[current].position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);

        turning = true;


    }
   
    // Update is called once per frame
    void Update () {

        Vector3 direction = target[current].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(-direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if (turning || transform.position == target[current].position)
        {
            print("turning");
            current = (current + 1) % target.Length;
           
            turning = false;
        }
        else
        {
            //print("not turning");
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);


            GetComponent<Rigidbody>().MovePosition(pos);

            turning = false;
        }
		
	}
}
