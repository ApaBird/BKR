using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrewRobotElement : MonoBehaviour
{
    [SerializeField] private SpawnRobot robot;
    [SerializeField] private TMP_Text fieldName;
    private string path;
    private MenuRobots menu;

    public void SetMenuRobots(MenuRobots m) => menu = m;

    public void SetPath(string path)
    {
        this.path = path;
        robot.SetRobot(path);
        fieldName.text = path.Substring(path.LastIndexOf('/') + 1, path.LastIndexOf(".json") - 6);
    }

    public void SelectRobot()
    {
        menu.SetRobot(path);
    }
}
