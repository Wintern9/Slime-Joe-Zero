using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.IO;
using static UnityEngine.EventSystems.EventTrigger;
using System.Linq;
using System;

public class ExtractDataBase : MonoBehaviour
{
    Settings settings;
    string dbPath;
    SQLiteConnection connection;

    private void Awake()
    {
        dbPath = Application.persistentDataPath + "/mydatabase.db";
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
        try
        {
            connection.Update(new PlayerInfo() { Coin = Coin });
        } catch
        {
            connection.CreateTable<PlayerInfo>();
            connection.Insert(new PlayerInfo() { Coin = Coin });
        }
    }

    public void LevelInfoUpdate(List<Level> level)
    {
        levels = level;
        connection.Update(ParseListLevelInfo());
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
