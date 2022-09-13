using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            ToggleVisibility();
        }
    }


    void ToggleVisibility() {
        GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
    }
}
