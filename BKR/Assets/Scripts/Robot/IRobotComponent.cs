using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotComponent: MonoBehaviour
{
    [SerializeField] protected Dictionary<string, float> dictValues = new Dictionary<string, float>();

    public abstract List<string> GetListKey();

    public void SetValue(string key, float value)
    {
        dictValues[key] = value;
    }

}
