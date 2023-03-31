using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ILogicComponent: MonoBehaviour
{
    [SerializeField] protected List<string> values = new List<string>();
    [SerializeField] protected RobotComponent component;
    public RobotComponent Component { get { return component; } set { component = value; } }

    public abstract void Action();

}
