using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJumpSwitch : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] bool Bool;
    void Start()
    {
        Check();
    }

    public void Switch()
    {
        Settings.JumpControlSwitch = Bool;
        Check();
    }

    private void Check()
    {
        if (Settings.JumpControlSwitch)
        {
            button1.SetActive(false);
            button2.SetActive(true);
        }
        else
        {
            button1.SetActive(true);
            button2.SetActive(false);
        }
    }
}
