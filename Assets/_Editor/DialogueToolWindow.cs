using UnityEngine;
using UnityEditor;

public class DialogueToolWindow : EditorWindow
{
    Rect _sectionHeader;
    Rect _textHeader;
    Rect _portraitHeader;
    Rect _nameHeader;

    Texture2D _headerSectionTexture;
    Texture2D _textHeaderTexture;
    Texture2D _portraitHeaderTexture;
    Texture2D _nameHeaderTexture;

    Color _headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);
    Color _textHeaderColor = new Color(56f/255f, 12f/255f, 68f/255f, 1f);
    Color _nameHeaderColor = new Color(45f/255f, 65f/255f, 30f/255f, 1f);
    Color _portraitHeaderColor = new Color(90f/255f, 2f/255f, 90f/255f, 1f);


    [MenuItem("Window/Dialogue Tool")]
    static void OpenWindow()
    {
        DialogueToolWindow window = 
            (DialogueToolWindow)GetWindow(typeof(DialogueToolWindow));

        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    private void OnEnable()
    {
        InitTextures();
    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
    }

    void InitTextures()
    {

        //CHANGE TO ASSETDATABASE AS A SOURCE FOR TEXTURES
        _headerSectionTexture = new Texture2D(1, 1);
        _headerSectionTexture.SetPixel(0,0, _headerSectionColor);
        _headerSectionTexture.Apply();

        _textHeaderTexture = new Texture2D(1, 1);
        _textHeaderTexture.SetPixel(0, 1, _textHeaderColor);
        _textHeaderTexture.Apply();

        _nameHeaderTexture = new Texture2D(1, 1);
        _nameHeaderTexture.SetPixel(1, 0, _nameHeaderColor);
        _nameHeaderTexture.Apply();

        _portraitHeaderTexture = new Texture2D(1,1);
        _portraitHeaderTexture.SetPixel(2, 3, _portraitHeaderColor);
        _portraitHeaderTexture.Apply();
    }

    void DrawLayouts()
    {
        _sectionHeader.x = 0;
        _sectionHeader.y = 0;
        _sectionHeader.width = Screen.width;
        _sectionHeader.height = 50;

        _textHeader.x = 0;
        _textHeader.y = 50;
        _textHeader.width = Screen.width / 3;
        _textHeader.height = Screen.height - 50;

        _nameHeader.x = Screen.width / 3;
        _nameHeader.y = 50;
        _nameHeader.width = Screen.width / 3;
        _nameHeader.height = Screen.height - 50;

        _portraitHeader.x = Screen.width / 3 * 2;
        _portraitHeader.y = 50;
        _portraitHeader.width = Screen.width / 3;
        _portraitHeader.height = Screen.height - 50;

        GUI.DrawTexture(_sectionHeader, _headerSectionTexture);
        GUI.DrawTexture(_textHeader, _textHeaderTexture);
        GUI.DrawTexture(_nameHeader, _nameHeaderTexture);
        GUI.DrawTexture(_portraitHeader, _portraitHeaderTexture);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(_sectionHeader);

        GUILayout.Label("Dialogue Tool");

        GUILayout.EndArea();
    }
}