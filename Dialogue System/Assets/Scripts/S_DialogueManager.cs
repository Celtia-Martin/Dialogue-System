using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DialogueManager : MonoBehaviour
{
    public static S_DialogueManager singleton;
    [SerializeField]
    private S_DialogueCharacter[] characters;
    [SerializeField]
    private TextAsset[] textFiles;
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private S_DialogueOptions dialogueOptions;

    private Dictionary<string, S_Dialogue> dialogueDictionary;
    private Dictionary<string, S_DialogueCharacter> characterDictionary;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        dialogueDictionary = new Dictionary<string, S_Dialogue>();
        characterDictionary = new Dictionary<string, S_DialogueCharacter>();
        foreach(S_DialogueCharacter chara in characters)
        {
            characterDictionary.Add(chara.getCharacterName(), chara);

        }
        S_Dialogue newDialogue;
        foreach (TextAsset textAsset in textFiles)
        {
            newDialogue = new S_Dialogue(textAsset);
            dialogueDictionary.Add(newDialogue.getDialogueID(), newDialogue);
        }
    }

   public Sprite getCharacterEmotionSprite(S_Emotions emotion,string nameCharacter)
    {
        if(characterDictionary.TryGetValue(nameCharacter,out S_DialogueCharacter value)){

            return value.getSprite((int)emotion)? value.getSprite((int)emotion):defaultSprite;
        }
        else
        {
            return defaultSprite;
        }
    }
    public S_Dialogue getDialogue(string id)
    {
        if(dialogueDictionary.TryGetValue(id, out S_Dialogue value)){

            return value;
        }
        else
        {
            return null;
        }
    }
    public float getSpeed(S_Modes mode)
    {
        return dialogueOptions.getSpeed((int)mode);
    }
    public AudioClip getSound()
    {
        return dialogueOptions.getSound();
    }
    public AudioClip getCharacterSound(string nameCharacter)
    {
        if (characterDictionary.TryGetValue(nameCharacter, out S_DialogueCharacter value))
        {

            return value.getSound() ? value.getSound() : getSound();
        }
        else
        {
            return getSound();
        }
    }
}
