using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public List<DialogueData> dialogues = new List<DialogueData>();

    Button _btn;
    Text _dialogueText;
    Transform _ObjectTransform;
    void Awake()
    {
        _btn = GetComponent<Button>();
        _ObjectTransform = GetComponent<Transform>();
        _dialogueText = _ObjectTransform.root.GetChild(0).GetComponentInChildren<Text>();

        _dialogueText.text = null;

        dialogues.Reverse();
    }

    private void OnEnable()
    {
        _btn.onClick.AddListener(DrawText);
    }

    private void OnDisable()
    {
        _btn.onClick.RemoveListener(DrawText);
    }

    void DrawText() 
    {
        StartCoroutine(TextBuilder(.15f));
    }

    IEnumerator TextBuilder(float delay)
    {
        for(int i = 0; i < dialogues[0].dialogue.Length; i++)
        {
            _dialogueText.text = string.Concat(_dialogueText.text, dialogues[0].dialogue[i]);
            yield return new WaitForSeconds(delay);
        }
        
    }
}