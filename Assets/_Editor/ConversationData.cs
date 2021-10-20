using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation Data", menuName = "New Conversation")]
public class ConversationData : ScriptableObject
{
    public string ConversationTitle;
    public GameObject prefab;
    public List<DialogueData> dialogues = new List<DialogueData>();
}