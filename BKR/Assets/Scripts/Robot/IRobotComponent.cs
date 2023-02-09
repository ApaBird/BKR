using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotComponent: MonoBehaviour
{
    private static Dictionary<string, float> dictValues = new Dictionary<string, float>();

    public List<string> GetListKey()
    {
        List<string> list = new List<string>();
        foreach (KeyValuePair<string, float> i in dictValues)
        {
            list.Add(i.Key);
        }
        return list;
    }

    public void SetValue(string key, float value)
    {
        dictValues[key] = value;
    }

}
