using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : MonoBehaviour
{
    public int Stat1 = 5;

    public CardDefinition CurrentCard;

    public UnityEvent<int> OnStat1Changed;

    public void SwipeLeft()
    {
        Debug.Log("Swipe Left");
        ApplyResult(CurrentCard.LeftResult);
    }

    public void SwipeRight()
    {
        Debug.Log("Swipe Right");
        ApplyResult(CurrentCard.RightResult);
    }

    public void ApplyResult(CardDefinition.CardResult result)
    {
        if (result.Stat1Change != 0) {
            Stat1 += result.Stat1Change;
            OnStat1Changed.Invoke(Stat1);
            Debug.Log("Triggering Stat1 Change");
        }
    }
}
