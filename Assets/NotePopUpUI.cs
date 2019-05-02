using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zach;

public class NotePopUpUI : MonoBehaviour
{
    public Text UIText;
    public void SetUIText(StringVariable stringVariable)
    {
        UIText.text = stringVariable.MaxValue.ToString();
    }
}
