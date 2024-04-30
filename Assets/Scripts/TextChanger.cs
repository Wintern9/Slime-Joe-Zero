using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text text;

    [SerializeField] private string Text1;
    [SerializeField] private string Text2;

    [SerializeField] private string[] LanguageMassText;
    private int LanguageValue;

    [SerializeField] private int Music0OrSounds1OrLanguage2;

    void Start()
    {
        LanguageValue = LanguageScript.language[0].localization.Length;
        if (Music0OrSounds1OrLanguage2 == 0)
        {
            if (Settings.MusicBool)
            {
                text.text = Text1;
            }
            else
            {
                text.text = Text2;
            }
        } else if (Music0OrSounds1OrLanguage2 == 1)
        {
            if (Settings.SoundBool)
            {
                text.text = Text1;
            }
            else
            {
                text.text = Text2;
            }
        }
        else if (Music0OrSounds1OrLanguage2 == 2)
        { 
            text.text = LanguageMassText[numLan];
        }
    }

    public void ChangeTextBool()
    {
        if(text.text == Text1)
        {
            text.text = Text2;
        } else
        {
            text.text = Text1;
        }
    }

    private int numLan = 0;

    public void ChangeLaunguage()
    {
        numLan++;
        if (numLan >= LanguageValue) { numLan = 0; }
        Debug.Log(numLan);
        text.text = LanguageMassText[numLan];
        Settings settings = new Settings(); settings.ChangeLanguage(numLan);
    }
}
