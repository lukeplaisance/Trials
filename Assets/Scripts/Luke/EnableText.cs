using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableText : ScriptableObject
{
    public Text text;

    public void ShowText()
    {
        text.enabled = true;
    }
}
