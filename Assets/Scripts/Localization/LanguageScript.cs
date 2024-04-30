public class LanguageScript
{ 
    static public Language[] language = new Language[] {
        new Language() { localization = new string[] { "English", "Русский" } },
        new Language() { localization = new string[] { "SETTINGS", "НАСТРОЙКИ" } },
        new Language() { localization = new string[] { "Music", "Музыка" } },
        new Language() { localization = new string[] { "Sounds", "Звуки" } },
        new Language() { localization = new string[] { "Language", "Язык" } },
        new Language() { localization = new string[] { ">> Character Control <<", ">> Управление персонажем <<" } },
        new Language() { localization = new string[] { "On", "Вкл." } },
        new Language() { localization = new string[] { "Off", "Выкл." } },
        new Language() { localization = new string[] { "Wind Lore", "История о ветре" } },
    };
}

[System.Serializable]
public class Language // Сделаем класс Language публичным
{
    public string[] localization { get; set; }
}
