using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum CardState {
    Hidden,
    Entering,
    Idle,
    Lifted,
    Swiping,
}

public enum CardSide {
    Center,
    Left,
    Right,
}


public class GameLogic : MonoBehaviour
{
    public GameObject card;
    Card cl;
    public float fMovingSpeed = 1f;
    private Player player;

    public CardState CurrentState = CardState.Hidden;
    
    // Start is called before the first frame update
    void Start()
    {
        cl = card.GetComponent<Card>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

   
    private CardSide PreviousSide = CardSide.Center;
    private CardSide CurrentSide {
        get {
            if (card.transform.position.x > 1)
            {
                return CardSide.Right;
            }
            else if (card.transform.position.x < -1)
            {
                return CardSide.Left;
            }
            else
            {
                return CardSide.Center;
            }
        }
    }

    private bool BeingDraggedWithTheMouse => Input.GetMouseButton(0) && cl.IsMouseOver;

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        if (PreviousSide != CurrentSide) {
            OnSideChanged();
            PreviousSide = CurrentSide;
        }

        UpdateCardPosition();
    }

    void OnSideChanged() {
        if (CurrentState == CardState.Lifted) {
            switch (CurrentSide) {
                case CardSide.Left:
                    player.PreviewLeft();
                    break;
                case CardSide.Right:
                    player.PreviewRight();
                    break;
                case CardSide.Center:
                    player.MovedBackToCenter();
                    break;
            }
        }
    }

    void UpdateState() {
        switch (CurrentState) {
            case CardState.Entering:
                CurrentState = CardState.Idle;
                break;
            case CardState.Lifted:
                if (!BeingDraggedWithTheMouse) {
                    switch (CurrentSide) {
                        case CardSide.Left:
                            player.SwipeLeft();
                            CurrentState = CardState.Swiping;
                            break;
                        case CardSide.Right:
                            player.SwipeRight();
                            CurrentState = CardState.Swiping;
                            break;
                        case CardSide.Center:
                            player.DropDown();
                            CurrentState = CardState.Idle;
                            break;
                    }
                }
                break;

            case CardState.Idle:
                if (BeingDraggedWithTheMouse) {
                    CurrentState = CardState.Lifted;
                    player.PickUp();
                }
                break;
        }
    }

    void UpdateCardPosition() {
        switch (CurrentState)
        {
            case CardState.Lifted:
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                card.transform.position = pos;
                break;
            case CardState.Idle:
                card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0, 0), fMovingSpeed);
                break;
        }
    }
}