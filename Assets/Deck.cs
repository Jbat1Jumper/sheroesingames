using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    Stack<Card> Cards = new Stack<Card>();

    public Card GetNextCard()
    {
        if (Cards.Count > 0) {
            Debug.Log("Poppin Card");
            return Cards.Pop();
        }
        Debug.Log("No more cards");
        return null;
    }

    public void Start()
    {
        var cards = GetComponentsInChildren<Card>();
        // TODO: Actually shuffle cards
        Cards = new Stack<Card>(cards);
    }
}
