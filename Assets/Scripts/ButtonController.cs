using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    void Start()
    {
        Button[] childButtons = GetComponentsInChildren<Button>();
        Settings settings = new Settings();

        for (int i = 0; i < settings.LevelComNumGet()+1; i++)
        {
            childButtons[i].interactable = true;
        }
    }    
}
