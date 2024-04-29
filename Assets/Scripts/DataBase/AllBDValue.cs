using SQLite4Unity3d;

public class Skin
{
    public int SkinID { get; set; }
    public int SkinMoney { get; set; }
}

public class LevelInfo
{
    public int MoneyNum { get; set; }
    public bool MoneyTake { get; set; }
}

public class LevelInfoBD
{
    [PrimaryKey, AutoIncrement]
    public int IdLevelInfoDB { get; set; }

    public int MoneyNum { get; set; }
    public int MoneyTake { get; set; }
}

public class Level
{
    public LevelInfo[] levelInfos { get; set; }
}

public class PlayerInfo
{
    [PrimaryKey, AutoIncrement]
    public int IdPlayer { get; set; }

    public int Coin { get; set; }
}

public class ScinColection
{
    [PrimaryKey, AutoIncrement]
    public int IdScinCollection { get; set; }

    public int SkinOpens { get; set; }
}

public class LevelComplite
{
    [PrimaryKey, AutoIncrement]
    public int LevelId { get; set; }

    public string LevelComplites { get; set; }
}