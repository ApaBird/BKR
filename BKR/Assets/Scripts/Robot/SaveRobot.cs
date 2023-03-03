using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveRobot : object
{
    public static string Save(string robotName)
    {
        GameObject[] components = GameObject.FindGameObjectsWithTag("RobotComponent");
        bool saved = false;
        if(components.Length != 0)
        {
            foreach(GameObject component in components )
            {
                if(component.GetComponent<SavedObject>().Save().Name == "Proc")
                {
                    Debug.Log("F");
                    saved = true;
                    break;
                }
            }
        }

        if (!saved)
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
