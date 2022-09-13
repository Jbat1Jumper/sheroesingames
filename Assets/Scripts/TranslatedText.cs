using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslatedText : MonoBehaviour
{
    string Key;
    TextMeshProUGUI TMP;
    Language CurrentLanguage;

    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
        Key = TMP.text;
        CurrentLanguage = Translations.CurrentLanguage;
        TMP.text = Translations.For(Key);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentLanguage != Translations.CurrentLanguage) {
            CurrentLanguage = Translations.CurrentLanguage;
            TMP.text = Translations.For(Key);
        }
    }
}
