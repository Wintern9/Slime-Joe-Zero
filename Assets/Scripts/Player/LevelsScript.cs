using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartDisable : MonoBehaviour
{
    // Start is called before the first frame update
    private Image[] images;
    private TextMeshProUGUI[] Texts;

    [SerializeField] private GameObject buttonDisable;

    void Start()
    {
        images = GetComponentsInChildren<Image>();
        Texts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (Image image in images)
        {
            Color color = image.color; color.a = 0; image.color = color;
        }
        foreach (TextMeshProUGUI text in Texts)
        {
            Color color = text.color; color.a = 0; text.color = color;
        }
        gameObject.SetActive(false);
    }

    bool OpacityComplete = false;
    bool OpacityRevComplete = true;
    bool ButtonBackBool = false;
    float Timer;

    public void OpacityCom()
    {
        OpacityComplete = false;
    }
    
    public void OpacityRevCom()
    {
        OpacityRevComplete = false;
    }

    bool BackButton = false;

    public void ButtonClickBack()
    {
        Timer = 0;
        BackButton = true;
        buttonDisable.SetActive(true);
    }

    private void Update()
    {
        if (gameObject.activeSelf && !OpacityComplete)
        {
            Timer += Time.deltaTime;
            if (Timer > 0.5f)
            {
                foreach (Image image in images)
                {
                    Color color = image.color; color.a += 1f * Time.deltaTime; image.color = color;
                }
                foreach (TextMeshProUGUI text in Texts)
                {
                    Color color = text.color; color.a += 1f * Time.deltaTime; text.color = color;
                    if (color.a >= 1f) OpacityComplete = true;
                }
            }
        }

        if (images[0].color.a > 0f && !OpacityRevComplete)
        {
            foreach (Image image in images)
            {
                Color color = image.color; color.a -= 1f * Time.deltaTime; image.color = color;
            }
            foreach (TextMeshProUGUI text in Texts)
            {
                Color color = text.color; color.a -= 1f * Time.deltaTime; text.color = color;
                if (color.a <= 0f) OpacityRevComplete = true;
            }
        }

        if (BackButton && images[0].color.a <= 0)
        {
            gameObject.SetActive(false);
            BackButton = false;
        }
    }
}
