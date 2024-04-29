using UnityEngine;
using System.IO;

public class JsonDataLoader : MonoBehaviour
{
    public string filePath = Application.persistentDataPath + "localization.json";

    void Start()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            MyDataObject[] dataObjects = JsonUtility.FromJson<MyDataObject[]>(jsonData);

            foreach (MyDataObject dataObject in dataObjects)
            {
                Debug.Log("Name: " + dataObject.Name + ", Age: " + dataObject.Age);
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    [System.Serializable]
    public class MyDataObject
    {
        public string Name;
        public int Age;
    }
}
