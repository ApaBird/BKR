using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRobots : MonoBehaviour
{
    [SerializeField] private GameObject prefabUI;
    [SerializeField] private SpawnRobotUI robot;
    private string selectedRobot = "";
    private float offsetX = 0;
    private float offsetY = 1;

    public void SetRobot(string path) { 
        selectedRobot = path; 
        robot.SetRobotUI(selectedRobot);
    }

    void Start()
    {
        string[] robots = LoadAllRobots.GetRobotFiles();
        foreach (string pathRobot in robots)
        {
            GameObject a = Instantiate<GameObject>(prefabUI, this.transform);
            a.GetComponentInChildren<PrewRobotElement>().SetPath(pathRobot);
            a.GetComponentInChildren<PrewRobotElement>().SetMenuRobots(this);
            a.transform.parent = this.transform;
            a.GetComponent<RectTransform>().anchorMin = new Vector2(offsetX, offsetY - 0.4f);
            a.GetComponent<RectTransform>().anchorMax = new Vector2(offsetX + 0.18f, offsetY);
            offsetX += 0.2f;
            if(offsetX >= 1)
            {
                offsetX = 0;
                offsetY = 0.5f;
            }
        }
    }
}
