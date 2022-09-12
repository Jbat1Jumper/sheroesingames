using UnityEngine;



public class CardSwiper : MonoBehaviour
{
    enum State {
        PlacingCard,
        Idle,
        Lifted,
        Empty,
    }

    enum CardSide {
        Center,
        Left,
        Right,
    }

    Card CurrentCard;
    private Player Player;
    public float fMovingSpeed = 1f;

    State CurrentState = State.Empty;

    public void PutCardAndStartInteraction(Card card, Player player)
    {
        Debug.Log("Putting Card in Swiper and Starting Interaction", card);
        CurrentCard = card;
        Player = player;
        CurrentState = State.PlacingCard;
    }

   
    private CardSide PreviousSide = CardSide.Center;
    private CardSide CurrentSide {
        get {
            if (CurrentCard.transform.position.x > 1)
            {
                return CardSide.Right;
            }
            else if (CurrentCard.transform.position.x < -1)
            {
                return CardSide.Left;
            }
            else
            {
                return CardSide.Center;
            }
        }
    }

    private bool BeingDraggedWithTheMouse => Input.GetMouseButton(0) && CurrentCard.IsMouseOver;

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        
        if (CurrentState != State.Empty)
        {
            if (PreviousSide != CurrentSide) {
                OnSideChanged();
            }
            PreviousSide = CurrentSide;
        }

        UpdateCardPosition();
    }

    void OnSideChanged() {
        if (CurrentState == State.Lifted) {
            switch (CurrentSide) {
                case CardSide.Left:
                    Player.PreviewLeft();
                    break;
                case CardSide.Right:
                    Player.PreviewRight();
                    break;
                case CardSide.Center:
                    Player.MovedBackToCenter();
                    break;
            }
        }
    }

    void UpdateState() {
        switch (CurrentState) {
            case State.PlacingCard:
                CurrentState = State.Idle;
                break;
            case State.Lifted:
                if (!BeingDraggedWithTheMouse) {
                    switch (CurrentSide) {
                        case CardSide.Left:
                            CurrentCard = null;
                            CurrentState = State.Empty;
                            Player.SwipeLeft();
                            break;
                        case CardSide.Right:
                            CurrentCard = null;
                            CurrentState = State.Empty;
                            Player.SwipeRight();
                            break;
                        case CardSide.Center:
                            Player.DropDown();
                            CurrentState = State.Idle;
                            break;
                    }
                }
                break;

            case State.Idle:
                if (BeingDraggedWithTheMouse) {
                    CurrentState = State.Lifted;
                    Player.PickUp();
                }
                break;
        }
    }

    void UpdateCardPosition() {
        switch (CurrentState)
        {
            case State.Lifted:
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CurrentCard.transform.position = pos;
                break;
            case State.Idle:
                CurrentCard.transform.position = transform.position;
                // CurrentCard.transform.position = Vector2.MoveTowards(CurrentCard.transform.position, transform.position, fMovingSpeed);
                break;
        }
    }
}