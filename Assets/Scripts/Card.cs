using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardResult {
    public int EnergyChange;
    public int MoodChange;
}

public class Card : MonoBehaviour
{
    public CardDefinition Definition;
    public void Start()
    {
   
        GetComponent<SpriteRenderer>().sprite = Definition.SpriteNormal;
    }
    public bool isMouseOver = false;
    
    private void OnMouseOver()
    {
        isMouseOver = true;

    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}

[System.Serializable]
public class CardDefinition
{
    public Sprite SpriteNormal;
    public Sprite SpriteLeft;
    public Sprite SpriteRight;
    public String TextNormal;
    public String TextLeft;
    public String TextRight;
    public CardResult LeftResult;

    public CardResult RightResult;
}
