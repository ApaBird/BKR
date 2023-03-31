using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedComponent : IClickComponent
{
    [SerializeField] private ComponentBar bar;
    [SerializeField] private List<GameObject> logicComponent = new List<GameObject>();
    [SerializeField] private RobotComponent original; 

    private void Start()
    {
        foreach (GameObject logic in logicComponent)
        {
            logic.GetComponent<ILogicComponent>().Component = original;
        }
    }

    public override GameObject Select(Camera cam)
    {
        bar.UpdateComponentList(logicComponent, original);
        return null;
    }

    public void SetBar(ComponentBar b) => bar = b;

    public override void Unselect()
    {
        throw new System.NotImplementedException();
    }

    
}
