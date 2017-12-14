using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAnswer : MonoBehaviour {

    private int num;

	public Color mouseOverColor;

	bool mouseOver = false;
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
		Debug.Log(gameObject.name);
       
    }

/*	void OnMouseOver(){
		//If your mouse hovers over the GameObject with the script attached, output this message
		GetComponent<Renderer>().material.SetColor("_Color",Color.blue);

	}
	void onMouseExit(){
		GetComponent<Renderer>().material.SetColor("_Color",Color.clear);
	}*/
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate(){
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothedPos = Vector3.Lerp (transform.position, desiredPos,smoothSpeed);
		transform.position = smoothedPos;
	}
}
