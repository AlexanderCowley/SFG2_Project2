using UnityEngine;
using UnityEditor;

public static class CustomTextAreaStyle
{

    public static GUIStyle TextAreaStyle;
    static CustomTextAreaStyle()
    {
        TextAreaStyle = new GUIStyle(EditorStyles.textArea);
        TextAreaStyle.wordWrap = true;
    }
}