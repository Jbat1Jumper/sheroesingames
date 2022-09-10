using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    Stack<CardDefinition> Cards = new Stack<CardDefinition>();

    public CardDefinition GetNextCard()
    {
        if (Cards.Count > 0) {
            return Cards.Pop();
        }
        return null;
    }

    public void ShuffleDeck()
    {
        // TODO: Actually shuffle cards
        Cards = new Stack<CardDefinition>(InitialCards);
    }

    List<CardDefinition> InitialCards = new List<CardDefinition>() {
        new CardDefinition() {
            LeftResult = new CardResult() {
                Stat1Change = 1,
            },
            RightResult = new CardResult() {
                Stat1Change = -1,
            },
        },
        new CardDefinition() {
            LeftResult = new CardResult() {
                Stat1Change = 2,
            },
            RightResult = new CardResult() {
                Stat1Change = -2,
            },
        },
        new CardDefinition() {
            LeftResult = new CardResult() {
                Stat1Change = 3,
            },
            RightResult = new CardResult() {
                Stat1Change = -3,
            },
        },
    };

}
