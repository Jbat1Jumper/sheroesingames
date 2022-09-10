using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardResult {
    public int Stat1Change;
}

public class Card : MonoBehaviour
{
    public CardDefinition Definition;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Definition.SpriteNormal;
    }
}

[System.Serializable]
public class CardDefinition
{
    public Sprite SpriteNormal;
    public Sprite SpriteLeft;
    public Sprite SpriteRight;

    public CardResult LeftResult;

    public CardResult RightResult;
}
