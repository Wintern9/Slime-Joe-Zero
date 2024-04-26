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
        string dbPath = Application.persistentDataPath + "/mydatabase.db";
        if (!File.Exists(dbPath))
        {          
            connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            FirstEntryGame();
        }else{connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite);}
        FirstEntryGame();
        settings = new Settings();
    }
    void Start()
    {
        settings.SetValueToLevel(CreateLevelList());
    }

    void FirstEntryGame()
    {
        connection.CreateTable<LevelInfoBD>();
        foreach (LevelInfoBD levelInfoBD in ParseListLevelInfo())
            connection.Insert(levelInfoBD);
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
        List<Level> level = new Level();
        List<LevelInfoBD> levelInfo = connection.Table<LevelInfoBD>().ToList();
        foreach(var levelInfoBD in levelInfo)
        {
            level.Add()
        }


        return connection.Table<LevelInfoBD>().ToList();
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
