using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour {

    public bool start;
    private Text _textComponent;

    public GameObject textBox;

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

    // Use this for initialization
    void Start()
    {
        finish = false;
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
        start = false;

        textBox.SetActive(false);
        HideIcons();

        if (textFile != null)
            textLines = (textFile.text.Split('\n'));

        if (endAtLines == 0)
            endAtLines = textLines.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
         //   print("다이알로그들어옴");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                textBox.SetActive(true);
                if (!_isDialoguePlaying)
                {
                  //  textBox.SetActive(false);

                    _isDialoguePlaying = true;
                    StartCoroutine(StartDialogue());
                }

            }
        }else
        {
            textBox.SetActive(false);
        }
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

                print(currentDialogueIndex);

                if (currentDialogueIndex >= dialogueLength)
                {
                //    print("왜인식못해");
                    _isEndOfDialogue = true;
                    //finish = true;
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
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }

        ShowIcon();

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
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

    }
