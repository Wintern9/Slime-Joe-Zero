public class LanguageScript
{
    public class Language // Сделаем класс Language публичным
    {
        public string[] localization { get; set; }
    }

    public Language[] language = new Language[] { 
        new Language() { localization = new string[] { "Settings", "Настройки" } },
        new Language() { localization = new string[] { "Settings", "Настройки" } }
    };
}
