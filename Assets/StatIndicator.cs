using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatIndicator : MonoBehaviour
{
    public string StatName;

    public void SetStatValue(int newValue) {
        var text = GetComponent<UnityEngine.UI.Text>();
        Debug.Log("Changing stat value");
        text.text = string.Format("{0}: {1}", StatName, newValue);
    }
}
