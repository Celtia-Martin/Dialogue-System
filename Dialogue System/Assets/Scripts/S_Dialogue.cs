using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Dialogue //: ScriptableObject
{
    private Queue<S_DialogueText> dialogueTexts;
    private String dialogueID;
    public S_Dialogue(TextAsset textAsset)
    {
        dialogueTexts = new Queue<S_DialogueText>();
        string[] texts = textAsset.text.Split('\n');
        string[] textInfo;
        dialogueID = textAsset.name;
        
        S_DialogueText newText;
        foreach(string text in texts)
        {
            textInfo = text.Split('|');
            S_Modes mode;
            S_Emotions emotion;
            Enum.TryParse<S_Modes>(textInfo[3], out mode);
            Enum.TryParse<S_Emotions>(textInfo[2], out emotion);
            newText = new S_DialogueText(textInfo[1], emotion, mode, textInfo[4], textInfo[0].Equals("1"));
            dialogueTexts.Enqueue(newText);

        }
    }
    public string getDialogueID()
    {
        return dialogueID;
    }
    public S_DialogueText nextDialogue()
    {
        if (dialogueTexts.Count != 0)
        {
            return dialogueTexts.Dequeue();
        }
        return null;
    }
 
}
