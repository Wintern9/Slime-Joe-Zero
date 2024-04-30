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
    static public bool MusicBool = true; //ÁÄ
    static public bool SoundBool = true; //ÁÄ
    static public int LanguageWork = 0; //ÁÄ

    static public float SpeedCloud = 0.0001f;
    static public float parallaxEffectMultiplier = 0.7f;
    static public bool MusicPlaying = true; //Íå äîáàâëÿòü â ÁÄ

    static public bool volumeSoundEffectsBool = true;
    static public int AdaptiveJumpScreen = 0;

    static public int ScinNum = 0;
    static public int ScinNumEquipped = 0;

    static private int CoinValue = 0; //ÁÄ
    static public bool JumpControlSwitch = true;

    static private List<int> SkinOpens = new List<int> { 0 }; //ÁÄ

    static private List<string> LevelCompites = new List<string>(); //ÁÄ

    static private List<Level> Level = new List<Level>(); //ÁÄ


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
        LocalizationScript.TextChange = true;
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
        new ControllerDataBase().CoinSave(CoinValue);
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
            new ControllerDataBase().SkinSave(SkinOpens);
        }      
    }

    public bool LevelInfoGet(int LevelNum, int MoneyNum)
    {
        return Level[LevelNum].levelInfos[MoneyNum].MoneyTake;
    }

    public void LevelInfoSet(int LevelNum, int MoneyNum, bool Take)
    {
        Debug.Log("Update");
        Level[LevelNum].levelInfos[MoneyNum].MoneyTake = Take;
        new ControllerDataBase().LevelInfoUpdate(Level);
    }

    public int LevelComNumGet()
    {
        return LevelCompites.Count;
    }

    public void LevelComSet(string LevelName)
    {
        if (!LevelCompites.Contains(LevelName))
        {
            LevelCompites.Add(LevelName);
            new ControllerDataBase().LevelComSave(LevelCompites);
        }
    }

    public void SetValueToLevel(List<Level> LevelExtract)
    {
        Level = LevelExtract;
    }

    public void SetValueToSkin(List<ScinColection> Skin)
    {
        List<int> skinCollection = new List<int>() {0};

        foreach (ScinColection sc in Skin)
        {
            skinCollection.Add(sc.SkinOpens);
        }

        SkinOpens = skinCollection;
    }


    public void SetValueToLevelComplites(List<LevelComplite> levels)
    {
        List<string> levelsComplite = new List<string>();

        foreach (LevelComplite sc in levels)
        {
            levelsComplite.Add(sc.LevelComplites);
        }
        foreach (string sc in LevelCompites)
        {
            Debug.Log(sc);
        }
        LevelCompites = levelsComplite;
    }
}
