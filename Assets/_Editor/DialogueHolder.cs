using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public List<DialogueData> dialogues = new List<DialogueData>();

    int _currentDialogueIndex = 0;
    void Awake()
    {
        dialogues.Reverse();
    }

    void NextDialogue()
    {

    }

    void ResetDialogue()
    {

    }

    void DrawText() 
    {
        StartCoroutine(TextBuilder(dialogues
            [_currentDialogueIndex].textSpeed));
    }

    IEnumerator TextBuilder(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}