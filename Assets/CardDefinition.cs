using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDefinition : MonoBehaviour
{
    [System.Serializable]
    public class CardResult {
        public int Stat1Change;
    }

    public CardResult LeftResult;

    public CardResult RightResult;
}
