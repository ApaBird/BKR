using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveRobot : object
{
    public static string Save(string robotName)
    {
        GameObject[] components = GameObject.FindGameObjectsWithTag("RobotComponent");

        if (components.Length == 0)
        {
            Debug.Log("Not Save");
            return "Not Save";
        }
        else
        {
            ComponentInfo[] json = new ComponentInfo[components.Length];
            int iter = 0;
            foreach (GameObject component in components)
            {
                Debug.Log(JsonUtility.ToJson(component.GetComponent<SavedObject>().Save()));
                json[iter] = component.GetComponent<SavedObject>().Save();
                iter++;
            }
            StreamWriter file = new StreamWriter(robotName + ".json", false);
            file.Write(JsonUtility.ToJson(new Robot{components = json}));
            file.Close();
            return "Save";
        }
    }
}
