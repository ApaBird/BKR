using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnRobot : MonoBehaviour
{
    private string path = "Robot1.json";
    [SerializeField] private List<GameObject> prefabs;

    private void Start()
    {
        LoadRobot();
    }

    public void SetRobot(string p) => path = p;

    public void LoadRobot()
    {
        StreamReader file = new StreamReader(path);
        Robot b =  JsonUtility.FromJson<Robot>(file.ReadLine());
        Vector3 center = Vector3.zero;
        foreach (ComponentInfo a in b.components)
        {
            if (a.Name == "Proc")
            {
                center = this.transform.position - a.Position;
                break;
            }
        }
        foreach (ComponentInfo a in b.components)
        {
            GameObject prefab = null;
            foreach (GameObject el in prefabs)
                if (el.GetComponent<IRobotComponent>().GetName() == a.Name)
                {
                    prefab = el;
                    break;
                }
            Instantiate<GameObject>(prefab, a.Position + center, a.Rotate).transform.parent = this.transform;
        }
    }
}
