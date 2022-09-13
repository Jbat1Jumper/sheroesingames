using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Situation Definition;
    TextMeshPro Text;

    public void Start()
    {
        Text = GetComponentInChildren<TextMeshPro>();
        GetComponent<SpriteRenderer>().sprite = Definition.CardSprite;
        SetCenterText();
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
        Text.fontSize = 12;
        Text.text = Definition.LeftResult.ActionText;
    }

    public void SetRightText()
    {
        Text.fontSize = 12;
        Text.text = Definition.RightResult.ActionText;
    }

    public void SetCenterText()
    {
        Text.fontSize = 8;
        Text.text = Definition.SituationText;
    }
}

[System.Serializable]
public class Situation
{
    public string Id;

    public Outcome LeftResult;
    public Outcome RightResult;
    public Sprite CardSprite;
    public string SituationText;
}



[System.Serializable]
public class Outcome {
    public string Id;
    public int EnergyChange;
    public int MoodChange;
    public int EmpowermentChange;

    public string ActionText;
    public string OutcomeDescription;
}

