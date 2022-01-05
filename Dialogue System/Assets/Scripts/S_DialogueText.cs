using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DialogueText //: ScriptableObject
{
    private string characterName;
    private S_Emotions emotion;
    private S_Modes mode;
    private string dialogueText;
    private bool isRightCharacter;

    public S_DialogueText(string characterName, S_Emotions emotion, S_Modes mode, string dialogueText, bool isRightCharacter)
    {
        this.characterName = characterName;
        this.emotion = emotion;
        this.mode = mode;
        this.dialogueText = dialogueText;
        this.isRightCharacter = isRightCharacter;
    }

    public string getCharacterName() { return characterName; }
    public string getDialogueText() { return dialogueText; }
    public S_Emotions getEmotion() { return emotion; }
    public S_Modes getMode() { return mode; }
}
