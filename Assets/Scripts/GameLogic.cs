using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameLogic : MonoBehaviour
{
    public GameObject card;
    Card cl;
    public float fMovingSpeed = 1f;
    private Player player;
    public bool onScreen = false;
    [SerializeField] TextMeshPro textObject;
    private SoundController sounds;

    private bool lastUpdateWasBeingDragged = false;
   
    
    // Start is called before the first frame update
    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundController>();
        sounds.PlayPickUp();
        sounds.PlayDrop();
      
        cl = card.GetComponent<Card>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        textObject = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!onScreen) return;

        if (Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            card.transform.position = pos;

            if (!lastUpdateWasBeingDragged)
            {
                sounds.PlayPickUp();
            }
            lastUpdateWasBeingDragged = true;
        }
        else
        {
            if (card.transform.position.x > 1)
            {
               player.SwipeRight();
               
            }
            else if (card.transform.position.x < -1)
            {
                player.SwipeLeft();
            }
            else
            {
                card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0, 0), fMovingSpeed);
            }
          
            if (lastUpdateWasBeingDragged)
            {
                sounds.PlayDrop();
            }
            lastUpdateWasBeingDragged = false;
        }

        if (card.transform.position.x > 1)
        {
            textObject.fontSize = 150;
            textObject.text = Translations.Get(cl.Definition.id+"A");
        }
        else if (card.transform.position.x < -1)
        {
            textObject.fontSize = 150;
            textObject.text = Translations.Get(cl.Definition.id+"B");
        }
        else
        {
            textObject.fontSize = 100;
            textObject.text = Translations.Get(cl.Definition.id);
        }

    }
}