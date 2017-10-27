using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

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
    void Start()
    {
        Talk = FindObjectOfType<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {

        if (waitForPress && Input.GetKeyDown(KeyCode.J))
        {
            Axis.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {

            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            print("Collide?");
            Talk._start();
            Axis.Stop();

            //TextBox.call (this.name);
            /*		Axis.Stop ();
                    TextBox.ReloadScript (theText);
                    TextBox.currentLine = startLine;
                    TextBox.endAtLines = endLine;
                    TextBox.EnableTextBox ();
                    */

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            waitForPress = false;
            Axis.StartAgain();
        }
    }

    public void Disappear()
    {
        destroyWhenActivated = true;

    }
}
