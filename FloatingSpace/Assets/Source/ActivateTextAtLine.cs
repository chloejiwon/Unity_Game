using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {


	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextBoxManager TextBox;
	public cnr Axis;

	public bool requireButtonPress;
	private bool waitForPress;

	public bool destroyWhenActivated;

    public Dialogue Talk;

	// Use this for initialization
	void Start () {
		TextBox = FindObjectOfType<TextBoxManager> ();
		Axis = FindObjectOfType<cnr> ();
        Talk = FindObjectOfType<Dialogue>();


		destroyWhenActivated =false;
	}

	// Update is called once per frame
	void Update () {

		if (waitForPress && Input.GetKeyDown (KeyCode.J)) {

            Talk.ReloadScript(theText);
	/*		TextBox.ReloadScript (theText);
			TextBox.currentLine = startLine;
			TextBox.endAtLines = endLine;
			TextBox.EnableTextBox ();
			print (gameObject);
			TextBox.call (gameObject.name);
            */

			Axis.Stop ();
		}
        if (destroyWhenActivated)
            Destroy(gameObject);
        if (Talk.finish)
            Destroy(gameObject);
    }

	void OnTriggerEnter(Collider other){
		if (other.name == "Player") {

			if (requireButtonPress) {
				waitForPress = true;
				return;
			}
            print("Collide?");
            Talk.ReloadScript(theText);
            Talk.currentLine = startLine;
            Talk.endAtLines = endLine;
            Talk._start();
            Axis.Stop();

            //TextBox.call (this.name);
            /*		Axis.Stop ();
                    TextBox.ReloadScript (theText);
                    TextBox.currentLine = startLine;
                    TextBox.endAtLines = endLine;
                    TextBox.EnableTextBox ();
                    */

			if (destroyWhenActivated) {
				Destroy (gameObject,2f);
			}
		}
	}

	void onTriggerExit(Collider other){
		if (other.name == "Player") {
			waitForPress = false;
			Axis.StartAgain ();
		}
	}

    public void Disappear()
    {
        destroyWhenActivated = true;

    }
}
