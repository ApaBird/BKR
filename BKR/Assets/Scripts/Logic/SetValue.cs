using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour, ILogicComponent
{
    [SerializeField] private List<string> values = new List<string>();
    private int selectedElement;
    private float value = 0;
    private RobotComponent component;
    public RobotComponent Component { get { return component; } set { component = value; } }
    public void Action()
    {
        component.SetValue(values[selectedElement], value);
    }

    private void Start()
    {
        values = component.GetListKey();
    }

}
