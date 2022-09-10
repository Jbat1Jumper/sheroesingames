using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject card;
    SpriteRenderer sr;
    public CardLogic cl;


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
   

    }
    
}