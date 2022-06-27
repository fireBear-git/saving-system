using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ScriptableData 
{
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] private string _json;

    public string json => _json;

    public ScriptableData(ScriptableObject scriptableObject)
    {
        _scriptableObject = scriptableObject;
        _json = "";
    }

    public void Serialize()
    {
        _json = JsonUtility.ToJson(_scriptableObject);
    }

    public void Overwrite()
    {
        JsonUtility.FromJsonOverwrite(_json, _scriptableObject);
    }
}
