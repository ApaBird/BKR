using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTextBox : IClickComponent
{
    [SerializeField] private TMP_Text text;
    private bool selected = false;
    public override GameObject Select(Camera cam)
    {
        selected = true;
        text.text = "";
        return null;
    }

    public override void Unselect()
    {
        selected = false;
    }

    private void Update()
    {
        if(selected)
        {
            //реагирует на все клавиши включая backspace, esc и т.д. как на символ
            text.text += Input.inputString;
        }
    }

}
