using System.Collections.Generic;
using UnityEngine;

public enum Language {
    Spanish,
    English,
    Deutsch,
}

public static class Translations
{
    public static Language CurrentLanguage = Language.Spanish;

    public static Table GameData;
    private static Dictionary<string, string> Texts;

    public static void ChangeLanguage(Language language)
    {
        if (GameData != null && language == CurrentLanguage)
            return;

        CurrentLanguage = language;

        GameData = Table.Load("Tablas/Tareas SHEROES - Narrativa.tsv");
        switch (language)
        {
            case Language.Deutsch:
                GameData.MergeWith(
                    Table.Load("Tablas/Tareas SHEROES - Narrativa auf Deutsch.tsv")
                );
                break;
            case Language.English:
                GameData.MergeWith(
                    Table.Load("Tablas/Tareas SHEROES - Narrativa en ingles.tsv")
                );
                break;
        }

        Texts = new Dictionary<string, string>();
        var rawTexts = Table.Load("Tablas/Tareas SHEROES - Traducciones Varias.tsv");
        var lang = LanguageColumn(language);
        foreach (var row in rawTexts.Rows) {
            Texts.Add(row["key"], row[lang]);
        }
    }

    private static string LanguageColumn(Language language) {
        switch (language)
        {
            case Language.Spanish:
                return "spanish";
            case Language.Deutsch:
                return "deutsch";
            case Language.English:
                return "english";
        }
        return "";
    }
}
