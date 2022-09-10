using UnityEditor.Tilemaps;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject card;
    SpriteRenderer sr;
    public Card cl;
    public float fMovingSpeed = 1f;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();
        cl = card.GetComponent<Card>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
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
            sr.sprite = card.GetComponent<Card>().Definition.SpriteRight;
        }
        else if (card.transform.position.x < -1)
        {
            sr.sprite = card.GetComponent<Card>().Definition.SpriteLeft;
        }
        else
        {
            sr.sprite = card.GetComponent<Card>().Definition.SpriteNormal;
        }
    }
}