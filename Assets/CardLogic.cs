using UnityEngine;

public class CardLogic : MonoBehaviour
{
    public bool isMouseOver = false;
    
    private void OnMouseOver()
    {
        isMouseOver = true;

    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }

}
