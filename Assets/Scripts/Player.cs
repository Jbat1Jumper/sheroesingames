using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int Stat1 = 5;

    public Card CurrentCard;
    public Deck Deck;

    public UnityEvent<int> OnStat1Changed;

    public void Start()
    {
        //PullNextCard();
    }

    public void SwipeLeft()
    {
        Debug.Log("Swipe Left");
        ApplyResult(CurrentCard.Definition.LeftResult);
    }

    public void SwipeRight()
    {
        Debug.Log("Swipe Right");
        ApplyResult(CurrentCard.Definition.RightResult);
    }

    public void ApplyResult(CardResult result)
    {
        if (result.Stat1Change != 0) {
            Stat1 += result.Stat1Change;
            OnStat1Changed.Invoke(Stat1);
            Debug.Log("Triggering Stat1 Change");
        }

        // Maybe yield until animation
        PullNextCard();
    }

    public void PullNextCard()
    {
        if (CurrentCard != null) {
            Destroy(CurrentCard.gameObject);
        }

        var card = Deck.GetNextCard();
        if (card != null) {
            PlaceCardInCenter(card);
            CurrentCard = card;
        } else {
            NoMoreCards();
        }
    }

    public void PlaceCardInCenter(Card card)
    {
        card.transform.position = Vector3.zero;
    }

    public void NoMoreCards()
    {
        Debug.Log("No more cards");
        Debug.Log("GAME OVER");
    }
}
