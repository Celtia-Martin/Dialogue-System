using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DialogueInstanceOnStart : S_DialogueInstance
{
    void Start()
    {

       // OnDialogueActivated();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnDialogueActivated();
        }
    }


}
