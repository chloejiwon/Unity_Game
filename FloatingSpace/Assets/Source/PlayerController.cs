using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

	public float rotateSpeed = 45f;
	public float forwardSpeed = 0f;

	// Too many speed.. character needs to take a rest a little while!!!
	bool IsTired;
	float timer;
	float fps;
	float waitingTime = 5;

	public bool canMove=true;
	public cnr NPC;

    public string[] Members;

    public int score;

	// Use this for initialization
	void Start () {
		NPC = FindObjectOfType<cnr> ();
        score = 0;
		timer = 0.0f;
	}

	void OnTriggerEnter(Collider col){
		IsTired = false;

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

		if (!IsTired){
			if (Input.GetKey (KeyCode.Space)) {

				if (rotateSpeed <= 300) {
					transform.Translate (Vector3.forward * Time.deltaTime);
				}

				//		if (NPC.name == "Axis")
				//			NPC.SpeedUp ();
			
				rotateSpeed += 50 * Time.deltaTime;
				//		forwardSpeed += (0.1f) * Time.deltaTime;
				if (rotateSpeed >= 300) {
					// Stop Spinning !! 
					// Character tired
					rotateSpeed = 1; 
					forwardSpeed = 0;
					IsTired = true;

				}
			}
				
		} else {
			// If Tired..
			timer+= Time.deltaTime;
			print ("TIRED");
			if (timer > waitingTime) {
				timer = 0;
				IsTired = false;
			}
		}
		transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);

	}
    

}
