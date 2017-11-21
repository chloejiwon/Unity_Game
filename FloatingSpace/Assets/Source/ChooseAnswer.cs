using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAnswer : MonoBehaviour {

    private int num;
	// Use this for initialization
	void Start () {
        if (gameObject.name == "FirstAnswer")
            num = 1;
        else
            num = 2;
	}
	
	// Update is called once per frame
	void Update () {
  //      print("!!!!!!!!!!!!!!!ONMOUSEDOWN");
    }

    void OnMouseDown()
    {
        if (!Second_Dialogue.Pressed )
        {
            Debug.Log(gameObject.name);
           
			Second_Dialogue.selectedAnswer = num;
			Second_Dialogue.Pressed = true;
        }
       
    }
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate(){
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos,smoothSpeed);
		transform.position = smoothedPos;
	}
}
