using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnr : MonoBehaviour {

	public float rotateSpeed = 0.1f;
	private bool Talking;

	// Use this for initialization
	void Start () {
		Talking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Talking)
			transform.Rotate (Vector3.up * rotateSpeed);
		else
			return;
	}

	public void SpeedUp(){
		rotateSpeed += 0.001f;
	}

	public void Stop(){
		Talking = true;

	}
	public void StartAgain(){
		Talking = false;
	}
}
