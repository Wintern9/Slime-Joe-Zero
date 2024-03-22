using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUpdate : MonoBehaviour
{
    Settings settings;
    TextMeshProUGUI coinValueText;
    private void Start()
    {
        settings = new Settings();
        coinValueText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinValueText.text = $"{settings.CoinGet()}";
    }
}
