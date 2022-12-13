using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnRobot : MonoBehaviour
{
    private string path = "Robot1.json";

    private void Start()
    {
        LoadRobot();
    }

    public void SetRobot(string p) => path = p;

    public void LoadRobot()
    {
        StreamReader file = new StreamReader(path);
        Dictionary<string,string> b =  JsonUtility.FromJson<Dictionary<string, string>>(file.ReadLine());
        foreach (KeyValuePair<string, string> a in b)
        {
            Debug.Log(a);
        }
    }
}
