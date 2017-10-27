using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

	public float rotateSpeed = 45f;

	public bool canMove=true;
	public cnr NPC;

	// Use this for initialization
	void Start () {
		NPC = FindObjectOfType<cnr> ();

	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "character") {
			// conversation should be starting
			//print(col.gameObject.name);
		
		}
	}
	// Update is called once per frame
	void Update () {

		if (!canMove) {
			return;
		}
		if (Input.GetKey (KeyCode.Space)) {

			if (NPC.name == "Axis")
				NPC.SpeedUp ();
			
			rotateSpeed += 50* Time.deltaTime;
			if (rotateSpeed >= 300) {
				// Stop Spinning !! 
				// Character tired
				rotateSpeed = 1; 

			}
		}

		transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);

	}


}
