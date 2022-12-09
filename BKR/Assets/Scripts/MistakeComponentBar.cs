using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakeComponentBar : MonoBehaviour
{
    [SerializeField] private List<Component> components = new List<Component>();
    [SerializeField] private int sizeCell;
    private RectTransform rect;


    private void Start()
    {
        rect = this.GetComponent<RectTransform>();
        int i = 0;
        foreach (Component a in components)
        {
                GameObject z = Instantiate<GameObject>(a.GetSprite(), rect);//Тут говорит что в качестве создаваемого объекта null
                z.GetComponent<RectTransform>().anchoredPosition += Vector2.right * i * sizeCell;
                i += 1;
        }
    }
}
