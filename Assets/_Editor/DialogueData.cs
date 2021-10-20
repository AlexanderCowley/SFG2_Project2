using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Data", menuName = "New Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string TitleName;
    public string dialogue;
    public string characterName;
    public Sprite portrait;
    public float textSpeed;
}