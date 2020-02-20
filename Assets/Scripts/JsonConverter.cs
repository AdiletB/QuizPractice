using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class JsonConverter<T> where T: class
{
    private readonly string _fileName;
    private readonly string dataPath;
    private string json;

    public JsonConverter(string fileName)
    {
        _fileName = fileName;
        dataPath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

        json = System.IO.File.ReadAllText(dataPath);
    }
    public static bool TryRead(string fullPath){
        try
        {
            var text = System.IO.File.ReadAllText(fullPath);
            if(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                Debug.LogError("Empty file");

                return false;
            }
         

            return true;
        }
        catch(System.Exception exception)
        {
            Debug.LogError("TryRead method:"+ exception);

            return false;
        }
    }
    public T Convert()
    {
        try
        {
            Debug.Log("Convert info:"+ json);
            return JsonUtility.FromJson<T>(json); 
        }
        catch (System.Exception exception)
        {
            Debug.LogError("Convert method:"+ exception);

            return null;
        }
    }
}
