using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSave : MonoBehaviour
{
    [SerializeField] private string nameComponent = "Component";

    public string GetName() => nameComponent;

    public ComponentInfo Save()
    {
        return new ComponentInfo { Name = this.nameComponent, Position = this.transform.position, Rotate = this.transform.rotation };
    }
}
