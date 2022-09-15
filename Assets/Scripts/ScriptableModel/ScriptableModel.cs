using System;
using System.IO;
using UnityEngine;

public class ScriptableModel<TModel> : ScriptableObject, IStorable where TModel : Model, new()
{
    [SerializeField] protected TModel _model;

    public TModel Model
    {
        get => _model;
        set
        {
            _model = value;
        }
    }

    public bool Load()
    {
        if(!File.Exists(GetStoragePath(name)))
        {
            return false;
        }

        TModel model = new TModel();
        string text = File.ReadAllText(GetStoragePath(name));
        JsonUtility.FromJsonOverwrite(text, model);

        Model = model;

        return true;
    }

    public bool Save()
    {
        try
        {
            string text = JsonUtility.ToJson(Model);
            File.WriteAllText(GetStoragePath(name), text);
        }
        catch(Exception e)
        {
            Debug.LogError(e);
            return false;
        }
        return true;
    }

    protected static string GetStoragePath(string name)
    {
        return Application.persistentDataPath + Path.DirectorySeparatorChar + name + ".json";
    }
}