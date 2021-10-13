using UnityEngine;
using UnityEditor;

public class DialogueToolWindow : EditorWindow
{
    Rect _sectionHeader;
    Rect _textHeader;
    Rect _portraitHeader;
    Rect _nameHeader;
    Rect _textSpeedHeader;
    Rect _BtnSaveHeader;

    Texture2D _headerSectionTexture;
    Texture2D _textHeaderTexture;
    Texture2D _portraitHeaderTexture;
    Texture2D _nameHeaderTexture;
    Texture2D _textSpeedHeaderTexture;
    Texture2D _BtnSaveHeaderTexture;

    Color _headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    Color _textHeaderColor = new Color(56f / 255f, 12f / 255f, 68f / 255f, 1f);
    Color _nameHeaderColor = new Color(45f / 255f, 65f / 255f, 30f / 255f, 1f);
    Color _portraitHeaderColor = new Color(90f / 255f, 21f / 255f, 42f / 255f, 1f);
    Color _textSpeedHeaderColor = new Color(50f / 255f, 67f / 255f, 23f / 255f, 1f);
    Color _BtnSaveHeaderColor = new Color(25f / 255f, 88f / 255f, 114f / 255f, 1f);

    static DialogueData _data;

    public static DialogueData DialogueData {get {return _data;}}


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
        InitData();
    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawSections();
    }

    public static void InitData()
    {
        _data = (DialogueData)ScriptableObject.CreateInstance(typeof(DialogueData));
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

        _portraitHeaderTexture = new Texture2D(1 ,1);
        _portraitHeaderTexture.SetPixel(1, 1, _portraitHeaderColor);
        _portraitHeaderTexture.Apply();

        _textSpeedHeaderTexture = new Texture2D(1, 1);
        _textSpeedHeaderTexture.SetPixel(1, 2, _textSpeedHeaderColor);
        _textSpeedHeaderTexture.Apply();

        _BtnSaveHeaderTexture = new Texture2D(1, 1);
        _BtnSaveHeaderTexture.SetPixel(2, 2, _BtnSaveHeaderColor);
        _BtnSaveHeaderTexture.Apply();
    }

    void DrawLayouts()
    {
        _sectionHeader.x = 0;
        _sectionHeader.y = 0;
        _sectionHeader.width = position.width;
        _sectionHeader.height = 38;

        _nameHeader.x = 0;
        _nameHeader.y = position.height / 8;
        _nameHeader.width = (position.width / 4f) * 2;
        _nameHeader.height = (position.height / 4) - 50;

        _textHeader.x = 0;
        _textHeader.y = position.width/4;
        _textHeader.width = (position.width / 4f) * 2;
        _textHeader.height = position.height - 50;

        _portraitHeader.x = 0;
        _portraitHeader.y = position.height/5;
        _portraitHeader.width = (position.width / 4f) * 2;
        _portraitHeader.height = (position.height / 4) - 50;

        _textSpeedHeader.x = 0;
        _textSpeedHeader.y = (position.height/3) - 15;
        _textSpeedHeader.width = (position.width / 4f) * 2;
        _textSpeedHeader.height = (position.height/4) - 30;

        _BtnSaveHeader.x = (position.width / 4f) * 3;
        _BtnSaveHeader.y = ((position.height / 4f) * 3) + 25;
        _BtnSaveHeader.width = (position.width / 4f);
        _BtnSaveHeader.height = position.height - 255;

        GUI.DrawTexture(_sectionHeader, _headerSectionTexture);
        GUI.DrawTexture(_nameHeader, _nameHeaderTexture);
        GUI.DrawTexture(_textHeader, _textHeaderTexture);
        GUI.DrawTexture(_portraitHeader, _portraitHeaderTexture);
        GUI.DrawTexture(_textSpeedHeader, _textSpeedHeaderTexture);
        GUI.DrawTexture(_BtnSaveHeader, _BtnSaveHeaderTexture);
    }

    void DrawSections()
    {
        DrawToolHeaderSection();
        DrawTextSection();

        DrawNameSection();
        DrawPortraitSection();
        DrawTextSpeedSection();
        DrawSaveBTNSection();

    }

    private void DrawPortraitSection()
    {
        GUILayout.BeginArea(_portraitHeader);
        GUILayout.BeginHorizontal();

        GUILayout.Label("Portrait: ");
        _data.portrait = (Sprite)EditorGUILayout.ObjectField(_data.portrait, typeof(Sprite), false);

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private void DrawTextSection()
    {
        GUILayout.BeginArea(_textHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Text Editor");
         _data.dialogue = (string)EditorGUILayout.TextArea(_data.dialogue, CustomTextAreaStyle.TextAreaStyle);

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void DrawToolHeaderSection()
    {
        GUILayout.BeginArea(_sectionHeader);

        GUILayout.Label("Dialogue Tool");

        GUILayout.EndArea();
    }

    private void DrawNameSection()
    {
        GUILayout.BeginArea(_nameHeader);
        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Name: ");
        EditorGUILayout.TextField(_data.characterName);

        EditorGUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private void DrawTextSpeedSection()
    {
        GUILayout.BeginArea(_textSpeedHeader);
        GUILayout.BeginHorizontal();

        GUILayout.Label("Text Speed: ");
        _data.textSpeed = (float)EditorGUILayout.FloatField(_data.textSpeed);

        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void DrawSaveBTNSection()
    {
        GUILayout.BeginArea(_BtnSaveHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Finish: ");
        if (GUILayout.Button("Save Conversation", GUILayout.Height(25)))
        {
            SaveData();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void SaveData()
    {

    }
}