using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour, ILogicComponent, IElementBar
{
    [SerializeField] private List<string> values = new List<string>();
    [SerializeField] private DropBox dropBox;
    [SerializeField] private TextBox prew;
    private float value = 0;
    private RobotComponent component;
    public RobotComponent Component { get { return component; } set { component = value; } }

    public void Action()
    {
        component.SetValue(dropBox.GetValue(), value);
    }

    public GameObject GetElement()
    {
        return prew.gameObject;
    }

    private void Start()
    {
        //values = component.GetListKey();
        prew.SetText("Set Value");
        prew.gameObject.AddComponent<PrewObject>();
        prew.gameObject.GetComponent<PrewObject>().original = this.gameObject;
        dropBox.SetList(values);
    }

}
