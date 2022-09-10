using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Energy = 5;
    public int Mood = 5;

    public Card CurrentCard;
    public Deck Deck;

    public UnityEvent<int> OnEnergyChanged;
    public UnityEvent<int> OnMoodChanged;

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
        if (result.EnergyChange != 0) {
            Energy += result.EnergyChange;
            OnEnergyChanged.Invoke(Energy);
            Debug.Log("Triggering Stat1 Change");
        }

        if (result.MoodChange != 0) {
            Mood += result.MoodChange;
            OnMoodChanged.Invoke(Mood);
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
        card.GetComponent<GameLogic>().onScreen = true;
    }

    public void NoMoreCards()
    {
        Debug.Log("No more cards");
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("MenuScene");
    }
}
