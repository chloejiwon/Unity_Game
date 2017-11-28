using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextBoxManager TextBox;

	public bool requireButtonPress;
	private bool waitForPress;

	public bool destroyWhenActivated;

	public Second_Dialogue Talk;


	// Use this for initialization
	void Start () {
		TextBox = FindObjectOfType<TextBoxManager> ();
		Talk = FindObjectOfType<Second_Dialogue>();


		destroyWhenActivated =false;
	}

	// Update is called once per frame
	void Update () {

		if (waitForPress && Input.GetKeyDown (KeyCode.J)) {

			Talk.ReloadScript(theText);
		}
/*		if (destroyWhenActivated) {
			Debug.Log ("Destroy where?");
			Destroy (gameObject);
		
		}if (Talk.finish) {
			Debug.Log ("Talk Finish Destroy");
			Destroy (gameObject);
		}*/
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {

			if (requireButtonPress) {
				waitForPress = true;
				return;
			}
			print("Collide?");

			Talk.CharName = gameObject.name;
			Debug.Log (Talk.CharName);



			Talk.ReloadScript(theText);
			Talk.currentLine = startLine;
			Talk.endAtLines = endLine;
			Talk._start();

			if (destroyWhenActivated) {
				Destroy (gameObject,2f);
			}
		}
	}

	void onTriggerExit(Collider other){
		if (other.name == "Player") {
			waitForPress = false;
		}
	}

	public void Disappear()
	{
		destroyWhenActivated = true;

	}

}
