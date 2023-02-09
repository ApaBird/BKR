using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComponentBar : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private List<GameObject> components = new List<GameObject>();
    [SerializeField] private int sizeCell;
    private RectTransform rect;
    bool scrolling = false;
    Vector2 lastPos;

    private void Start()
    {
        rect = this.GetComponent<RectTransform>();
        int i = 0;
        foreach (GameObject a in components)
        {
            if (a.GetComponent<Preview>())
            {
                GameObject z = Instantiate<GameObject>(a.GetComponent<Preview>().GetSprite(), rect);
                z.GetComponent<RectTransform>().anchoredPosition += Vector2.right * i * sizeCell;
                z.GetComponent<RectTransform>().anchoredPosition3D += new Vector3(0, 0, -0.1f);
                i += 1;
            }
        }
    }
    public void OnMouseDown()
    {
        if (scrolling)
        {
            lastPos = Input.mousePosition;
            scrolling = true;
        }
    }

    private void Update()
    {
        if (scrolling)
        {
            Debug.Log("work");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        scrolling = false;
    }

    


}
