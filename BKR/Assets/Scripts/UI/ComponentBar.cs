using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComponentBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> components = new List<GameObject>();
    private List<GameObject> oldComponent = new List<GameObject>();
    [SerializeField] private int sizeCell;
    [SerializeField] private bool horizontal = false;
    private RectTransform rect;
    private RobotComponent robotComponent;
    Vector2 lastPos;

    private void Start()
    {
        UpdateBar();
    }

    public void UpdateComponentList(List<GameObject> list, RobotComponent robotComp)
    {
        robotComponent = robotComp;
        components = list;
        UpdateBar();
    }

    private void UpdateBar()
    {
        foreach(GameObject t in oldComponent) { Destroy(t); }

        rect = this.GetComponent<RectTransform>();
        int i = 0;
        foreach (GameObject a in components)
        {
            if (a.GetComponent<IElementBar>() != null)
            {
                oldComponent.Add(Instantiate(a.GetComponent<IElementBar>().GetElement(), rect));
                if (a.GetComponent<ILogicComponent>())//костыль
                    oldComponent[i].GetComponent<PrewObject>().original = a.gameObject;
                oldComponent[i].GetComponent<PrewObject>().SetRobotComponent(robotComponent);
                oldComponent[i].GetComponent<RectTransform>().anchoredPosition += (horizontal?Vector2.down:Vector2.right) * i * sizeCell;
                oldComponent[i].GetComponent<RectTransform>().anchoredPosition3D += new Vector3(0, 0, -0.1f);
                oldComponent[i].transform.parent = this.transform;
                i += 1;
            }
        }
    }
}
