using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void SwithMenu()
    {
        if(menu.activeSelf)
            menu.SetActive(false);
        else    
            menu.SetActive(true);
    }
}
