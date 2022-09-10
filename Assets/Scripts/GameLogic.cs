using System;
using TMPro;
using UnityEditor.Tilemaps;
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
    [SerializeField]  string prueba;

    // Start is called before the first frame update
    void Start()
    {
      
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
          
        }

        if (card.transform.position.x > 1)
        {
            textObject.text = prueba;
        }
        else if (card.transform.position.x < -1)
        {
          
        }
        else
        {
         
        }
    }
}