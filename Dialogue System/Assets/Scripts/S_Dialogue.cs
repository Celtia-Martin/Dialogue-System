using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Dialogue 
{
    //private Queue<S_DialogueText> dialogueTexts;
    private S_DialogueText[] dialogueTexts;
    private String dialogueID;
    private int cont=-1;
    public S_Dialogue(TextAsset textAsset)
    {

        string[] texts = textAsset.text.Split('\n');
        string[] textInfo;
        dialogueTexts = new S_DialogueText[texts.Length];
        dialogueID = textAsset.name;
        cont = 0;
        S_DialogueText newText;
        string text;
        for(int i=0; i<texts.Length;i++)
        {
            text = texts[i];
            textInfo = text.Split('|');
            S_Modes mode;
            S_Emotions emotion;
            Enum.TryParse<S_Modes>(textInfo[3], out mode);
            Enum.TryParse<S_Emotions>(textInfo[2], out emotion);
            newText = new S_DialogueText(textInfo[1], emotion, mode, textInfo[4], textInfo[0].Equals("1"));
            dialogueTexts[i]=newText;

        }
    }
    public string getDialogueID()
    {
        return dialogueID;
    }
 
    public S_DialogueText nextDialogue()
    {
        cont++;
        if (cont<dialogueTexts.Length)
        {
           
            return dialogueTexts[cont];
        }
        cont = -1;
        return null;
    }
 
}
