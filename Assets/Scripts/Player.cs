using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public const int MAX_STAT_VALUE = 10;


    public int Energy = 5;
    public int Mood = 5;
    public int Empowerment = 0;

    public Card CurrentCard;
    public Deck Deck;

    public UnityEvent<int> OnEnergyChanged;
    public UnityEvent<int> OnEnergyChangePreview;

    public UnityEvent<int> OnMoodChanged;
    public UnityEvent<int> OnMoodChangePreview;

    public UnityEvent<int> OnEmpowermentChanged;
    public UnityEvent<int> OnEmpowermentChangePreview;

    private SoundController Sounds;

    public void Start()
    {
        Sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundController>();
        PullNextCard();
        EmitCurrentStats();
    }


    #region Interaction From Card Swipe

    public void PickUp()
    {
        Debug.Log("Pick Up");
        Sounds.PlayPickUp();
        EmitCurrentStats();
    }

    public void PreviewLeft()
    {
        Debug.Log("Preview Left");
        PreviewResult(CurrentCard.Definition.LeftResult);
        CurrentCard.SetLeftText();
        Sounds.PlayPreviewLeft();
    }

    public void PreviewRight()
    {
        Debug.Log("Preview Right");
        PreviewResult(CurrentCard.Definition.RightResult);
        CurrentCard.SetRightText();
        Sounds.PlayPreviewRight();
    }

    public void MovedBackToCenter()
    {
        Debug.Log("Move Back To Center");
        EmitCurrentStats();
        CurrentCard.SetNormalText();
    }

    public void SwipeLeft()
    {
        Debug.Log("Swipe Left");
        Sounds.PlaySwipeLeft();
        ApplyResult(CurrentCard.Definition.LeftResult);
    }

    public void SwipeRight()
    {
        Debug.Log("Swipe Right");
        Sounds.PlaySwipeRight();
        ApplyResult(CurrentCard.Definition.RightResult);
    }

    public void DropDown()
    {
        Debug.Log("Drop Down");
        Sounds.PlayDropDown();
    }

    #endregion



    private void PreviewResult(CardResult result)
    {
        OnEnergyChangePreview.Invoke(result.EnergyChange);
        OnMoodChangePreview.Invoke(result.MoodChange);
        OnEmpowermentChangePreview.Invoke(result.EmpowermentChange);
    }

    private void EmitCurrentStats()
    {
        OnEnergyChanged.Invoke(Energy);
        OnMoodChanged.Invoke(Mood);
        OnEmpowermentChanged.Invoke(Empowerment);
    }

    private void ApplyResult(CardResult result)
    {
        Energy += result.EnergyChange;
        Mood += result.MoodChange;
        Empowerment += result.EmpowermentChange;

        EmitCurrentStats();

        // Maybe yield until animation
        PullNextCard();
    }

    private void PullNextCard()
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

    private void PlaceCardInCenter(Card card)
    {
        card.transform.position = Vector3.zero;
        card.GetComponent<GameLogic>().CurrentState = CardState.Entering;
    }

    private void NoMoreCards()
    {
        Debug.Log("No more cards");
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("EndScene");
    }
}
