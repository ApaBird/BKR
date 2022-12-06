using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IClickComponent: MonoBehaviour
{
    abstract public void Unselect();

    abstract public GameObject Select(Camera cam);
}
