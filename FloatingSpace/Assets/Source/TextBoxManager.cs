using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;


	public TextAsset textFile;
	public string[] textLines;


	public int currentLine;
	public int endAtLines;

	public PlayerController player;

	public bool isActive=false;

	public bool stopPlayerMovement = true;

	public Character1 NPC;

	public string Caller;
    public bool isFinished;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController> ();

        isFinished = false;

		if (textFile != null) 
			textLines = (textFile.text.Split ('\n'));

		if (endAtLines == 0)
			endAtLines = textLines.Length - 1;

        
		if (isActive)
			EnableTextBox ();
		else if(isFinished)
			DisableTextBox ();
	}

	void Update(){

        if (currentLine > endAtLines)
        {
            //아..!!! 이거때문이어쒀!!!ㅠㅠㅠ

            currentLine = 0;
            isFinished = true;
            DisableTextBox();
        }
		if (!isActive)
			return;
		
		theText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Space)) {
			currentLine++;
		}


	}

	public void EnableTextBox(){
		textBox.SetActive (true);
		isActive = true;
		if (stopPlayerMovement)
			player.canMove = false;
		
	}

	public void DisableTextBox(){
     //   print("뭐지");
		textBox.SetActive (false);
		isActive = false;
		player.canMove = true;
        if (isFinished)
        {
            NPC = FindObjectOfType<Character1>();
            NPC.BroadcastMessage("Disappear");
            isFinished = false;
        }
        if (!isFinished)
            return;
     

	}

	public void call(string name){
		Caller = name;
		print (Caller);

	}

	public void ReloadScript(TextAsset theText){
		// load back-up scripts 
		// to use different text files 
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));
			isActive = true;
		}


		
	}
}
