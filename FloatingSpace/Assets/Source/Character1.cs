using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour {

	public float rotateSpeed = 1;
	public float self_rotateSpeed = 1;
	public bool canMove=true;
	public bool Die = false;

	// Use this for initialsization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!canMove)
			return;
		if (Die)
			Destroy (gameObject,3f);
	//	transform.Rotate (Vector3.back * self_rotateSpeed);
		transform.Rotate (Vector3.up * rotateSpeed);
		
	}

	public void EndOfConversation(){
		Die = true;
	}
}
