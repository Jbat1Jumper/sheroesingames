using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStatIndicator : MonoBehaviour
{
    private string TemplateString;
    private string ValueString;
    private Text Text;

    public void Start()
    {
        Text = GetComponent<Text>();
    }

    private void GrabTemplateText()
    {
        Text = GetComponent<Text>();
        TemplateString = Text.text;
        ValueString = Text.text;
    }

    public void SetStatValue(int newValue)
    {
        if (TemplateString == null)
            GrabTemplateText();

        ValueString = string.Format(TemplateString, newValue);
        Text.text = ValueString;
    }

    public void SetChangePreview(int change)
    {
        if (TemplateString == null)
            GrabTemplateText();

        if (change > 0)
        {
            Text.text = string.Format("{0} (+{1})", ValueString, change);
        }
        else if (change < 0)
        {
            Text.text = string.Format("{0} ({1})", ValueString, change);
        }
    }
}
