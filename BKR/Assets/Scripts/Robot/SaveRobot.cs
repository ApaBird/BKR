using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveRobot : MonoBehaviour
{
    public void Save(TMP_Text name)
    {
        if (name.text.Length > 1)
            Save(name.text);
        else
            Debug.Log("Нет имени!");
    }

    public void Save(string robotName)
    {
        GameObject[] components = GameObject.FindGameObjectsWithTag("RobotComponent");
        bool saved = false;
        if(components.Length != 0)
        {
            foreach(GameObject component in components )
            {
                if(component.GetComponent<SavedObject>().Save().Name == "Proc")
                {
                    saved = true;
                    break;
                }
            }
        }

        if (!saved)
        {
            Debug.Log("Not Save");
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
            StreamWriter file = new StreamWriter("Robots/" + robotName + ".json", false);
            file.Write(JsonUtility.ToJson(new Robot{components = json}));
            file.Close();
        }
    }
}
