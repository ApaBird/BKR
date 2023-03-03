using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropBox : IClickComponent
{
    private List<string> values = new List<string>();
    private int selected = 0;
    [SerializeField] private GameObject list;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject prefabElement;
    [SerializeField] private float offset = 0.5f;
    [SerializeField] private float interval = 0.45f;

    public void SetList(List<string> list)
    {
        values = list;
        foreach (string s in values)
        {
            GameObject element = Instantiate(prefabElement, transform.position, prefabElement.transform.rotation, this.list.transform);
            element.transform.position -= new Vector3(0, offset, 0);
            element.GetComponent<ElementDropBox>().SetText(s);
            offset += interval;
        }
        text.text = values[selected];
        this.list.SetActive(false);
    }

    public string GetValue() => values[selected];

    public override void Unselect()
    {
        list.SetActive(false);
    }

    public override GameObject Select(Camera cam)
    {
        list.SetActive(true);
        return null;
    }

    public void ChioceElement(string numElement)
    {
        selected = values.IndexOf(numElement);
        text.text = values[selected];
        Unselect();
    }
}
