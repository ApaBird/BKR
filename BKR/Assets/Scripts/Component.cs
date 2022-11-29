using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    [SerializeField] private float distan = 0.5f;
    [SerializeField] private Color selectColor;
    private Outline outline = null;
    private RaycastHit2D[] rays = new RaycastHit2D[4];
    [SerializeField] private bool selected = false;

    private void Start()
    {
        if (this.GetComponent<Outline>())
        {
            outline = this.GetComponent<Outline>();
            outline.AddColor("selectColor", selectColor);
        }
    }

    private void Update()
    {
        if (!selected)
            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y), 0);
    }

    public void Select()
    {
        selected = true;
        if (outline != null)
        {
            outline.SetColor("selectColor");
            outline.OutlineOn();
        }
    }

    public void Unselect()
    {
        selected = false;
        if (outline != null)
        {
            outline.OutlineOff();
        }
    }


}
