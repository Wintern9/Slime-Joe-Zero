public class LanguageScript
{ 
    static public Language[] language = new Language[] {
        new Language() { localization = new string[] { "English", "�������" } },
        new Language() { localization = new string[] { "SETTINGS", "���������" } },
        new Language() { localization = new string[] { "Music", "������" } },
        new Language() { localization = new string[] { "Sounds", "�����" } },
        new Language() { localization = new string[] { "Language", "����" } },
        new Language() { localization = new string[] { ">> Character Control <<", ">> ���������� ���������� <<" } },
        new Language() { localization = new string[] { "On", "���." } },
        new Language() { localization = new string[] { "Off", "����." } },
        new Language() { localization = new string[] { "Wind Lore", "������� � �����" } },
    };
}

[System.Serializable]
public class Language // ������� ����� Language ���������
{
    public string[] localization { get; set; }
}
