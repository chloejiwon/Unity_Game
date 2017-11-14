using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

	public float rotateSpeed = 45f;

	// 너무 오래 스페이스바 눌렀을 경우에, Player 지침!
	bool IsTired;
	float Timer;
	float waitTime=2f;

	public bool canMove=true;
	public cnr NPC;

	// Use this for initialization
	void Start () {
		NPC = FindObjectOfType<cnr> ();
		IsTired = false;
		Timer = 0f;
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
		if(!IsTired){
				if (Input.GetKey (KeyCode.Space)) {
				/*	if (NPC.name == "Axis")
						NPC.SpeedUp ();
		*/
					transform.Translate(Vector3.forward * Time.deltaTime);
					rotateSpeed += 50* Time.deltaTime;
					if (rotateSpeed >= 300) {
						// Stop Spinning !!
						// Character tired
						IsTired = true;
						rotateSpeed = 1;

					}
				}
		}else{
			//지쳤을 경우
				if(Timer >= waitTime){
					//2초 지났을 경우에
					IsTired = true;
				}
		}
		transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);

	}


}
