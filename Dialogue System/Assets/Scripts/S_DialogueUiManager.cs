using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_DialogueUiManager : MonoBehaviour
{
    public static S_DialogueUiManager singleton;
    //References (Editor)
    [SerializeField]
    private Text UIText;
    [SerializeField]
    private Image spriteLeft;
    [SerializeField]
    private Image spriteRight;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Color colorInactiveCharacter;
    [SerializeField]
    private string otherSpriteCommand = "OTHERSPRITE";

    //References (Start)
    private GameObject dialogueCanvas;
    private AudioSource myAudioSource;
    private S_DialogueManager myManager;

    //References (Dinamic)
    private S_Dialogue currentDialogue;
    private string currentDialogueText;
    private Coroutine secuentialText;

    //Properties
    private bool otherCharacterInvisible;

    //Unity Functions
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            dialogueCanvas = transform.GetChild(0).gameObject;
            continueButton.onClick.AddListener( ()=>OnContinue());
            myAudioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        myManager = S_DialogueManager.singleton;
        otherCharacterInvisible = myManager.getOtherSpriteVisible();
    }
    // Principal Functions
    public void StartDialogue(string id)
    {
        currentDialogue = myManager.getDialogue(id);
        if (currentDialogue != null)
        {
            dialogueCanvas.SetActive(true);
            ComprobateOtherCharacter();
            OnContinue();
        }
    }

    public void OnContinue()
    {
        if (secuentialText != null)
        {
            StopCoroutine(secuentialText);
            secuentialText = null;
            UIText.text = currentDialogueText;
        }
        else
        {
            if (currentDialogue != null)//Cambiar pa que si la corrutina est�, salga todo el texto y ya est�
            {
                S_DialogueText currentText = currentDialogue.NextDialogue();
                if (currentText != null)
                {
                    currentDialogueText = currentText.getDialogueText();
                    if (currentText.getIsRightCharacter())
                    {
                        ChangeRightSprite(myManager.getCharacterEmotionSprite(currentText.getEmotion(), currentText.getCharacterName()));

                    }
                    else
                    {

                        ChangeLeftSprite(myManager.getCharacterEmotionSprite(currentText.getEmotion(), currentText.getCharacterName()));
                    }
                    secuentialText = StartCoroutine(SecuencialText(myManager.getSpeed(currentText.getMode()), currentDialogueText, myManager.getCharacterSound(currentText.getCharacterName())));
                }
                else
                {
                    dialogueCanvas.SetActive(false);
                }
            }
            else
            {
                dialogueCanvas.SetActive(false);
            }
        }
    }

         //Auxiliar Functions
        private void ComprobateOtherCharacter()
        {
        S_DialogueText firstDialogue = currentDialogue.getFirstDialogue();
        if (firstDialogue != null && firstDialogue.getDialogueText().Trim().ToUpper().Equals(otherSpriteCommand))
        {
            if (firstDialogue.getIsRightCharacter())
            {
                ChangeRightSprite(myManager.getCharacterEmotionSprite(firstDialogue.getEmotion(), firstDialogue.getCharacterName()));
            }
            else
            {
                ChangeLeftSprite(myManager.getCharacterEmotionSprite(firstDialogue.getEmotion(), firstDialogue.getCharacterName()));
            }
            currentDialogue.NextDialogue();
        }
    }

    private void ChangeRightSprite(Sprite sprite)
    {
        if (otherCharacterInvisible)
            spriteRight.gameObject.SetActive(true);
        spriteRight.sprite = sprite;
        //spriteRight.SetNativeSize();
        spriteRight.color = Color.white;
        if (otherCharacterInvisible)
        {
            spriteLeft.gameObject.SetActive(false);
        }
        else
        {
            spriteLeft.color = colorInactiveCharacter;
        }
      
    }

    private void ChangeLeftSprite(Sprite sprite)
    {
        if (otherCharacterInvisible)
            spriteLeft.gameObject.SetActive(true);
        spriteLeft.sprite = sprite;
        //spriteLeft.SetNativeSize();
        spriteLeft.color = Color.white;
 
        if (otherCharacterInvisible)
        {
            spriteRight.gameObject.SetActive(false);
        }
        else
        {
            spriteRight.color = colorInactiveCharacter;
        }

    }


    //Coroutines
    IEnumerator SecuencialText(float secondsBetween,string text,AudioClip sound)
    {
        List<char> characters = new List<char>();
        characters.AddRange(text.ToCharArray());
        UIText.text = "";
        char currentChar;
        myAudioSource.clip = sound;
        while (characters.Count > 0)
        {
            currentChar = characters[0];
            characters.RemoveAt(0);
            UIText.text += currentChar;
            if(!currentChar.Equals(' '))
                myAudioSource.Play();
            yield return new WaitForSeconds(secondsBetween);
        }
        secuentialText = null;
    }

}
