using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SavedData))]
public class SavedDataEditor : Editor
{
    private SavedData _savedData;
    private SerializedProperty _fileName;
    private SerializedProperty _scriptableDatas;

    private void OnEnable()
    {
        _savedData = target as SavedData;
        _fileName = serializedObject.FindProperty(nameof(_fileName));
        _scriptableDatas = serializedObject.FindProperty(nameof(_scriptableDatas));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_fileName);

        EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

        if (GUILayout.Button("Find all Savable"))
            _savedData.ReloadScriptableDatas(FindAllSavable<Savable>());

        if (GUILayout.Button("Clear Savable"))
            _savedData.ClearScriptableDatas();


        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(_scriptableDatas);
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

        if (GUILayout.Button("Serialize"))
            _savedData.Serialize();
        if (GUILayout.Button("Overwrite"))
            _savedData.Overwrite();

        EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

        if (GUILayout.Button("Save"))
            _savedData.Save();
        if (GUILayout.Button("Load"))
            _savedData.Load();

        serializedObject.ApplyModifiedProperties();
    }


    public T[] FindAllSavable<T>() where T : ScriptableObject
    {
        string[] typeIDs = AssetDatabase.FindAssets($"t:{typeof(T).Name}", new string[] { "Assets" });

        T[] output = new T[typeIDs.Length];

        for (int i = 0; i < typeIDs.Length; i++)
            output[i] = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(typeIDs[i]), typeof(T)) as T;

        return output;
    }

}
