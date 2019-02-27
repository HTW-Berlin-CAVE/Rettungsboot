using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

	float speed = 0.1f;
	public float rotationSpeed = 4.0f;
	Vector3 avgHeading;
	Vector3 avgPosition;
	public float neighbourDistance = 4.0f;
	public float speed_min = 0, speed_max = 0;
	public float size_min = 1, size_max =1 ;

	bool turning = false;

	// Use this for initialization
	void Start () {
		float randomScale = Random.Range(size_min, size_max);
		speed = Random.Range(speed_min, speed_max);
		transform.localScale= new Vector3(randomScale, randomScale, randomScale);

	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, GlobalFlock.position) >= GlobalFlock.TANKSIZE)
			turning = true;
		else
			turning = false;
		if (turning)
		{
			Vector3 direction = GlobalFlock.position - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
			speed= Random.Range(speed_min, speed_max);
		}
		else if (Random.Range(0, 5) < 1)
		{
			ApplyRules();
		}
		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void ApplyRules()
	{
		GameObject[] gos = GlobalFlock.allFish;

		Vector3 vcentre = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = GlobalFlock.goalPos;

		float dist;

		int groupsSize = 0;
		foreach (GameObject go in gos)
		{
			if(go != this.gameObject)
			{
				dist = Vector3.Distance(go.transform.position, this.transform.position);
				if (dist <= neighbourDistance)
				{
					vcentre += go.transform.position;
					groupsSize++;
					if (dist < 1.0f)
					{
						vavoid += (this.transform.position - go.transform.position);
					}
					Flock anotherFlock = go.GetComponent<Flock>();
					gSpeed += anotherFlock.speed;
				}
			}
		}
		if (groupsSize > 0)
		{
			vcentre = vcentre / groupsSize + (goalPos - transform.position);
			speed = gSpeed / groupsSize;

			Vector3 direction = (vcentre + vavoid) - transform.position;
			if (direction != GlobalFlock.position)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
			}
		}
	}
}
