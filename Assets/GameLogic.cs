using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject card;
    SpriteRenderer sr;
    public CardLogic cl;
public float fMovingSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();
        cl = card.GetComponent<CardLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&& cl.isMouseOver)
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        card.transform.position = pos;
    }
    else
    {
        card.transform.position = Vector2.MoveTowards(card.transform.position, new Vector2(0,0),fMovingSpeed);
    }

        if (card.transform.position.x >1)
        {
            sr.color = Color.green;
        }else if (card.transform.position.x <-1)
        {
            sr.color = Color.red;
        }
        else
        {
            sr.color = Color.white;
        }

    }
    
}