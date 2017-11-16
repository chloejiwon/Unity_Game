using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1 : MonoBehaviour {

	public float rotateSpeed = 1;

	// Use this for initialsization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back * rotateSpeed);

	}

	void OnTriggerEnter(Collider other){
		// npc 가 player와 충돌 했을 때 
		// 대화 시작
		print("collision Enter");

		if (other.gameObject.tag.Equals ("Player")) {
			// Player?
			// Dialogue begins
			// STOP JUST FOR NOW

			print("Collide");

			other.gameObject.GetComponent<PlayerController> ().canMove = false;

		}

	
	}

}
