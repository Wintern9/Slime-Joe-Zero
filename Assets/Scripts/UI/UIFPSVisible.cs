using System.Diagnostics;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private TextMeshProUGUI fpsText;
    private float timer;
    private int frames;

    void Start()
    {
        fpsText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        frames++;

        if (timer >= 1f)
        {
            float fps = frames / timer;
            fpsText.text = "FPS: " + fps.ToString("0");
            timer = 0f;
            frames = 0;
        }
    }
}
