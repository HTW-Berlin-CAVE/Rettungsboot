using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	public GameObject orientationSource;

	// Use this for initialization
	void Start () {
		Rotate();
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
	}

	private void Rotate() 
	{
		Vector3 rotationFromMaster = orientationSource.transform.localRotation.eulerAngles;

		Vector3 rotationFromSlave = this.transform.localEulerAngles;
		rotationFromSlave[2] = rotationFromMaster[1];
		//this.transform.localRotation.z = rotationYFromMaster;
		this.transform.localEulerAngles = rotationFromSlave;
	}
}
