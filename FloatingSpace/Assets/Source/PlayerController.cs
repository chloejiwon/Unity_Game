using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

	public float rotateSpeed = 45f;
	public float forwardSpeed = 0f;
	public float smoothSpeed = 0.125f;
	public Vector3 left_offset;
	public Vector3 right_offset;


	// Too many speed.. character needs to take a rest a little while!!!
	bool IsTired;
	float timer;
	float fps;
	float waitingTime = 1;

	// if Dialogue starts.. player should STOP!!!
	public bool canMove=true;
	public cnr NPC;

    public string[] Members;

    public int score;

	// Use this for initialization
	void Start () {
		NPC = FindObjectOfType<cnr> ();
        score = 0;
		timer = 0.0f;
		left_offset = new Vector3 (-0.6f, 0, 0);
		right_offset = new Vector3 (0.6f, 0, 0);
		//DontDestroyOnLoad (transform.gameObject);
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
		
		if (canMove) {

			if (!IsTired) {

				if (Input.GetKey (KeyCode.LeftArrow) == true) {
					Vector3 desiredPos = transform.position + left_offset;
					Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos,smoothSpeed);
					transform.position = smoothedPos;
				}
				if (Input.GetKey (KeyCode.RightArrow) == true) {
					Vector3 desiredPos = transform.position + right_offset;
					Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos,smoothSpeed);
					transform.position = smoothedPos;
				}

				if (Input.GetKey (KeyCode.Space)) {

					if (rotateSpeed <= 300) {
						transform.Translate (Vector3.forward * forwardSpeed * Time.deltaTime);
					}

					//		if (NPC.name == "Axis")
					//			NPC.SpeedUp ();
			
					rotateSpeed += 50 * Time.deltaTime;
					//		forwardSpeed += (0.1f) * Time.deltaTime;
					if (rotateSpeed >= 500) {
						// Stop Spinning !! 
						// Character tired
						rotateSpeed = 1; 
						forwardSpeed = 0;
						IsTired = true;

					}
				}
				
			} else {
				// If Tired..
				timer += Time.deltaTime;
				print ("TIRED");
				if (timer > waitingTime) {
					timer = 0;
					IsTired = false;
				}
			}

			transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);
		} else {
			transform.Rotate (Vector3.back * 1.0f);
		}
	}
    

}
