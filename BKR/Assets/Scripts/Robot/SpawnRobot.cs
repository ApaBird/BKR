using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnRobot : MonoBehaviour
{
    private string path = "";
    [SerializeField] protected List<GameObject> prefabs;

    private void Start()
    {
        LoadRobot();
    }

    public void SetRobot(string p)
    {
        path = p;
        LoadRobot();
    }

    public void LoadRobot()
    {
        Transform[] des = GetComponentsInChildren<Transform>();
        foreach(Transform t in des) { 
            if (this.gameObject != t.gameObject)
                Destroy(t.gameObject); 
        }

        float sizeX = this.transform.localScale.x, sizeY = this.transform.localScale.y, sizeZ = this.transform.localScale.z;
        this.transform.localScale = Vector3.one;
        Debug.Log(path);
        StreamReader file = new StreamReader(path);
        Robot rorbot =  JsonUtility.FromJson<Robot>(file.ReadLine());
        Vector3 center = Vector3.zero;
        foreach (ComponentInfo a in rorbot.components)
        {
            if (a.Name == "Proc")
            {
                center = this.transform.position - a.Position;
                break;
            }
        }
        foreach (ComponentInfo a in rorbot.components)
        {
            GameObject prefab = null;
            foreach (GameObject el in prefabs)
                if (el.GetComponent<SavedObject>().GetName() == a.Name)
                {
                    prefab = el;
                    break;
                }
            GameObject component = Instantiate<GameObject>(prefab, a.Position + center, a.Rotate);
            component.transform.parent = this.transform;
            Destroy(component.GetComponent<Control>());
        }
        this.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }
}
