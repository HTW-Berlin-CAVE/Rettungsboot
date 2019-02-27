using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

	public GameObject fishPrefab;

	public int tankSize = 5;
	public int numFish = 10;
	public static int TANKSIZE;


	public static GameObject[] allFish ;
	public GameObject goalObj;
	public static Vector3 goalPos;
	public static Vector3 position;

	// Use this for initialization
	void Start () {
		allFish = new GameObject[numFish];

		position = transform.position;
		goalPos = transform.position;
		goalObj.transform.position = goalPos;

		for (int i = 0; i < numFish; i++)
		{
			Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
				Random.Range(-tankSize, tankSize),
				Random.Range(-tankSize, tankSize));
			pos += transform.position;
			allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].transform.parent = goalObj.transform.parent;
            TANKSIZE = this.tankSize;

		}
	}

	// Update is called once per frame
	void Update () {
		if (Random.Range(0, 10000) < tankSize*10)
		{
			goalPos= new Vector3(Random.Range(-tankSize*0.6f, tankSize * 0.6f),
				Random.Range(-tankSize * 0.6f, tankSize * 0.6f),
				Random.Range(-tankSize * 0.6f, tankSize * 0.6f));
			goalPos += transform.position;
			goalObj.transform.position = goalPos;
		}
	}
}
