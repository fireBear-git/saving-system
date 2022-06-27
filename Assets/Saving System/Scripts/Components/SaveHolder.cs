using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveHolder : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private SavedData _savedData;
    
    public static Action serialize { get; private set; }
    public static Action overwrite { get; private set; }
    
    public static Action save { get; private set; }
    public static Action load { get; private set; }

    void OnEnable()
    {
        if (!_savedData)
            return;

        serialize += _savedData.Serialize;       
        overwrite += _savedData.Overwrite;       

        save += _savedData.Save;       
        load += _savedData.Load;       
    }

#if UNITY_EDITOR
    
    private void Reset()
    {
        string dataID = AssetDatabase.FindAssets($"t:{typeof(SavedData).Name.ToLower()}")[0];
        _savedData = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(dataID), typeof(SavedData)) as SavedData;
    }

#endif
    
    void OnDisable()
    {
        if (!_savedData)
            return;

        serialize -= _savedData.Serialize;       
        overwrite -= _savedData.Overwrite;       

        save -= _savedData.Save;       
        load -= _savedData.Load;       
    }
}
