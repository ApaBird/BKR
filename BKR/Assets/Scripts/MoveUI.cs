using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector2 endPos;
    [SerializeField] private float speed;
    private Vector2 beginPos;
    private RectTransform rect;
    private bool select = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        select = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        select = false;
    }

    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        beginPos = rect.anchoredPosition;
    }

    private void Update()
    {
        if (select)
        {
            if (rect.anchoredPosition != endPos)
                rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, endPos, speed);
        }
        else
        {
            if (rect.anchoredPosition != beginPos)
                rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, beginPos, speed);
        }

    }
}
