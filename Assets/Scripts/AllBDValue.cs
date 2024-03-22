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

public class Level
{
    public LevelInfo[] levelInfos { get; set; }
}