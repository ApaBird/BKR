using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedComponent : IClickComponent
{
    [SerializeField] private ComponentBar bar;
    [SerializeField] private List<GameObject> logicComponent = new List<GameObject>();
    public override GameObject Select(Camera cam)
    {
        bar.UpdateComponentList(logicComponent);
        return null;
    }

    public override void Unselect()
    {
        throw new System.NotImplementedException();
    }

    
}
