using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.IO;
using System.Linq;
using System;

public class ExtractDataBase : MonoBehaviour
{
    Settings settings;
    string dbPath;
    SQLiteConnection connection;

    string DBName = "/mydatabase.db";

    private void Awake()
    {
        dbPath = Application.persistentDataPath + DBName;
        if (!File.Exists(dbPath))
        {          
            connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            FirstEntryGame();
        }else{connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite);}
        settings = new Settings();
        StartLoading();
    }

    void StartLoading()
    {
        settings.SetValueToLevel(CreateLevelList());
        settings.CoinSet(connection.Table<PlayerInfo>().ToList()[0].Coin);
        settings.SetValueToSkin(connection.Table<ScinColection>().ToList());
        settings.SetValueToLevelComplites(connection.Table<LevelComplite>().ToList());
    }

    void FirstEntryGame()
    {
        connection.CreateTable<LevelInfoBD>();
        connection.CreateTable<PlayerInfo>();
        connection.CreateTable<ScinColection>();
        connection.CreateTable<LevelComplite>();

        foreach (LevelInfoBD levelInfoBD in ParseListLevelInfo())
            connection.Insert(levelInfoBD);

        connection.Insert(new PlayerInfo() {Coin = 0});
    }

    List<LevelInfoBD> ParseListLevelInfo()
    {
        List<LevelInfoBD> newLevelInfoBD = new List<LevelInfoBD>();
        foreach (Level level in levels)
        {
            foreach (LevelInfo levelInfo in level.levelInfos)
            {
                newLevelInfoBD.Add(new LevelInfoBD
                {
                    MoneyNum = levelInfo.MoneyNum,
                    MoneyTake = Convert.ToInt32(levelInfo.MoneyTake)
                });
            }
        }
        return newLevelInfoBD;
    }

    private List<Level> CreateLevelList()
    {
        List<LevelInfoBD> levelInfo = connection.Table<LevelInfoBD>().ToList();

        try
        {
            int b = 0;
            for (int i = 0; i < levels.Count; i++)
            {
                for (int j = 0; j < levels[i].levelInfos.Length; j++)
                {
                    levels[i].levelInfos[j].MoneyTake = levelInfo[b].MoneyTake > 0;
                    Debug.Log(levels[i].levelInfos[j].MoneyTake);
                    b++;
                }
            }
        } catch(Exception ex) {
            throw new Exception("Ошибка обработки LevelInfo: " + ex.Message);
        }

        return levels;
    }

    public void CoinSave(int Coin)
    {
        connection = new SQLiteConnection(Application.persistentDataPath + DBName, SQLiteOpenFlags.ReadWrite);
        var coinUpdate = connection.Table<PlayerInfo>().FirstOrDefault();
        coinUpdate.Coin = Coin;
        connection.Update(coinUpdate);
    }

    public void LevelInfoUpdate(List<Level> level)
    {
        levels = level;

        connection = new SQLiteConnection(Application.persistentDataPath + DBName, SQLiteOpenFlags.ReadWrite);
        var levelUpdate = connection.Table<LevelInfoBD>().ToList();
        var levelUpdate2 = ParseListLevelInfo();

        for(int i = 0; i < levelUpdate.Count; i++)
        {
            levelUpdate[i].MoneyTake = levelUpdate2[i].MoneyTake;
            levelUpdate[i].MoneyNum = levelUpdate2[i].MoneyNum;
        }

        connection.UpdateAll(levelUpdate);
    }

    public void SkinSave(List<int> skin)
    {
        connection = new SQLiteConnection(Application.persistentDataPath + DBName, SQLiteOpenFlags.ReadWrite);
        var skinOpen = connection.Table<ScinColection>().ToList();
        connection.Insert(new ScinColection() { SkinOpens = skin[skin.Count - 1] });
    }

    public void LevelComSave(List<string> levels)
    {
        connection = new SQLiteConnection(Application.persistentDataPath + DBName, SQLiteOpenFlags.ReadWrite);
        connection.Insert(new LevelComplite() { LevelComplites = levels[levels.Count - 1] });
    }

    List<Level> levels = new List<Level>{
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
        new Level { levelInfos = new LevelInfo[] { new LevelInfo { MoneyNum = 0, MoneyTake = false } } }, // Уровень 2
        new Level { levelInfos = new LevelInfo[] { new LevelInfo { MoneyNum = 0, MoneyTake = false } } },  // Уровень 3
        new Level { levelInfos = new LevelInfo[] { new LevelInfo { MoneyNum = 0, MoneyTake = false } } },  // Уровень 4
        new Level { levelInfos = new LevelInfo[] { new LevelInfo { MoneyNum = 0, MoneyTake = false }, new LevelInfo { MoneyNum = 1, MoneyTake = false }, new LevelInfo { MoneyNum = 2, MoneyTake = false } } },  // Уровень 5
        new Level { levelInfos = new LevelInfo[] { new LevelInfo { MoneyNum = 0, MoneyTake = false } } },  // Уровень 6      
    };
}
