using System;
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
        S_DialogueText newText;
        string text;
       
        int start = 0;
        S_Modes mode;
        S_Emotions emotion;

        for(int i=0; i<texts.Length;i++)
        {
            text = texts[i];
            textInfo = text.Split('|');
           
            Enum.TryParse<S_Modes>(textInfo[3], out mode);
            Enum.TryParse<S_Emotions>(textInfo[2], out emotion);
            newText = new S_DialogueText(textInfo[1], emotion, mode, textInfo[4], textInfo[0].Equals("1"));
            dialogueTexts[i]=newText;

        }
    }
    //Getters
    public string getDialogueID()
    {
        return dialogueID;
    }
    public S_DialogueText getFirstDialogue() { 
        if (dialogueTexts.Length > 0)
        {
            return dialogueTexts[0];
        }
        return null;
    }
    //Functions
    public S_DialogueText NextDialogue()
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
