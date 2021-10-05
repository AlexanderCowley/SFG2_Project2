using UnityEngine;
using UnityEditor;

public class DialogueToolWindow : EditorWindow
{
    [MenuItem("Window/Dialogue Tool")]
    static void OpenWindow()
    {
        DialogueToolWindow window = 
            (DialogueToolWindow)GetWindow(typeof(DialogueToolWindow));

        window.minSize = new Vector2(600, 300);
        window.Show();
    }
}