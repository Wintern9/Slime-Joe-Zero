using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private int numSkin;

    private SpriteRenderer spriteRenderer;

    private int SkinEneble;

    [SerializeField] private BuyScript buyScript;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (Settings.ScinNum == numSkin)
        {
            SkinEneble = Settings.ScinNumEquipped;
            Color color = spriteRenderer.color;
            color.a = 0.4f;
            spriteRenderer.color = color;
        }
        if(buyScript == null)
        {
            Debug.LogError($"Кнопка {numSkin} не содержит объект BuyScript");
        }
    }

    private void Update()
    {
        if (Settings.ScinNum != numSkin)
        {
            Color color = spriteRenderer.color;
            color.a = 0.2f;
            spriteRenderer.color = color;
        }
    }

    public void ButtonSkin()
    {
        if (Settings.ScinNum != numSkin)
        {
            Color color = spriteRenderer.color;
            color.a = 0.4f;
            spriteRenderer.color = color;
        }
        Settings.ScinNum = numSkin;
        buyScript.BuyEnebled(Settings.ScinNum);
    }
}
