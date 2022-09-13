using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class OutcomeDialog : MonoBehaviour
{

    TextMeshPro TMP;
    SpriteRenderer SpriteRenderer;
    Outcome Outcome;
    bool Visible = false;

    public UnityEvent<Outcome> Acknowledged;

    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponentInChildren<TextMeshPro>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Hide();
    }

    public void Show(Outcome outcome)
    {
        Visible = true;
        Outcome = outcome;
        TMP.color = new Color(TMP.color.r, TMP.color.g, TMP.color.b, 1f);
        TMP.faceColor = new Color(TMP.faceColor.r, TMP.faceColor.g, TMP.faceColor.b, 1f);
        Debug.Log($"Showing outcome description: {outcome.OutcomeDescription}");
        TMP.text = outcome.OutcomeDescription;
        SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, 1f);
    }

    public void Hide()
    {
        Visible = false;
        TMP.color = new Color(TMP.color.r, TMP.color.g, TMP.color.b, 0f);
        TMP.faceColor = new Color(TMP.faceColor.r, TMP.faceColor.g, TMP.faceColor.b, 0f);
        SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, 0f);
    }

    private void OnMouseDown()
    {
        if (Visible) {
            Hide();
            Acknowledged.Invoke(Outcome);
        }
    }
}
