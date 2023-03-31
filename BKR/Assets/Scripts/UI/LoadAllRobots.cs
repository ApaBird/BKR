using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class LoadAllRobots
{
    [SerializeField] private static string path = "Robots/";
    public static string[] GetRobotFiles() { return Directory.GetFiles(path); }
}
