using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotOutput : IClickComponent
{
    private DotInput dotInput = null;
    private bool selected = false;
    private Camera camera;
    private Vector2 mousePosition;
    [SerializeField] private LineRenderer lr;

    private void Start()
    {
        camera = Camera.main;
    }

    public override GameObject Select(Camera cam)
    {
        selected = true;
        camera = cam;
        if (dotInput != null)
            dotInput.SetDotOutput(null);
        dotInput = null;
        return this.gameObject;
    }

    public override void Unselect()
    {
        lr.SetPosition(0, this.transform.position);
        selected = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        RaycastHit2D underObject = Physics2D.Raycast(mousePosition, Vector3.forward);
        this.GetComponent<CircleCollider2D>().enabled = true;
        if (underObject.collider != null && underObject.collider.GetComponent<DotInput>())
        {
            dotInput = underObject.collider.GetComponent<DotInput>();
            dotInput.SetDotOutput(this);
            lr.SetPosition(1, dotInput.transform.position);
        }
        else
        {
            dotInput = null;
            lr.SetPosition(1, this.transform.position);
        }
    }

    void Update()
    {
        mousePosition = camera.ScreenPointToRay(Input.mousePosition).GetPoint(Mathf.Abs(camera.transform.position.z));
        lr.SetPosition(0, this.transform.position);
        if (dotInput != null)
            lr.SetPosition(1, dotInput.transform.position);
        else if (selected)
            lr.SetPosition(1, new Vector3(mousePosition.x, mousePosition.y) + Vector3.back);
        else
            lr.SetPosition(1, this.transform.position);

    }
}
