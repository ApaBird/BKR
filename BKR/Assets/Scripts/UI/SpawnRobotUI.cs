using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRobotUI : SpawnRobot
{
    [SerializeField] private ComponentBar bar;

    private void Start()
    {
        foreach (GameObject component in base.prefabs)
        {
            component.GetComponent<SelectedComponent>().SetBar(bar);
        }
    }

    public void SetRobotUI(string path)
    {
        base.SetRobot(path);
        base.LoadRobot();
    }
}
