using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Component : MonoBehaviour
{
    [SerializeField] private List<ILogicComponent> listLogicBlock = new List<ILogicComponent>();
    
    public List<ILogicComponent> GetListLogicBlock()
    {
        return listLogicBlock;
    }
}
