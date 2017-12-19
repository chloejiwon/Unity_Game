using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public int[] Members;
	public int MemberNumber;

	public int score;


	//images
	public Sprite []npcImages;
	public bool hasFriend;

	//When Rejected
	public GameObject Rejected;
	public GameObject Selected;

	// Use this for initialization
	void Start () {
		string name;
		GameObject friend;

		hasFriend = false;
		NPC = FindObjectOfType<cnr> ();
		score = 0;
		timer = 0.0f;
		left_offset = new Vector3 (-0.6f, 0, 0);
		right_offset = new Vector3 (0.6f, 0, 0);
		MemberNumber = 0;
		Members = new int[3];

		if (Members [0] == 0) {
			// no friends
			for(int i=1;i<4;i++) {

				name = "friend" + i;
				friend = GameObject.Find (name);
				friend.SetActive (false);

			}
		}

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

			/*if (Rejected.activeSelf) {
				// rejected 가 true면
				Rejected.SetActive(false);
			}
			if (Selected.activeSelf) {
				Selected.SetActive (false);
			}*/
			if (!IsTired) {

				if (Members [0] != 0) {
					hasFriend = true;
					FriendManager ();
				}

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

					if (rotateSpeed <= 500) {
						//forwardSpeed = forwardSpeed * Time.deltaTime;
						//transform.Translate (Vector3.forward);
						// Something wrong with Time.deltaTime when it is called again
						// First Try works fine.
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
						//forwardSpeed = 0;
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
			rotateSpeed = 45f;

			transform.Rotate (Vector3.back * 1.0f);
		}
	}

	void FriendManager(){
		// upload member's images to the canvas
		int cnt = 1;
		string name;
		GameObject friend;
		if (hasFriend) {
			// First to show images
			foreach (int i in Members) {
				if (i != 0) {
					name = "friend" + cnt;
					friend = GameObject.Find ("Friends");
					friend.transform.Find(name).gameObject.SetActive (true);
					cnt++;
				}
			}
			hasFriend = false;
		}
		if (MemberNumber != 0) {
			cnt = 1;
			foreach (int i in Members) {
				if(i!=0){
					// i가 0이라는 것은 아직 아무 친구도 없는 상태를 의미한다
					name = "friend" + cnt;
					friend = GameObject.Find (name);
					friend.GetComponent<Image> ().sprite = npcImages [i-1];
					cnt++;
				}
			}

		}
	}

}