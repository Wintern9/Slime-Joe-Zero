public class LanguageScript
{
    public class Language // ������� ����� Language ���������
    {
        public string[] localization { get; set; }
    }

    public Language[] language = new Language[] { 
        new Language() { localization = new string[] { "Settings", "���������" } },
        new Language() { localization = new string[] { "Settings", "���������" } }
    };
}
