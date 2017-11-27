using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1 : MonoBehaviour {

	public float rotateSpeed = 1;
	public static int Score;

	// Use this for initialsization
	void Start () {
		Score = 0;
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
	public void CalculateScore(int num)
	{
		Score += num;

		//Debug
		Debug.Log(Score);
	}
	public bool judge()
	{
		bool result = false;
		if(Score > 100)
		{
			result = true;
			//호감이라는뜻
		}
		else
		{
			//불합격^^
		}
		return result;
	}

}
