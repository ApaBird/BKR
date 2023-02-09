using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotOutput : IClickComponent
{
    private DotInput dotInput = null;
    private bool selected = false;
    private Camera camera;
    private Vector2 mousePosition;
    [SerializeField] private LineRenderer line;

    private void Start()
    {
        camera = Camera.main;
    }

    public override GameObject Select(Camera cam)//Когда перехватываешь в точке входа линия становиться вечно выбраная при не активной точке
    {
        selected = true;
        if (dotInput != null)
            dotInput.SetDotOutput(null);
        dotInput = null;
        return this.gameObject;
    }

    public override void Unselect()
    {
        line.SetPosition(0, this.transform.position);
        selected = false;
        this.GetComponent<CircleCollider2D>().enabled = false;//Зачем?
        RaycastHit2D underObject = Physics2D.Raycast(mousePosition, Vector3.forward);
        this.GetComponent<CircleCollider2D>().enabled = true;
        if (underObject.collider != null && underObject.collider.GetComponent<DotInput>())
        {
            dotInput = underObject.collider.GetComponent<DotInput>();
            dotInput.Select(camera);
            dotInput.SetDotOutput(this);
            line.SetPosition(1, dotInput.transform.position);
        }
        else
        {
            dotInput = null;
            line.SetPosition(1, this.transform.position);
        }
    }

    public void SetDotInput(DotInput dot)
    {
        if (dot == null)
            selected = false;
         dotInput = dot;
    }

    void Update()
    {
        mousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(camera.transform.position.z));
        line.SetPosition(0, this.transform.position);
        if (dotInput != null)
            line.SetPosition(1, dotInput.transform.position);
        else if (selected)
            line.SetPosition(1, new Vector3(mousePosition.x, mousePosition.y) + Vector3.back);
        else
            line.SetPosition(1, this.transform.position);

    }
}
