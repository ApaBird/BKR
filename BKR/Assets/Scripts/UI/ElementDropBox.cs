using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class ElementDropBox : IClickComponent
{
    [SerializeField] private TMP_Text text;

    public override GameObject Select(Camera cam)
    {
        gameObject.GetComponentInParent<DropBox>().ChioceElement(text.text);
        return null;
    }

    public void SetText(string t)
    {
        text.text = t;
    }

    public override void Unselect()
    {
        throw new System.NotImplementedException();
    }
}
