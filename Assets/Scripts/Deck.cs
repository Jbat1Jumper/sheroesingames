using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Deck : MonoBehaviour
{
    Stack<Card> Cards = new Stack<Card>();

    private bool isInitialize = false;
    public Card GetNextCard()
    {
        if (!isInitialize)
        {
            InitializeCards();
            isInitialize = true;
        }
        if (Cards.Count > 0) {
            Debug.Log("Poppin Card");
            return Cards.Pop();
        }
        
        Debug.Log("No more cards");
        return null;
    }

    public void InitializeCards()
    {
        var cards = GetComponentsInChildren<Card>();
 
        Debug.Log(string.Format("Initialized {0} Cards", cards.Length));
        // TODO: Actually shuffle cards
        List<Card> wholeDeck = new List<Card>(cards);
        Random r = new Random((int)Time.time);
            
            while (wholeDeck.Count > 0) 
            {
            var aCard = wholeDeck[r.Next(0,wholeDeck.Count)];     // grab a random card
            Cards.Push(aCard);                              // push it on the stack
            wholeDeck.Remove(aCard);                              // remove it from the original list
        }
       
    }
}
