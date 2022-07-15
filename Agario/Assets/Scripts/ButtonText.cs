using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text textObject;
    public RequestServerTime RST;

    public void SetText(string text)
    {
        textObject.text = text;
    }
}
