using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageSystemBehaviour : MonoBehaviour
{
    public Text text;

    public void TypeMessage(string message)
    {
        message = text.text;
    }
}
