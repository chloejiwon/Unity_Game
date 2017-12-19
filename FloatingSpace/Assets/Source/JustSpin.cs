using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustSpin : MonoBehaviour {

	float rotateSpeed = 45f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);
	}
}
