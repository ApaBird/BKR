using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRobotComponent : MonoBehaviour
{
    // ������� ���������
    [SerializeField] private string name;

    public string GetName() => name;
}
