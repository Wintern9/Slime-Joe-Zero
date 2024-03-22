using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChangerScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Slime;
    private ScinChanger scinChanger;

    private void Start()
    {
        scinChanger = GameObject.FindGameObjectWithTag("SkinSystem").GetComponent<ScinChanger>();
    }

    private void Update()
    {
        Slime.sprite = scinChanger.GetSprite();
    }
}
