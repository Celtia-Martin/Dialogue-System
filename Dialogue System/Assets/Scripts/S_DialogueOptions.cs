using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueOptions", menuName = "ScriptableObjects/DialogueOptions", order = 1)]
public class S_DialogueOptions :ScriptableObject
{
    [SerializeField]
    private float[] characterSeconds= new float[Enum.GetNames(typeof(S_Modes)).Length];
    [SerializeField]
    private AudioClip sound;
    [SerializeField]
    private bool otherSpriteIsInvisible;
    private static float defaultSpeed= 0.1f;
    
    public float getSpeed(int index)
    {
        if (index < characterSeconds.Length)
        {
            return characterSeconds[index];
        }
        else
        {
            return defaultSpeed;
        }
    }
    public AudioClip getSound() { return sound; }
    public bool getOtherSpriteIsVisible() { return otherSpriteIsInvisible; }
 
}
[CustomEditor(typeof(S_DialogueOptions))]
public class S_DialogueOptionsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Label("\ncharacterSeconds: seconds between characters creation.");
        GUILayout.Label("\nOrder of speed modes: ");
        string[] modes = Enum.GetNames(typeof(S_Modes));
        int i = 0;
        foreach (string mode in modes)
        {

            GUILayout.Label("\n" + i + ". " + mode);
            i++;
        }


    }
}