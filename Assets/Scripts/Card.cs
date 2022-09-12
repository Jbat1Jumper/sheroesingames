using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class CardResult {
    public int EnergyChange;
    public int MoodChange;
    public int EmpowermentChange;
}

public class Card : MonoBehaviour
{
    public CardDefinition Definition;
    TextMeshPro Text;

    public void Start()
    {
        Text = GetComponentInChildren<TextMeshPro>();
        GetComponent<SpriteRenderer>().sprite = Definition.SpriteNormal;
        SetNormalText();
    }
    public bool IsMouseOver = false;
    
    private void OnMouseOver()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }

    public void SetLeftText()
    {
        // TODO: Revisar esto, puede que lo haya puesto al revez 
        Text.fontSize = 12;
        Text.text = Translations.Get(Definition.id+"A");
    }

    public void SetRightText()
    {
        Text.fontSize = 12;
        Text.text = Translations.Get(Definition.id+"B");
    }

    public void SetNormalText()
    {
        Text.fontSize = 8;
        Text.text = Translations.Get(Definition.id);
    }
}

[System.Serializable]
public class CardDefinition
{
    public Sprite SpriteNormal;

    public string id;

    public CardResult LeftResult;

    public CardResult RightResult;
}
