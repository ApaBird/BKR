using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void SetText(string str)
    {
        text.text = str;
    }
}
