using UnityEngine;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;

public class JsonDataLoader : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "-localization.json";

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            LanguageScript.language = JsonConvert.DeserializeObject<Language[]>(jsonData);
        }
        else
        {
            string jsonData = JsonConvert.SerializeObject(LanguageScript.language, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
