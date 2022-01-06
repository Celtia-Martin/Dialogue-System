using System;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueCharacters", menuName = "ScriptableObjects/DialogueCharacter", order = 1)]
public class S_DialogueCharacter : ScriptableObject
{
   [SerializeField]
    private string characterName;
    [SerializeField]
    private Sprite[] emotionSprites;
    [SerializeField]
    private AudioClip sound;
 
    //More things like sound, font...
    public string getCharacterName()
    {
        return characterName;
    }
    public Sprite getSprite(int i)
    {
        if(i<emotionSprites.Length)
            return emotionSprites[i];
        return null;
    }
    public AudioClip getSound()
    {
        return sound;
    }

}
[CustomEditor(typeof(S_DialogueCharacter))]
public class S_DialogueCharacterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Label("\nOrder of emotions: ");
        string[] emotions = Enum.GetNames(typeof(S_Emotions));
        int i = 0;
        foreach(string emotion in emotions)
        {
           
            GUILayout.Label("\n"+i+". " +emotion);
            i++;
        }


    }
}