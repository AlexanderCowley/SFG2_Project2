using System.Collections;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public ConversationData _conversationData;

    int _currentDialogueIndex = 0;
    void Awake()
    {
        
    }

    void NextDialogue()
    {

    }

    void ResetDialogue()
    {

    }

    void DrawText() 
    {
        StartCoroutine(TextBuilder(_conversationData.dialogues
            [_currentDialogueIndex].textSpeed));
    }

    IEnumerator TextBuilder(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}