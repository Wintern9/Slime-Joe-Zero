using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationScript : MonoBehaviour
{
    [SerializeField] Text[] text1;
    [SerializeField] TMP_Text[] text2;

    static public bool TextChange = false;
    static public int lanInt = 0;

    void Start()
    {
        lanInt = Settings.LanguageWork;
        Load();
    }

    void Load()
    {
        if (text1 == null || text2 == null)
        {
            text1 = FindObjectsOfType<Text>();
            text2 = FindObjectsOfType<TMP_Text>();
            Debug.Log("--" + text2.Length);
        }
    }

    void Update()
    {
        if (TextChange)
        {
            Debug.Log("Language");
            foreach (Text text in text1)
            {
                foreach (Language lan in LanguageScript.language)
                {
                    if(text.text.ToLower() == lan.localization[lanInt].ToLower())
                    {
                        text.text = lan.localization[Settings.LanguageWork];
                    }
                }
            }
            foreach (var text in text2)
            {
                foreach (Language lan in LanguageScript.language)
                {
                    if (text.text.ToLower() == lan.localization[lanInt].ToLower())
                    {
                        text.text = lan.localization[Settings.LanguageWork];
                    }
                }
            }
        }
        lanInt = Settings.LanguageWork;
        TextChange = false;
    }
}
