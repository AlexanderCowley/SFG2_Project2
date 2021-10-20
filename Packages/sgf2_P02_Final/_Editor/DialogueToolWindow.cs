using System.IO;
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
    Rect _BtnPrefabHeader;
    Rect _prefabHeader;
    Rect _dialogueTitleHeader;

    GUISkin _skin;

    Texture2D _headerSectionTexture;
    Texture2D _textHeaderTexture;
    Texture2D _portraitHeaderTexture;
    Texture2D _nameHeaderTexture;
    Texture2D _textSpeedHeaderTexture;
    Texture2D _BtnSaveHeaderTexture;
    Texture2D _dialogueTitleHeaderTexture;
    Texture2D _prefabHeaderTexture;
    Texture2D _BtnPrefabHeaderTexture;

    Color _headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    Color _textHeaderColor = new Color(56f / 255f, 12f / 255f, 68f / 255f, 1f);
    Color _nameHeaderColor = new Color(45f / 255f, 65f / 255f, 30f / 255f, 1f);
    Color _portraitHeaderColor = new Color(90f / 255f, 21f / 255f, 42f / 255f, 1f);
    Color _textSpeedHeaderColor = new Color(50f / 255f, 67f / 255f, 23f / 255f, 1f);
    Color _BtnSaveHeaderColor = new Color(25f / 255f, 88f / 255f, 114f / 255f, 1f);
    Color _prefabHeaderColor = new Color(67f / 255f, 12f / 255f, 120f / 255f, 1f);
    Color _dialogueTitleHeaderColor = 
        new Color(63f / 255f, 98f / 255f, 63f / 255f, 1f);
    Color _BtnPrefabHeaderColor = new Color(63f / 255f, 113f / 255f, 200f / 255f, 1f);

    static DialogueData _dialogueData;

    GameObject _dialoguePrefab;

    DialogueHolder _selectedDialogueHolder;

    int DataCharacterIndex = 0;

    bool _assetFound;

    string _previousPath;

    public static DialogueData DialogueData {get {return _dialogueData;}}

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
        _skin = Resources.Load<GUISkin>("GUISkins/DialogueToolSkin");
    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawSections();
    }

    public static void InitData()
    {
        _dialogueData = (DialogueData)ScriptableObject.
            CreateInstance(typeof(DialogueData));
    }


    void InitTextures()
    {
        InitWindowsTextures();

        InitDialogueTextures();
    }

    private void InitWindowsTextures()
    {
        _headerSectionTexture = new Texture2D(1, 1);
        _headerSectionTexture.SetPixel(0, 0, _headerSectionColor);
        _headerSectionTexture.Apply();
    }

    void InitDialogueTextures()
    {
        _textHeaderTexture = new Texture2D(1, 1);
        _textHeaderTexture.SetPixel(0, 1, _textHeaderColor);
        _textHeaderTexture.Apply();

        _nameHeaderTexture = new Texture2D(1, 1);
        _nameHeaderTexture.SetPixel(1, 0, _nameHeaderColor);
        _nameHeaderTexture.Apply();

        _portraitHeaderTexture = new Texture2D(1, 1);
        _portraitHeaderTexture.SetPixel(1, 1, _portraitHeaderColor);
        _portraitHeaderTexture.Apply();

        _textSpeedHeaderTexture = new Texture2D(1, 1);
        _textSpeedHeaderTexture.SetPixel(1, 2, _textSpeedHeaderColor);
        _textSpeedHeaderTexture.Apply();

        _BtnSaveHeaderTexture = new Texture2D(1, 1);
        _BtnSaveHeaderTexture.SetPixel(2, 2, _BtnSaveHeaderColor);
        _BtnSaveHeaderTexture.Apply();

        _dialogueTitleHeaderTexture = new Texture2D(1, 1);
        _dialogueTitleHeaderTexture.SetPixel(1, 1, _dialogueTitleHeaderColor);
        _dialogueTitleHeaderTexture.Apply();

        _prefabHeaderTexture = new Texture2D(1, 1);
        _prefabHeaderTexture.SetPixel(1, 1, _prefabHeaderColor);
        _prefabHeaderTexture.Apply();

        _BtnPrefabHeaderTexture = new Texture2D(1, 1);
        _BtnPrefabHeaderTexture.SetPixel(1, 1, _BtnPrefabHeaderColor);
        _BtnPrefabHeaderTexture.Apply();
    }

    void DrawLayouts()
    {
        DrawHeaderLayout();
        DrawDialogueLayout();
        DrawConversationLayout();
    }

    void DrawHeaderLayout()
    {
        _sectionHeader.x = 0;
        _sectionHeader.y = 0;
        _sectionHeader.width = position.width;
        _sectionHeader.height = (position.height / 8);

        GUI.DrawTexture(_sectionHeader, _headerSectionTexture);
    }

    void DrawDialogueLayout()
    {

        _dialogueTitleHeader.x = 0;
        _dialogueTitleHeader.y = (position.height / 8);
        _dialogueTitleHeader.width = (position.width);
        _dialogueTitleHeader.height = (position.height / 8);

        _nameHeader.x = 0;
        _nameHeader.y = position.height / 4;
        _nameHeader.width = (position.width / 4f) * 2;
        _nameHeader.height = (position.height / 6f);

        _textSpeedHeader.x = 0;
        _textSpeedHeader.y = (position.height / 2.6f);
        _textSpeedHeader.width = (position.width / 4f) * 2;
        _textSpeedHeader.height = (position.height / 6);

        _portraitHeader.x = 0;
        _portraitHeader.y = position.height / 2.3f;
        _portraitHeader.width = (position.width / 4f) * 2;
        _portraitHeader.height = (position.height / 8);

        _textHeader.x = 0;
        _textHeader.y = position.height / 1.8f;
        _textHeader.width = (position.width / 2);
        _textHeader.height = position.height / 4;

        _BtnSaveHeader.x = 0;
        _BtnSaveHeader.y = ((position.height / 1.24f));
        _BtnSaveHeader.width = (position.width / 2f);
        _BtnSaveHeader.height = position.height / 5f;

        _BtnPrefabHeader.x = position.height /0.93f;
        _BtnPrefabHeader.y = position.width / 2.68f;
        _BtnPrefabHeader.width = position.width / 1.9f;
        _BtnPrefabHeader.height = position.height / 5f;


        GUI.DrawTexture(_nameHeader, _nameHeaderTexture);
        GUI.DrawTexture(_textHeader, _textHeaderTexture);
        GUI.DrawTexture(_portraitHeader, _portraitHeaderTexture);
        GUI.DrawTexture(_textSpeedHeader, _textSpeedHeaderTexture);
        GUI.DrawTexture(_BtnSaveHeader, _BtnSaveHeaderTexture);
        GUI.DrawTexture(_dialogueTitleHeader, _dialogueTitleHeaderTexture);
        GUI.DrawTexture(_BtnPrefabHeader, _BtnPrefabHeaderTexture);
    }

    void DrawConversationLayout()
    {
        _prefabHeader.x = position.width / 2;
        _prefabHeader.y = (position.height / 4);
        _prefabHeader.width = (position.width / 4f) * 2;
        _prefabHeader.height = (position.height / 1.8f);

        GUI.DrawTexture(_prefabHeader, _prefabHeaderTexture);
    }

    void DrawSections()
    {
        DrawToolHeaderSection();

        DrawDialogueDataSections();
    }

    void DrawDialogueDataSections()
    {
        DrawDialogueTitleSection();

        DrawNameSection();
        DrawPortraitSection();
        DrawTextSpeedSection();
        DrawTextSection();

        DrawSaveBTNSection();
        DrawPrefabBTNSection();
        DrawPrefabSection();
    }

    private void DrawToolHeaderSection()
    {
        GUILayout.BeginArea(_sectionHeader);

        GUILayout.Label("Dialogue Tool", _skin.GetStyle("WindowHeader"));

        GUILayout.EndArea();
    }

    private void DrawDialogueTitleSection()
    {
        GUILayout.BeginArea(_dialogueTitleHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Dialogue Title:");
        _dialogueData.TitleName = (string)EditorGUILayout.TextField(_dialogueData.TitleName);

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void DrawNameSection()
    {
        GUILayout.BeginArea(_nameHeader);
        EditorGUILayout.BeginVertical();

        GUILayout.Label("Character Name:");
        EditorGUILayout.TextField(_dialogueData.characterName);

        EditorGUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void DrawPortraitSection()
    {
        GUILayout.BeginArea(_portraitHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Portrait:");
        _dialogueData.portrait = (Sprite)EditorGUILayout.
            ObjectField(_dialogueData.portrait, typeof(Sprite), false);

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void DrawTextSection()
    {
        GUILayout.BeginArea(_textHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Text Editor");
         _dialogueData.dialogue = (string)EditorGUILayout.TextArea
            (_dialogueData.dialogue, CustomTextAreaStyle.TextAreaStyle);

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void DrawTextSpeedSection()
    {
        GUILayout.BeginArea(_textSpeedHeader);
        GUILayout.BeginHorizontal();

        GUILayout.Label("Text Speed:");

        _dialogueData.textSpeed = (float)EditorGUILayout.
            FloatField(_dialogueData.textSpeed);

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    void DrawPrefabSection()
    {
        GUILayout.BeginArea(_prefabHeader);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        GUILayout.Label("Prefab:");
        _dialogueData.prefab = (GameObject)EditorGUILayout.ObjectField
            (_dialogueData.prefab, typeof(GameObject), false);

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    void DrawSaveBTNSection()
    {
        GUILayout.BeginArea(_BtnSaveHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Create Dialoge Data:");
        if (_dialogueData.dialogue == null || _dialogueData.dialogue.Length < 1)
            EditorGUILayout.HelpBox("[Dialogue] must have text before saving!", MessageType.Warning);

        else if (_dialogueData.TitleName == null || _dialogueData.TitleName.Length < 1)
            EditorGUILayout.HelpBox("[Title Name] must be filled in before saving!", MessageType.Warning);

        else if(_dialogueData.TitleName == AssetDatabase.GetAssetPath(_dialogueData))
            EditorGUILayout.HelpBox("[Title Name] needs a different name!", MessageType.Warning);

        else if(_selectedDialogueHolder == null)
            EditorGUILayout.HelpBox("Assign or Create a new [Prefab] before saving!", MessageType.Warning);

        else if (_assetFound)
            EditorGUILayout.HelpBox("[Title Name] is not unique! Change it!",
                MessageType.Warning);

        else if (GUILayout.Button("Save Dialogue Data", GUILayout.Height(25), GUILayout.Width(150)))
            SaveDialogueData();

        _assetFound = false;

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void DrawPrefabBTNSection()
    {
        GUILayout.BeginArea(_BtnPrefabHeader);
        GUILayout.BeginVertical();

        GUILayout.Label("Create New Prefab:");

        if (_dialogueData.TitleName == null || _dialogueData.TitleName.Length < 1)
            EditorGUILayout.HelpBox("[Title Name] must be filled in before saving!", MessageType.Warning);

        else if(_dialogueData.prefab == null)
            EditorGUILayout.HelpBox("[Prefab] needs to be selected!", MessageType.Warning);

        else if (_assetFound)
            EditorGUILayout.HelpBox("[Title Name] is not unique! Change it!",
                MessageType.Warning);

        else if (GUILayout.Button("Create Prefab", GUILayout.Height(25), GUILayout.Width(150)))
            SetNewPrefab();

        _assetFound = false;

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    void SaveDialogueData()
    {
        string dataPath = 
            $"Assets/Resources/CharacterData/DialogueData/{_selectedDialogueHolder.gameObject.name}_{DataCharacterIndex}.asset";

        Debug.Log(_previousPath);
        Debug.Log(dataPath);

        if (dataPath == _previousPath)
        {
            Debug.Log("wrong path");
            //Add message
            return;
        }
        if(AssetDatabase.GetAssetPath(_dialogueData) != null)
        {
            Debug.Log("working");
            AssetDatabase.CreateAsset(DialogueToolWindow._dialogueData, dataPath);
        }

        _previousPath = AssetDatabase.GetAssetPath(_dialoguePrefab);

        _dialoguePrefab.GetComponent<DialogueHolder>().
            dialogues.Add(DialogueToolWindow._dialogueData);

        Debug.Log(_dialoguePrefab.GetComponent<DialogueHolder>().
            dialogues.Count);

        DataCharacterIndex++;
    }

    void SetNewPrefab()
    {
        string newPrefabPath = AssetDatabase.GenerateUniqueAssetPath(
            "Assets/Prefabs/DialogueObjects/" + 
            DialogueToolWindow._dialogueData.TitleName + "_" + ".prefab");

        string prefabPath = AssetDatabase.GetAssetPath(DialogueToolWindow._dialogueData.prefab);

        AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        _dialoguePrefab = (GameObject)AssetDatabase.
            LoadAssetAtPath(newPrefabPath, typeof(GameObject));

        if (!_dialoguePrefab.GetComponent<DialogueHolder>())
            _dialoguePrefab.AddComponent(typeof(DialogueHolder));

        _selectedDialogueHolder = _dialoguePrefab.GetComponent<DialogueHolder>();
    }
}