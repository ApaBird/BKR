using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawn : MonoBehaviour
{
    private GameObject robot;

    public void SetRobot(GameObject r)
    {
        robot = r;
    }

    public void SpawnRobot()
    {
        if (robot != null)
        {
            Destroy(robot);
            robot = Instantiate<GameObject>(robot, this.transform);
        }
    }
}
