using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Second_Dialogue : MonoBehaviour {


	public bool start;
	private Text _textComponent;
	private Text _textComponent2;


	public GameObject textBox;
	public GameObject NameBox;
	public GameObject BG;
	public GameObject ChoicePopupBG;
	public static bool TeamChoice;


	public string[] DialogueStrings;

	public float SecondsBetweenCharacters = 0.15f;
	public float CharacterRateMultiplier = 0.5f;

	public KeyCode DialogueInput = KeyCode.Return;

	private bool _isStringBeingRevealed = false;
	private bool _isDialoguePlaying = false;
	private bool _isEndOfDialogue = false;

	public bool finish;

	public GameObject ContinueIcon;
	public GameObject StopIcon;

	//text File로 대화를 해보자
	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLines;


	private string NPCname;
	private bool isAnswer;
	public static  bool Pressed;

	public npc1 NPC;


//	public GameObject Duck;
//	public GameObject Player;

	public static int selectedAnswer;
	public GameObject First;
	public GameObject Second;

	//Score
	int score1,score2;

	// Use this for initialization
	void Start()
	{
		finish = false;
		_textComponent = GetComponent<Text>();
		_textComponent.text = "";
		start = false;

		NPC = FindObjectOfType<npc1>();

		textBox.SetActive(false);
		NameBox.SetActive(false);
		ChoicePopupBG.SetActive(false);
//		Player.SetActive(false);
		BG.SetActive (false);
		First.SetActive(false);
		Second.SetActive(false);
		_textComponent2 = NameBox.GetComponent<Text>();
		_textComponent2.text = "";
		HideIcons();

		if (textFile != null)
			textLines = (textFile.text.Split('\n'));

		if (endAtLines == 0)
			endAtLines = textLines.Length - 1;
	}

	// Update is called once per frame
	void Update()
	{
		if (start || _isDialoguePlaying)
		{

			BG.SetActive(true);
			First.SetActive(true);
			Second.SetActive(true);
			if (Input.GetKeyDown(KeyCode.Return))
			{
				textBox.SetActive(true);
				NameBox.SetActive(true);
				if (!_isDialoguePlaying)
				{
					_isDialoguePlaying = true;
					StartCoroutine(StartDialogue());
				}

			}
		}else
		{
			textBox.SetActive(false);
			NameBox.SetActive (false);
			//Write More..
			if (_isEndOfDialogue) {
				Debug.Log ("End Of Dialogue");
				_isEndOfDialogue = false;

				finish = true;
				end ();
			}
		}
	}

	private IEnumerator StartDialogue()
	{
		int dialogueLength = DialogueStrings.Length;
		int currentDialogueIndex = 0;

		NPCname = DialogueStrings[0];

		while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
		{
			if (!_isStringBeingRevealed)
			{
				_textComponent2.text = "";
				_isStringBeingRevealed = true;
				//StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

				//print(currentDialogueIndex);
				if (currentDialogueIndex <=3)
				{
					// 본인 특징, 다 NPC가 말하는 거
					isAnswer = false;
					Pressed = true;

					StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));
					_textComponent2.text += NPCname;


				}
				else if(currentDialogueIndex %5 == 4)
				{
					//NPC 질문
					isAnswer = false;
					Pressed = true;
					StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));
					_textComponent2.text += NPCname;

				}
				else
				{
					// Player 대답 선택해야 하는 부분

					Pressed = false;

					isAnswer = true;

					string temp;
					temp = DialogueStrings[currentDialogueIndex] + "\n" + DialogueStrings[currentDialogueIndex + 2];

					StartCoroutine(DisplayString(temp));
					_textComponent2.text += "Player";

					// Calculating Score
					score1 = Int32.Parse(DialogueStrings[currentDialogueIndex+1]);
					score2 = Int32.Parse (DialogueStrings [currentDialogueIndex + 3]);

					currentDialogueIndex += 4;

				}
				if (currentDialogueIndex >= dialogueLength)
				{
					_isEndOfDialogue = true;
					start = false;
					end ();
					Debug.Log ("Dialogue Ends!!!");
				}
			}

			yield return 0;
		}

		while (true)
		{
			if (Input.GetKeyDown(DialogueInput))
			{
				break;
			}

			yield return 0;
		}

		HideIcons();
		_isEndOfDialogue = false;
		_isDialoguePlaying = false;
	}

	private IEnumerator DisplayString(string stringToDisplay)
	{
		int stringLength = stringToDisplay.Length;
		int currentCharacterIndex = 0;

		HideIcons();

		_textComponent.text = "";

		while (currentCharacterIndex < stringLength)
		{
			_textComponent.text += stringToDisplay[currentCharacterIndex];
			currentCharacterIndex++;

			if (currentCharacterIndex < stringLength)
			{
				if (Input.GetKey(DialogueInput))
				{
					yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
				}
			}
			else
			{
				break;
			}
		}

		ShowIcon();

	/*	if (isAnswer) {

			if (Pressed) {
				Debug.Log ("Pressed is True");
				Debug.Log (selectedAnswer);
				if (selectedAnswer == 1) {
					//1 
					print("1111");
					NPC.CalculateScore (score1);

				} else {
					print ("2222");
					NPC.CalculateScore (score2);
				}
				Pressed = false;
			}

		}*/

		while (true)
		{
			if (isAnswer) {

				if (Pressed) {
					Debug.Log (selectedAnswer);
					if (selectedAnswer == 1) {
						//1 
						print("1111");
						NPC.CalculateScore(score1);
					} else {
						print ("2222");
						NPC.CalculateScore(score2);
					}
					Pressed = false;
					break;
				}

			}
			
			if (Input.GetKeyDown(DialogueInput) && Pressed==true  )
			{
				Pressed = false;
				break;
			}

			yield return 0;
		}

		HideIcons();

		_isStringBeingRevealed = false;
		_textComponent.text = "";
	}

	private void HideIcons()
	{
		ContinueIcon.SetActive(false);
		StopIcon.SetActive(false);

	}

	private void ShowIcon()
	{
		if (_isEndOfDialogue)
		{
			start = false;
			StopIcon.SetActive(true);
			//이제 다일로그 사라지고 선택창이 튀어나와야함!!

			finish = true;
			return;
		}

		ContinueIcon.SetActive(true);
	}
	public void _start()
	{
		start = true;
	}
	public void ReloadScript(TextAsset theText)
	{
		// load back-up scripts
		// to use different text files
		if (theText != null)
		{
			DialogueStrings = new string[1];
			DialogueStrings = (theText.text.Split('\n'));
			print("Reload!!");
			print(DialogueStrings.Length);
		}
	}
	public void end()
	{
		print("END!");
		print(NPCname);

//		textBox.SetActive(false);
//		NameBox.SetActive(false);

//		Duck.SetActive(false);

		//이제 선택할 수 있는 것을 띄워야합니당..!

		print("Dialouge end내부에서 SElect Team부름");

		ChoicePopupBG.SetActive(true);
		//SelectTeam._start();

//		Player.SetActive(false);
		BG.SetActive(false);
	}
	public void Finish()
	{
		ChoicePopupBG.SetActive(false);
		gameObject.SetActive(false);
	}

}
