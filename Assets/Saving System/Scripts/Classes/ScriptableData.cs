using System;
using UnityEngine;

[Serializable]
public class ScriptableData 
{
    [SerializeField] private ScriptableObject _scriptableObject;
    [SerializeField] [TextArea] private string _json;

    public ScriptableObject scriptableObject => _scriptableObject;
    public string json => _json;


    public ScriptableData(ScriptableObject scriptableObject)
    {
        _scriptableObject = scriptableObject;
        _json = "";
    }

    public void SetJson(string json)
    {
        _json = json;
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
