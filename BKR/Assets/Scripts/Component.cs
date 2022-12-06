using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : IClickComponent
{
    [SerializeField] private float distan = 0.5f;
    [SerializeField] private Color selectColor;
    [SerializeField] private bool isWhiteList;
    [SerializeField] private List<string> whiteList = new List<string>();
    [SerializeField] private string nameComponent = "Component";
    private Camera camera;
    private Outline outline = null;
    private RaycastHit2D[] rays = new RaycastHit2D[4];
    private bool selected = false;
    private Vector3 mousePosition;
    private Vector3 lastMousePosition;
    

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
        else
        {
            mousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(camera.transform.position.z));
            Vector3 moveVector = new Vector3(mousePosition.x - lastMousePosition.x, mousePosition.y - lastMousePosition.y, 0);
            this.transform.position += moveVector;
            lastMousePosition = mousePosition;
        }
    }

    public override GameObject Select(Camera cam)
    {
        selected = true;
        if (outline != null)
        {
            outline.SetColor("selectColor");
            outline.OutlineOn();
        }
        camera = cam;
        this.transform.position -= Vector3.forward;
        mousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(camera.transform.position.z));
        lastMousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(camera.transform.position.z));
        return this.gameObject;
    }

    public override void Unselect()
    {
        if (CheckUnselect())
        {
            selected = false;
            if (outline != null)
            {
                outline.OutlineOff();
            }
            this.transform.position += Vector3.forward;
        }
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
