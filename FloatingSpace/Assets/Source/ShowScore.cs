using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {


	public Text myText;
	public bool init;

	// Use this for initialization
	void Start () {
		init = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (init) {
			myText.GetComponent<Text>().text="0";
			init = false;
		}
	}

	public void ChangeScore(int score){
		myText.GetComponent<Text>().text= score.ToString();
	}
}
