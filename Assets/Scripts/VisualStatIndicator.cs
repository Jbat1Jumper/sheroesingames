using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualStatIndicator : MonoBehaviour
{
    public Sprite[] SpriteSheet;

    public void SetStatValue(int newValue)
    {
        var frame = (int)((((float)newValue) / Player.MAX_STAT_VALUE) * SpriteSheet.Length);
        GetComponent<SpriteRenderer>().sprite = SpriteSheet[frame];
    }
}
