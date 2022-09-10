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
}

[System.Serializable]
public class CardDefinition
{
    public CardResult LeftResult;

    public CardResult RightResult;
}
