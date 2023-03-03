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
            //��������� �� ��� ������� ������� backspace, esc � �.�. ��� �� ������
            text.text += Input.inputString;
        }
    }

}
