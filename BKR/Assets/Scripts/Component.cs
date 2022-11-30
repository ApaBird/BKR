using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    [SerializeField] private float distan = 0.5f;
    [SerializeField] private Color selectColor;
    [SerializeField] private bool isWhiteList;
    [SerializeField] private List<string> whiteList = new List<string>();
    [SerializeField] private string nameComponent = "Component";
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
        this.transform.position -= Vector3.forward;
    }

    public void Unselect()
    {
        selected = false;
        if (outline != null)
        {
            outline.OutlineOff();
        }
        this.transform.position += Vector3.forward;
    }

    public string GetName() => nameComponent;

    public bool CheckUnselect()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D underObject = Physics2D.Raycast(this.transform.position, Vector3.forward);
        this.GetComponent<BoxCollider2D>().enabled = true;
        if (underObject.collider != null)
            if (underObject.collider.GetComponent<Component>())
                if (whiteList.Contains(underObject.collider.GetComponent<Component>().GetName()) == isWhiteList)
                    return true;
                else
                    return false;
            else
                return true;
        else
            return true;
    }
}
