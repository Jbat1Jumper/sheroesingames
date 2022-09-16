using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatedCV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"CV {Translations.CurrentLanguageString}");
    }
}
