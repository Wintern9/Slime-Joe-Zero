using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : Settings
{
    [SerializeField] private int LevelNum_Minus1Level;
    [SerializeField] private int CoinNum;

    Settings settings;
    private void Start()
    {
        if(LevelInfoGet(LevelNum_Minus1Level, CoinNum))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelInfoSet(LevelNum_Minus1Level, CoinNum, true);
            gameObject.SetActive(false);
            CoinSet(1);
        }
    }
}
