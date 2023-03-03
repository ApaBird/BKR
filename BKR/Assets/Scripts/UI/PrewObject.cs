using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrewObject : IClickComponent, IElementBar
{
    [SerializeField] public GameObject original;

    public GameObject GetElement()
    {
        return this.gameObject;
    }

    public override GameObject Select(Camera cam)
    {
        GameObject detail = Instantiate<GameObject>(original);
        detail.transform.position = cam.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(cam.transform.position.z));
        detail.GetComponent<Control>().Select(cam);
        return detail;
    }

    public override void Unselect()
    {
        throw new System.NotImplementedException();
    }

}
