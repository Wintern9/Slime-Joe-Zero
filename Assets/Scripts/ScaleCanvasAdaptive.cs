using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCanvasAdaptive : MonoBehaviour
{
    void Awake()
    {
        var CanvasScaler = GetComponent<CanvasScaler>();
        Vector2 screen = new Vector2(Screen.width, Screen.height);
        Vector2 screen2 = new Vector2(2040, 1080);

        float nim = float.Parse(Screen.width.ToString()) / float.Parse(Screen.height.ToString());

        CanvasScaler.matchWidthOrHeight = CalculateValue(nim);
    }

    private float CalculateValue(float inputValue)
    {
        if (inputValue <= 1.7f)
        {
            return 0;
        }
        else if (inputValue >= 2.5f)
        {
            return 0.725f;
        }
        else
        {
            return 0.5f;
        }
    }
}
