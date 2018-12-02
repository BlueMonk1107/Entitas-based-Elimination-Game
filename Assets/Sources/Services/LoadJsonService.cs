using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadJsonService  {

    public static LoadJsonService Instance { get; private set; } = new LoadJsonService();

    public T LoadJson<T>() where T: class
    {
        string path = Application.streamingAssetsPath + "/Data.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }

        return null;
    }
}
