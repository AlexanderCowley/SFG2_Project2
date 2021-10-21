using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Dialogue Data", menuName = "New Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string TitleName;
    public GameObject prefab;
    public string dialogue;
    public string characterName;
    public Sprite portrait;
    public float textSpeed;
}