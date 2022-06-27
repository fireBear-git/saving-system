using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Saving System/Create SavedData", fileName = "SavedData")]
public class SavedData : ScriptableObject
{
    [Header("Fields")]
    [SerializeField] private string _fileName;
    
    [Header("Dipendencies")]
    [SerializeField] private ScriptableData[] _scriptableDatas;

    private string _path => $"{Application.persistentDataPath}/{_fileName}.sv";

    public void Serialize()
    {
        for (int i = 0; i < _scriptableDatas.Length; i++)
            _scriptableDatas[i].Serialize(); 
    }

    public void Overwrite()
    {
        for (int i = 0; i < _scriptableDatas.Length; i++)
            _scriptableDatas[i].Overwrite(); 
    }

    public void Save()
    {
        Serialize();

        string json = JsonUtility.ToJson(this);

        using (FileStream fileStream = new FileStream(_path, FileMode.OpenOrCreate))
        {
            using (BinaryWriter writer = new BinaryWriter(fileStream))
            {
                writer.Write(json);
            }
        }
    }

    public void Load()
    {
        string json = "";

        if (!File.Exists(_path))
        {
            Save();
            return;
        }

        using (FileStream FileStream = new FileStream(_path, FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(FileStream))
            {
                json = reader.ReadString();
            }
        }

        JsonUtility.FromJsonOverwrite(json, this);
        Overwrite();
    }
}
