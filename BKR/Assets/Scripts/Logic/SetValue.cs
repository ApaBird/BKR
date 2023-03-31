using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : ILogicComponent, IElementBar
{
    [SerializeField] private DropBox dropBox;
    [SerializeField] private TextBox prew;
    private float value = 0;

    public override void Action()
    {
        base.component.SetValue(dropBox.GetValue(), value);
    }

    public GameObject GetElement()
    {
        return prew.gameObject;
    }

    private void Start()
    {
        values = base.component.GetListKey();
        prew.SetText("Set Value");
        prew.gameObject.GetComponent<PrewObject>().original = this.gameObject;
        dropBox.SetList(values);
    }

}
