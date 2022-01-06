using UnityEngine;

public class S_DialogueInstance : MonoBehaviour
{
    [SerializeField]
    private string dialogueID;

    public void OnDialogueActivated()
    {
        S_DialogueUiManager.singleton.StartDialogue(dialogueID);
        Destroy(gameObject);
    }

}
