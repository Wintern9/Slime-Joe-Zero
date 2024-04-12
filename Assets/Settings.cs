using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //Passive//
    static public bool EyesBool = true;
    static public bool rotate = false;
    //Active//
    static public bool MusicBool = true;
    static public bool SoundBool = true;
    static public int LanguageWork = 0;

    //static public int LevelCount = 1;
    //static public int LevelComplete = 0;

    static public float SpeedCloud = 0.0001f;
    static public float parallaxEffectMultiplier = 0.7f;
    static public bool MusicPlaying = true; //Не добавлять в БД

    static public bool volumeSoundEffectsBool = true;
    static public int AdaptiveJumpScreen = 0;

    static public int ScinNum = 0;
    static public int ScinNumEquipped = 0;

    static private int CoinValue = 0;
    static public bool JumpControlSwitch = true;

    static private List<int> SkinOpens = new List<int> {0};

    static private List<string> LevelCompites = new List<string>();

    static private List<Level> Level = new List<Level>()
    { 
        new Level // Уровень 1
        { 
            levelInfos = new LevelInfo[] 
            { 
                new LevelInfo // Монета 1
                { 
                    MoneyNum = 0, MoneyTake = false 
                } 
                // Добавлять сюда монеты
            }
        }, 
        new Level{levelInfos = new LevelInfo[]{new LevelInfo{MoneyNum = 0, MoneyTake = false }}}, 
        new Level{levelInfos = new LevelInfo[]{new LevelInfo{MoneyNum = 0, MoneyTake = false } } },  // Уровень 3
        new Level{levelInfos = new LevelInfo[]{new LevelInfo{MoneyNum = 0, MoneyTake = false } } },  // Уровень 4
        new Level{levelInfos = new LevelInfo[]{new LevelInfo{MoneyNum = 0, MoneyTake = false }, new LevelInfo { MoneyNum = 1, MoneyTake = false } ,new LevelInfo{MoneyNum = 2, MoneyTake = false } } },  // Уровень 5
        new Level{levelInfos = new LevelInfo[]{new LevelInfo{MoneyNum = 0, MoneyTake = false } } },  // Уровень 6
        
    };


    public void ChangeMusicBool()
    {
        MusicBool = !MusicBool;
        Debug.Log(MusicBool);
    }

    public void ChangeSoundBool()
    {
        SoundBool = !SoundBool;
        Debug.Log(SoundBool);
    }
    
    public void ChangeLanguage(int lan)
    {
        LanguageWork = lan;
    }

    public void Adaptive()
    {
        //AdaptiveJumpScreen = gameObject.GetComponent<TMP_Dropdown>().value;
    }

    public int CoinGet()
    {
        return CoinValue;
    }

    public void CoinSet(int coin)
    {
        CoinValue += coin;
    }

    public List<int> SkinOpensGet()
    {
        return SkinOpens;
    }

    public void SkinOpensSet(int SkinAdd)
    {
        if (!SkinOpens.Contains(SkinAdd))
        {
            SkinOpens.Add(SkinAdd);
        }
    }

    public bool LevelInfoGet(int LevelNum, int MoneyNum)
    {
        return Level[LevelNum].levelInfos[MoneyNum].MoneyTake;
    }

    public void LevelInfoSet(int LevelNum, int MoneyNum, bool Take)
    {
        Level[LevelNum].levelInfos[MoneyNum].MoneyTake = Take;
    }

    public int LevelComNumGet()
    {
        return LevelCompites.Count;
    }

    public void LevelComSet(string LevelName)
    {
        if(!LevelCompites.Contains(LevelName))
            LevelCompites.Add(LevelName);
    }
}
