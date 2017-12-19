using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {

	float timer;
	float waitingTime = 1.5f;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {
			//true면 몇 초 있다가 다시 deactivate하게 
			timer+=Time.deltaTime;
			if (timer > waitingTime) {
				timer = 0;
				gameObject.SetActive (false);
			}

		}
	}
}
